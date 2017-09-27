using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;
using System.Windows.Forms;

namespace MiLTester.SourceCode.Bussiness.RunEngine
{
    public class MatlabAsyncProgram
    {
        public MatlabAsyncProgram(string programPath)
        {
            this.programPath = programPath;
        }

        public void Run(SingleTestRun singleTestRun)
        {
        }

        public void RunMatlab(MatlabCommand matlabCommand, bool silentMode)
        {
            string arguemntString = " -r \"" + matlabCommand.ToString() + "\"";
            Process process = new Process();
            process.StartInfo.Arguments = arguemntString;
            process.StartInfo.FileName = programPath;
            process.Start();
        }

        public static void KillMatlab()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName("matlab"))
                {
                    process.Kill();
                }
            }
            catch (Exception)
            {
            }
            do
            {
                System.Threading.Thread.Sleep(250);
                Application.DoEvents();
            } while (Process.GetProcessesByName("matlab").Count() != 0);

        }

        private string programPath;
    }
}
