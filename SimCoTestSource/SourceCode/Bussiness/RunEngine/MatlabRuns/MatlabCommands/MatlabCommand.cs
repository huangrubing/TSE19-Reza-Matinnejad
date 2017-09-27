using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands
{
    public class MatlabCommand  
    {
        public void LoadFromMatlabScript(string filePath)
        {
            SetFileString(File.ReadAllLines(filePath));
            return;
        }

        public virtual void ReplaceInTemplate(string toBeReplaced, string toReplace)
        {

        }
        
        public virtual void ReplaceInTemplate(string toBeReplaced, MatlabCommand toReplace)
        {

        }
        
        public void SaveToMatlabScript(string filePath)
        {
            File.WriteAllLines(filePath, GetFileString());
            return;
        }

        protected virtual string[] GetFileString()
        {
            return null;
        }
        
        protected virtual void SetFileString(string[] fileString)
        {
            return;
        }

    }
}
