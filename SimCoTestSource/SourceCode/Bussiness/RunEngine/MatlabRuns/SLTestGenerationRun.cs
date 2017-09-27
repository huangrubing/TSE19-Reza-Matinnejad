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
    public class SLTestGenerationRun : MatlabRun
    {
        public SLTestGenerationRun(TestWorkspace testWorkSpace,
            ISLTestGenerationProgressListener slTestGenerationProgressListener)
        {
            this.testWorkspace = testWorkSpace;
            this.slTestGenerationProgressListener = slTestGenerationProgressListener;
        }

        protected override void ReportResultsOnRunFinish(MatlabRunOutput matlabRunOutput)
        {
            //randomExplorationProgressListener.RandomExplorationFinished(
            //    matlabRunOutput.CheckOutput(),
            //    ((RandomExplorationRunOutput)matlabRunOutput).GetRandomExplorationResultsFolderPath());
        }

        public override void RunAsync()
        {
            MatlabAsyncProgram.KillMatlab();
            matlabAsyncProgram = new MatlabAsyncProgram(testWorkspace.modelSettings.MatlabExePath);
            SLTestWorkspace slTestWorkspace = (SLTestWorkspace)testWorkspace;
            //if (Directory.Exists(tempPath))
            //    Directory.Delete(tempPath,true);
            //Directory.CreateDirectory(tempPath);
            //File.Delete(outputLogPath);

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(slTestWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");

            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();
            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\SLTestGeneration\\SLTestGenerationRun.m");
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ModelComltName]", testWorkspace.modelSettings.GetSimulinkModelNameWithNoExtension());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelPathVal]", testWorkspace.modelSettings.GetSimulinkModelDirectory());       
            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");

            AsyncRunMainScript();
        }
        
        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new MatlabRunOutput();
        }

        private ISLTestGenerationProgressListener slTestGenerationProgressListener;
        //public static string heatMapDiagramsFileName = "HeatMapDiagrams.csv";
        //public static string heatMapRegionsFileName = "HeatMapRegions.csv";
        //public static string randomExplorationResultsFileName = "RandomExplorationResults.csv";
        
        //public static string randomExplorationResultsFolderPath = tempPath + "\\RandomExploration";
        //protected static string randomExplorationResultsFilePath = randomExplorationResultsFolderPath + "\\" + randomExplorationResultsFileName;
        //protected static string heatMapDiagramsFilePath = randomExplorationResultsFolderPath + "\\" + heatMapDiagramsFileName;
        //protected static string heatMapRegionsFilePath = randomExplorationResultsFolderPath + "\\" + heatMapRegionsFileName;
    }
}
