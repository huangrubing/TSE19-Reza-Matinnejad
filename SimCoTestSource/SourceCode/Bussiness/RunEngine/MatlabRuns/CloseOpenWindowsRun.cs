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
    public class CloseOpenWindowsRun : MatlabRun
    {
        public CloseOpenWindowsRun()
        {
            
        }

        public override ErrorResult RunSync()
        {

            MatlabCommand closeWindowsMatlabCommand = MatlabCommandBuilder.GetCloseWindowsMatlabCommand();
            return SyncRunCommand(closeWindowsMatlabCommand);
        }



        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new SingleTestRunOutput(outputLogPath);
        }

        public static string ModelRunningTimeStr = "modelRunningTime=";
    }
}
