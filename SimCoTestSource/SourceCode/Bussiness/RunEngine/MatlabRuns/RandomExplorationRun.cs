using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.RunEngine;
using MiLTester.SourceCode.Bussiness.Workspace;
using System.IO;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns
{
    public class RandomExplorationRun: MatlabRun
    {
        public RandomExplorationRun(TestWorkspace testWorkSpace, 
            IRandomExplorationProgressListener randomExplorationProgressListener)
        {
            this.testWorkspace = testWorkSpace;
            this.randomExplorationProgressListener = randomExplorationProgressListener;
        }

        protected override void ReportResultsOnRunFinish(MatlabRunOutput matlabRunOutput)
        {
            randomExplorationProgressListener.RandomExplorationFinished(
                matlabRunOutput.CheckOutput(),
                ((RandomExplorationRunOutput)matlabRunOutput).GetRandomExplorationResultsFolderPath());
        }

        public override void RunAsync()
        {
            MatlabAsyncProgram.KillMatlab();
            CCTestWorkspace ccTestWorkspace = (CCTestWorkspace)testWorkspace;
            if (Directory.Exists(tempPath))
                Directory.Delete(tempPath,true);
            Directory.CreateDirectory(tempPath);
            File.Delete(outputLogPath);

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(ccTestWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");

            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();

            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\RandomExploration\\RandomExplorationRun-Common.m");
            CompositeMatlabCommand GenerateNewValueCommand = new CompositeMatlabCommand();
            if (ccTestWorkspace.advancedCCSettings.randomExplorationAlgorithm == RandomExplorationAlgorithmsEnum.RandomSearch)
                GenerateNewValueCommand.LoadFromMatlabScript(templatePath + "\\RandomExploration\\RandomExplorationRun-RandomSearchGenerateValues.m");
            else if (ccTestWorkspace.advancedCCSettings.randomExplorationAlgorithm == RandomExplorationAlgorithmsEnum.AdaptiveRandomSearch)
            {
                GenerateNewValueCommand.LoadFromMatlabScript(templatePath + "\\RandomExploration\\RandomExplorationRun-AdaptiveRandomSearchGenerateNewValues.m");
                GenerateNewValueCommand.ReplaceInTemplate("[NumCandidatePointsInAdaptiveRandomVal]","5");
            }
            mainScriptCommand.ReplaceInTemplate("[MiLTester_GenerateNewValuesCode]", GenerateNewValueCommand);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulationTimeVal]", testWorkspace.GetSimulationTime().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelPathVal]", testWorkspace.modelSettings.SimulinkModelPath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_DesiredValueVar]", ccTestWorkspace.GetDesiredValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ActualValueVar]", ccTestWorkspace.GetActualValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_MinAlgorithmIterationsVal]",ccTestWorkspace.GetRandomExplorationMinAlgorithmIterations().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_MaxAlgorithmIterationsVal]",ccTestWorkspace.GetRandomExplorationMaxAlgorithmIterations().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_NumberOfPointsInEachRegionVal]",ccTestWorkspace.ccSettings.numberOfPointsInEachRegion.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_HeatMapDiagramDivisionFactorVal]", ccTestWorkspace.ccSettings.heatMapDiagramDivisionFactor.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RangeStartVal]",ccTestWorkspace.GetDesiredValueVariable().from.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_RangeStopVal]",ccTestWorkspace.GetDesiredValueVariable().to.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesNamesVar]", ccTestWorkspace.GetCalibrationVariableNamesStr());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesMinimumsVal]", ccTestWorkspace.GetCalibrationVariableMinimumsStr());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesMaximumsVal]", ccTestWorkspace.GetCalibrationVariableMaximumsStr());
            
            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");

            AsyncRunMainScript();
        }
        
        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new RandomExplorationRunOutput(outputLogPath, randomExplorationResultsFilePath,
                heatMapDiagramsFilePath, heatMapRegionsFilePath, randomExplorationResultsFolderPath);
        }

        private IRandomExplorationProgressListener randomExplorationProgressListener;
        public static string heatMapDiagramsFileName = "HeatMapDiagrams.csv";
        public static string heatMapRegionsFileName = "HeatMapRegions.csv";
        public static string randomExplorationResultsFileName = "RandomExplorationResults.csv";
        
        public static string randomExplorationResultsFolderPath = tempPath + "\\RandomExploration";
        protected static string randomExplorationResultsFilePath = randomExplorationResultsFolderPath + "\\" + randomExplorationResultsFileName;
        protected static string heatMapDiagramsFilePath = randomExplorationResultsFolderPath + "\\" + heatMapDiagramsFileName;
        protected static string heatMapRegionsFilePath = randomExplorationResultsFolderPath + "\\" + heatMapRegionsFileName;
    }
}
