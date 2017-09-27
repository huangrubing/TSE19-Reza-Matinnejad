using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.RunEngine;
using System.IO;
using System.Text.RegularExpressions;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using System.Threading;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns
{
    public class MatlabRun
    {
        public virtual ErrorResult RunSync()
        {
            return new ErrorResult();
        }

        public virtual void RunAsync()
        {
        }
        
        protected void FinishWaitFunction()
        {
            matlabRunOutput = GetMatlabRunOutput();
            while (!runCanceled && !RunIsFinished(matlabRunOutput))
                System.Threading.Thread.Sleep(1000);
            if (runCanceled)
                return;
            ReportResultsOnRunFinish(matlabRunOutput);
        }

        protected virtual void ReportResultsOnRunFinish(MatlabRunOutput matlabRunOutput)
        {
        }

        protected virtual MatlabRunOutput GetMatlabRunOutput()
        {
            return new MatlabRunOutput();
        }

        protected virtual bool RunIsFinished(MatlabRunOutput matlabRunOutput)
        {
            bool SuccessOrError;
            return matlabRunOutput.IsReady(out SuccessOrError);
        }

        protected ErrorResult SyncRunCommand(MatlabCommand toRunCommand)
        {
            //SingleMatlabCommand toRunCommand = new SingleMatlabCommand(commandString);
            runCanceled = false;

            return MatlabSyncProgram.RunMatlab(toRunCommand, true);
        }

        protected ErrorResult SyncRunMainScript()
        {
            CompositeMatlabCommand toRunCommand = new CompositeMatlabCommand();
            toRunCommand.AddCommand(new SingleMatlabCommand("addpath('" + tempPath + "')"));
            toRunCommand.AddCommand(new SingleMatlabCommand("run('" + MatlabCommandBuilder.MainScriptFileName + "')"));
            runCanceled = false;

            return MatlabSyncProgram.RunMatlab(toRunCommand, true);
        }

        protected void AsyncRunMainScript()
        {
            CompositeMatlabCommand toRunCommand = new CompositeMatlabCommand();
            toRunCommand.AddCommand(new SingleMatlabCommand("addpath('" + tempPath + "')"));
            toRunCommand.AddCommand(new SingleMatlabCommand("run('" + MatlabCommandBuilder.MainScriptFileName + "')"));
            runCanceled = false;
            
            Thread finishWaitThread = new Thread(this.FinishWaitFunction);
            finishWaitThread.Start();
            matlabAsyncProgram.RunMatlab(toRunCommand, true);
        }
        
        public void CancelRun()
        {
            MatlabAsyncProgram.KillMatlab();
            runCanceled = true;
        }

        protected MatlabAsyncProgram matlabAsyncProgram;
        protected MatlabRunOutput matlabRunOutput;
        protected TestWorkspace testWorkspace;
        protected bool runCanceled;

        protected static string codePath = Application.StartupPath + "\\MiLTesterFiles\\Code";
        protected static string functionsPath = codePath + "\\Functions";
        protected static string objectiveFunctionsPath = functionsPath + "\\ObjectiveFunctions";
        protected static string otherFunctionsPath = functionsPath + "\\OtherFunctions";
        protected static string tempPath = codePath + "\\Temp";
        protected static string templatePath = codePath + "\\Templates";
        protected static string outputLogPath = tempPath + "\\output.log";


        public static string InputValuesNameStr = "TestInputValues";
        public static string TestOututValuesStr = "TestOututValues";
        public static string SimulationFinishStr = "finished successfully with no error";
        public static string SimulationErrorStr = "Error in";
    }
}
