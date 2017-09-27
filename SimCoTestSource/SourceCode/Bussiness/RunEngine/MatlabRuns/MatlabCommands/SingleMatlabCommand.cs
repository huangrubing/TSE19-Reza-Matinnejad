using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands
{
    public class SingleMatlabCommand : MatlabCommand
    {
        public SingleMatlabCommand(string command,bool endWithSemicolon = true)
        {
            this.CommandString = command;
            this.endWithSemicolon = endWithSemicolon;
        }

        public override string ToString()
        {
            if(endWithSemicolon)
                return CommandString + ";";
            return CommandString;
        }


        public override void ReplaceInTemplate(string toBeReplaced, string toReplace)
        {
            CommandString=CommandString.Replace(toBeReplaced, toReplace);
        }

        public override void ReplaceInTemplate(string toBeReplaced, MatlabCommand toReplace)
        {
            CommandString = CommandString.Replace(toBeReplaced, toReplace.ToString());
        }


        private bool endWithSemicolon;
        private string CommandString;
    }
}
