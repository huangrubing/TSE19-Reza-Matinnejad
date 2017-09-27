using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.RunEngine;
using System.Windows.Forms;
using System.IO;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using System.Threading;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners;
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns
{
    public class ExtractInfoRun : MatlabRun
    {
        public ExtractInfoRun(TestWorkspace testWorkSpace)
        {
            this.testWorkspace = testWorkSpace;
        }

        public override ErrorResult RunSync()
        {
            RunExtractInfo();

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(testWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");
            return SyncRunMainScript();
        }

        private void RunExtractInfo()
        {
            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();
            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\ExtractInfo.m");
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelNameVal]", testWorkspace.modelSettings.GetSimulinkModelNameWithNoExtension());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelDirVal]", testWorkspace.modelSettings.GetSimulinkModelDirectory());

     
            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");
        }

        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new SingleTestRunOutput(outputLogPath);
        }

        public static string ModelRunningTimeStr = "modelRunningTime=";
    }
}
