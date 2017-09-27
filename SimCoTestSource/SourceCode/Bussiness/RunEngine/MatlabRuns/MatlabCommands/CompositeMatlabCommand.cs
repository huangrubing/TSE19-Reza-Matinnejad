using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands
{
    public class CompositeMatlabCommand : MatlabCommand
    {
        public override string ToString()
        {
            string commandStr="";
            for (int i = 0; i < MatlabCommands.Count; ++i)
                commandStr += MatlabCommands[i].ToString() + "\r\n";
            return commandStr;
        }

        protected override string[] GetFileString()
        {
            string[] commandLines = new string[MatlabCommands.Count];
            for (int i = 0; i < MatlabCommands.Count; ++i)
                commandLines[i] += MatlabCommands[i].ToString() + "\r\n";
            return commandLines;
        }

        protected override void SetFileString(string[] fileString)
        {
            for (int i = 0; i < fileString.Count(); ++i)
                AddCommand(new SingleMatlabCommand(fileString[i],false));
        }

        public override void ReplaceInTemplate(string toBeReplaced,string toReplace)
        {
            for (int i = 0; i < MatlabCommands.Count(); ++i)
                MatlabCommands[i].ReplaceInTemplate(toBeReplaced, toReplace);
        }

        public override void ReplaceInTemplate(string toBeReplaced, MatlabCommand toReplace)
        {
            for (int i = 0; i < MatlabCommands.Count(); ++i)
                MatlabCommands[i].ReplaceInTemplate(toBeReplaced, toReplace);
        }

        public void AddCommand(MatlabCommand matlabCommand)
        {
            MatlabCommands.Add(matlabCommand);
        }
        
        private List<MatlabCommand> MatlabCommands = new List<MatlabCommand>();
    }
}
