using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Service
{
    public static class UtilityClass
    {
        public static void CopyDirectory(string sourceDirectoy, string targetDirectoy)
        {
            List<string> filePaths = new List<string>(Directory.EnumerateFiles(sourceDirectoy));
            foreach (string filePath in filePaths)
            {
                int startIndexOfFileName = filePath.LastIndexOf('\\');
                string fileName = filePath.Substring(startIndexOfFileName + 1);
                File.Copy(filePath, targetDirectoy + fileName,true);
            }
            List<string> directoriesPath = new List<string>(Directory.EnumerateDirectories(sourceDirectoy));
            foreach (string directoryPath in directoriesPath)
            {
                int startIndexOfFileName = directoryPath.LastIndexOf('\\');
                string directoryName = directoryPath.Substring(startIndexOfFileName + 1);
                Directory.CreateDirectory(targetDirectoy + directoryName);
                CopyDirectory(directoryPath, targetDirectoy + directoryName + "\\");
            }
        }
    }
}
