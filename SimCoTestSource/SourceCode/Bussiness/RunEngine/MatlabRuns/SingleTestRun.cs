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

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns
{
    public class SingleTestRun : MatlabRun
    {
        public SingleTestRun(TestWorkspace testWorkSpace,CCTestCase ccTestCase,
            ISingleTestRunProgressListener singleTestRunProgressListener)
        {
            this.testWorkspace = testWorkSpace;
            this.ccTestCase = ccTestCase;
            this.singleTestRunProgressListener = singleTestRunProgressListener;
        }

        public SingleTestRun(TestWorkspace testWorkSpace, SLTestCase sbTestCase,
            ISingleTestRunProgressListener singleTestRunProgressListener)
        {
            this.testWorkspace = testWorkSpace;
            this.sbTestCase = sbTestCase;
            this.singleTestRunProgressListener = singleTestRunProgressListener;
        }

        protected override void ReportResultsOnRunFinish(MatlabRunOutput matlabRunOutput)
        {
            singleTestRunProgressListener.TestFinished(matlabRunOutput.CheckOutput());
        }
        
        /*public override void RunSync()
        {
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            File.Delete(outputLogPath);

            if(testWorkspace is CCTestWorkspace)
                RunCCTestCase();
            if (testWorkspace is SBTestWorkspace)
                RunSBTestCase();

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(testWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");
            SyncRunMainScript();
        }*/

        public override void RunAsync()
        {
            MatlabAsyncProgram.KillMatlab();
            matlabAsyncProgram = new MatlabAsyncProgram(testWorkspace.modelSettings.MatlabExePath);


            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            File.Delete(outputLogPath);

            if (testWorkspace is CCTestWorkspace)
                RunCCTestCase();
            if (testWorkspace is SLTestWorkspace)
                RunSBTestCase();

            MatlabCommand modelSettingsCommand = MatlabCommandBuilder.GetModelSettingsMatlabCommand(testWorkspace.modelSettings);
            modelSettingsCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.ModelSettingsScriptFileName + ".m");
            AsyncRunMainScript();
        }

        private void RunCCTestCase()
        {
            CCTestWorkspace ccTestWorkspace = (CCTestWorkspace)testWorkspace;

            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();
            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\SingleTestRun.m");
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulationTimeVal]", testWorkspace.GetSimulationTime().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelPathVal]", testWorkspace.modelSettings.SimulinkModelPath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_InitialDesiredVal]", ccTestCase.initialDesired.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_FinalDesiredVal]", ccTestCase.finalDesired.ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_DesiredValueVar]", ccTestWorkspace.GetDesiredValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_ActualValueVar]", ccTestWorkspace.GetActualValueVariable().parameterName);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesNamesVar]", ccTestWorkspace.GetCalibrationVariableNamesStr());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesValuesVal]", ccTestWorkspace.GetCalibrationVariableValuesStr());

            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");
        }

        private void RunSBTestCase()
        {
            /*SLTestWorkspace sbTestWorkspace = (SLTestWorkspace)testWorkspace;

            CompositeMatlabCommand mainScriptCommand = new CompositeMatlabCommand();
            mainScriptCommand.LoadFromMatlabScript(templatePath + "\\SingleTestRun2.m");
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CodeRootVal]", codePath);
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulationTimeVal]", testWorkspace.GetSimulationTime().ToString());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_SimulinkModelPathVal]", testWorkspace.modelSettings.SimulinkModelPath);

            mainScriptCommand.ReplaceInTemplate("[MiLTester_InputVariablesNamesVar]", sbTestWorkspace.GetInputVariableNamesStr());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_InputVariablesInitialValuesVal]", sbTestCase.GetInputVariableInitialValuesStr(sbTestWorkspace.inputVariables));
            mainScriptCommand.ReplaceInTemplate("[MiLTester_InputVariablesFinalValuesVal]", sbTestCase.GetInputVariableFinalValuesStr(sbTestWorkspace.inputVariables));
            mainScriptCommand.ReplaceInTemplate("[MiLTester_InputVariablesStepTimesVal]", sbTestCase.GetInputVariableStepTimesStr(sbTestWorkspace.inputVariables));

            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesNamesVar]", sbTestWorkspace.GetCalibrationVariableNamesStr());
            mainScriptCommand.ReplaceInTemplate("[MiLTester_CalibrationVariablesValuesVal]", sbTestCase.GetCalibrationVariableValuesStr(sbTestWorkspace.calibrationVariables));

            mainScriptCommand.ReplaceInTemplate("[MiLTester_OutputVariableNameVar]", sbTestWorkspace.outputVariable.parameterName);

            mainScriptCommand.SaveToMatlabScript(tempPath + "\\" + MatlabCommandBuilder.MainScriptFileName + ".m");*/
        }

        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new SingleTestRunOutput(outputLogPath);
        }

        private ISingleTestRunProgressListener singleTestRunProgressListener;
        private CCTestCase ccTestCase;
        private SLTestCase sbTestCase;
        public static string ModelRunningTimeStr = "modelRunningTime=";
    }
}
