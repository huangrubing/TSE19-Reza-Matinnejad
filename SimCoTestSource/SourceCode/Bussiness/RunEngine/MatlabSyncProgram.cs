using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;
using System.Windows.Forms;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine
{
    public static class MatlabSyncProgram
    {
       private static MLApp.MLApp matlab = new MLApp.MLApp();

        public static void Run(SingleTestRun singleTestRun)
        {

        }

        public static ErrorResult RunMatlab(MatlabCommand matlabCommand, bool silentMode)
        {
            string commandString = matlabCommand.ToString();
            matlab.Visible=0;
            string ans=matlab.Execute(commandString);
            return new ErrorResult();
        }

        public static void KillMatlab()
        {
            try
            {
              matlab.Quit();                  
            }
            catch(Exception)
            {
            }
        }
    }
}
