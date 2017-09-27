using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners;
using MiLTester.SourceCode.Bussiness.Workspace;
using System.IO;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns
{
    public class SingleStateSearchRun : MatlabRun
    {
        public SingleStateSearchRun(TestWorkspace testWorkSpace,
            ISingleStateSearchRunProgressListener singleStateSearchRunProgressListener,
            List<HeatMapRegion> heatMapRegions)
        {
            this.testWorkspace = testWorkSpace;
            this.heatMapRegions = heatMapRegions;
            this.singleStateSearchRunProgressListener = singleStateSearchRunProgressListener;
        }
        
        protected override void ReportResultsOnRunFinish(MatlabRunOutput matlabRunOutput)
        {
            int count = 0;
            while (count<worstCaseHeatMapRegions.Count)
            {
                if (!worstCaseHeatMapRegions[worstCaseHeatMapRegions.ElementAt(count).Key])
                {
                    worstCaseHeatMapRegions[worstCaseHeatMapRegions.ElementAt(count).Key] = true;
                    RunSingleStateSearchInRegion(worstCaseHeatMapRegions.ElementAt(count).Key);
                    return;
                }
                ++count;
            }
            singleStateSearchRunProgressListener.SingleStateSearchFinished(
                matlabRunOutput.CheckOutput(),
                ((SingleStateSearchRunOutput)matlabRunOutput).GetSingleStateSearchResultsFolderPath());
        }
        
        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new SingleStateSearchRunOutput(outputLogPath, singleStateSeachResultsFolderPath);
        }

        public override void RunAsync()
        {
            List<HeatMapRegion> worstHeatMapRegions=((CCTestWorkspace)testWorkspace).ccSettings.
                GetWorstHeatMapRegions(heatMapRegions,"Stability");
            worstHeatMapRegions.AddRange(((CCTestWorkspace)testWorkspace).ccSettings.
                GetWorstHeatMapRegions(heatMapRegions,"Liveness"));
            worstHeatMapRegions.AddRange(((CCTestWorkspace)testWorkspace).ccSettings.
                GetWorstHeatMapRegions(heatMapRegions, "Smoothness"));
            worstHeatMapRegions.AddRange(((CCTestWorkspace)testWorkspace).ccSettings.
                GetWorstHeatMapRegions(heatMapRegions, "NormalizedSmoothness"));
            worstHeatMapRegions.AddRange(((CCTestWorkspace)testWorkspace).ccSettings.
                GetWorstHeatMapRegions(heatMapRegions, "Responsiveness"));

            foreach (HeatMapRegion heatMapRegion in worstHeatMapRegions)
                worstCaseHeatMapRegions.Add(heatMapRegion, false);
            if (worstCaseHeatMapRegions.Count <= 0)
            {
                ErrorResult testErrorResult=new ErrorResult();
                testErrorResult.errorCode=ErrorCode.Success;
                singleStateSearchRunProgressListener.SingleStateSearchFinished(testErrorResult);
                return;
            }
            worstCaseHeatMapRegions[worstCaseHeatMapRegions.ElementAt(0).Key] = true;
            RunSingleStateSearchInRegion(worstCaseHeatMapRegions.ElementAt(0).Key);
        }

        public void RunSingleStateSearchInRegion(HeatMapRegion heatMapRegion)
        {
            MatlabAsyncProgram.KillMatlab();
            matlabAsyncProgram = new MatlabAsyncProgram(testWorkspace.modelSettings.MatlabExePath);
            CCTestWorkspace ccTestWorkspace = (CCTestWorkspace)testWorkspace;

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            File.Delete(outputLogPath);

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(ccTestWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");

            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();

            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\SingleStateSearch-Common.m");
            CompositeMatlabCommand GenerateNewValuesCommand = new CompositeMatlabCommand();
            CompositeMatlabCommand ReplaceValuesCommand = new CompositeMatlabCommand();
            if (ccTestWorkspace.advancedCCSettings.singelStateSearchAlgorithm == SingelStateSearchAlgorithmsEnum.RandomSearch)
            {
                GenerateNewValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\RandomSearch\\SingleStateSearch-RandomSearchGenerateValues.m");
                ReplaceValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\RandomSearch\\SingleStateSearch-RandomSearchReplaceValues.m");
            }
            else if (ccTestWorkspace.advancedCCSettings.singelStateSearchAlgorithm == SingelStateSearchAlgorithmsEnum.HillClimbing)
            {
                GenerateNewValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\HillClimbing\\SingleStateSearch-HillClimbingGenerateValues.m");
                GenerateNewValuesCommand.ReplaceInTemplate("[MiLTester_EASigmalVal]", ccTestWorkspace.GetSigmaForSingleStateSearch().ToString());
                ReplaceValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\HillClimbing\\SingleStateSearch-HillClimbingReplaceValues.m");
            }
            else if (ccTestWorkspace.advancedCCSettings.singelStateSearchAlgorithm == SingelStateSearchAlgorithmsEnum.HCRR)
            {
                GenerateNewValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\HCRR\\SingleStateSearch-HillClimbingGenerateValues.m");
                GenerateNewValuesCommand.ReplaceInTemplate("[MiLTester_EASigmalVal]", ccTestWorkspace.GetSigmaForSingleStateSearch().ToString());
                ReplaceValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\HCRR\\SingleStateSearch-HillClimbingReplaceValues.m");
            }
            else if (ccTestWorkspace.advancedCCSettings.singelStateSearchAlgorithm == SingelStateSearchAlgorithmsEnum.SimulatedAnnealing)
            {
                GenerateNewValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\SimulatedAnnealing\\SingleStateSearch-SimulatedAnnealingGenerateValues.m");
                GenerateNewValuesCommand.ReplaceInTemplate("[MiLTester_EASigmalVal]", ccTestWorkspace.GetSigmaForSingleStateSearch().ToString());
                ReplaceValuesCommand.LoadFromMatlabScript(templatePath + "\\SingleStateSearch\\SimulatedAnnealing\\SingleStateSearch-SimulatedAnnealingReplaceValues.m");
                ReplaceValuesCommand.ReplaceInTemplate("[MiLTester_AnnealingScheduleVal]", ccTestWorkspace.GetAnnealingScheduleForSingleStateSearch().ToString());

            }

            mainScriptCommand.ReplaceInTemplate("[MiLTester_GenerateNewValuesCode]", GenerateNewValuesCommand);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ReplaceValuesCode]", ReplaceValuesCommand);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulationTimeVal]", testWorkspace.GetSimulationTime().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelPathVal]", testWorkspace.modelSettings.SimulinkModelPath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SearchVariablesCntVal]", ccTestWorkspace.GetSearchVariablesCnt().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RegionWidthRangeStartVal]", heatMapRegion.xStart.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RegionWidthRangeStopVal]", heatMapRegion.xEnd.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RegionHeightRangeStartVal]", heatMapRegion.yStart.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RegionHeightRangeStopVal]", heatMapRegion.yEnd.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_WorstPointFromRandomExplorationInitialDesiredVal]", heatMapRegion.worstCasePointFromRandomExploration.x.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_WorstPointFromRandomExplorationFinalDesiredVal]", heatMapRegion.worstCasePointFromRandomExploration.y.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_AlgorithmRoundsVal]", ccTestWorkspace.advancedCCSettings.algorithmRounds.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_AlgorithmIterationsVal]", ccTestWorkspace.advancedCCSettings.algorithmIterations.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SelectedObjectiveFunction]", heatMapRegion.requirementName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_DesiredValueVar]", ccTestWorkspace.GetDesiredValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ActualValueVar]", ccTestWorkspace.GetActualValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RegionWidthIndexVal]", heatMapRegion.indexX.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RegionHeightIndexVal]", heatMapRegion.indexY.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RangeStartVal]", ccTestWorkspace.GetDesiredValueVariable().from.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RangeStopVal]", ccTestWorkspace.GetDesiredValueVariable().to.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_AnnealingStartTemprature]", ccTestWorkspace.GetAnnealingStartTemprature().ToString());
            
            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");

            AsyncRunMainScript();
        }
        private List<HeatMapRegion> heatMapRegions;
        private Dictionary<HeatMapRegion,bool> worstCaseHeatMapRegions = new Dictionary<HeatMapRegion,bool>();
        private ISingleStateSearchRunProgressListener singleStateSearchRunProgressListener;
        public static string singleStateSeachResultsFileName = "SingleStateSearchResults.csv";
        
        protected static string singleStateSeachResultsFolderPath = tempPath + "\\SingleStateSearch";
        protected static string singleStateSeachResultsFilePath = singleStateSeachResultsFolderPath + "\\" + singleStateSeachResultsFileName;
    }
}
