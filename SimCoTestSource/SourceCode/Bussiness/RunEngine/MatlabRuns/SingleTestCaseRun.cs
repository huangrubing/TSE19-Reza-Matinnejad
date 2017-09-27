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
    public class SingleTestCaseRun : MatlabRun
    {
        public SingleTestCaseRun(TestWorkspace testWorkSpace,SLTestCase slTestCase)
        {
            this.testWorkspace = testWorkSpace;
            this.slTestCase = slTestCase;
        }

        //protected override void ReportResultsOnRunFinish(MatlabRunOutput matlabRunOutput)
        //{
        //    singleTestRunProgressListener.TestFinished(matlabRunOutput.CheckOutput());
        //}

        public override ErrorResult RunSync()
        {
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            File.Delete(outputLogPath);

            if (testWorkspace is SLTestWorkspace)
                RunSLTestCase();

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(testWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");
            return SyncRunMainScript();
        }

        public override void RunAsync()
        {
            MatlabAsyncProgram.KillMatlab();
            matlabAsyncProgram = new MatlabAsyncProgram(testWorkspace.modelSettings.MatlabExePath);


            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            File.Delete(outputLogPath);

            if (testWorkspace is SLTestWorkspace)
                RunSLTestCase();

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(testWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");
            AsyncRunMainScript();
        }

        private void RunSLTestCase()
        {
            SLTestWorkspace slTestWorkspace = (SLTestWorkspace)testWorkspace;

            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();
            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\SingleTestCaseRun.m");
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_DsrdOutNo]", slTestCase.dsrdOutNo.ToString()); 
            mainScriptCommand.ReplaceInTemplate("[MiLTester_DsrdTCNo]", slTestCase.dsrdTCNo.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_FilesDirectory]", slTestCase.filesDir);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_TestSuiteFilepath]", slTestCase.testSuiteDir);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulationTimeVal]", testWorkspace.GetSimulationTime().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulationStepTimesVal]", "0.01");
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ModelComltName]", testWorkspace.modelSettings.GetSimulinkModelNameWithNoExtension());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelPathVal]", testWorkspace.modelSettings.SimulinkModelPath);

            /*mainScriptCommand.ReplaceInTemplate("[MiLTester_InitialDesiredVal]", ccTestCase.initialDesired.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_FinalDesiredVal]", ccTestCase.finalDesired.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_DesiredValueVar]", ccTestWorkspace.GetDesiredValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ActualValueVar]", ccTestWorkspace.GetActualValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesNamesVar]", ccTestWorkspace.GetCalibrationVariableNamesStr());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesValuesVal]", ccTestWorkspace.GetCalibrationVariableValuesStr());*/

            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");
        }


        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new SingleTestRunOutput(outputLogPath);
        }

        private SLTestCase slTestCase;
        public static string ModelRunningTimeStr = "modelRunningTime=";
    }
}
