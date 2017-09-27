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
    public class HighlightBlcokRun : MatlabRun
    {
        public HighlightBlcokRun(string blockPath)
        {
            this.blockPath = blockPath;
        }

        public override ErrorResult RunSync()
        {

            MatlabCommand highlightBlockCommand = MatlabCommandBuilder.GeHighlightBlcokMatlabCommand(blockPath);
            return SyncRunCommand(highlightBlockCommand);
        }



        protected override MatlabRunOutput GetMatlabRunOutput()
        {
            return new SingleTestRunOutput(outputLogPath);
        }

        public static string ModelRunningTimeStr = "modelRunningTime=";
        private string blockPath = "";
    }
}
