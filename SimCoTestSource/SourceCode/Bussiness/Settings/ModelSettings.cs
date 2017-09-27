using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;
using System.IO;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using System.Windows.Forms;

namespace MiLTester.SourceCode.Bussiness.Settings
{
    public class ModelSettings
    {
        public string GetSimulinkModelName()
        {
            if (SimulinkModelPath.Length == 0 ||
                !SimulinkModelPath.Contains('\\'))
                return "";
            int start = SimulinkModelPath.Length - 1;
            for (; SimulinkModelPath[start] != '\\'; --start) ;
            return SimulinkModelPath.Substring(start+1);
        }

        public string GetSimulinkModelNameWithNoExtension()
        {
            if (SimulinkModelPath.Length == 0 ||
                !SimulinkModelPath.Contains('\\'))
                return "";
            int start = SimulinkModelPath.Length - 1;
            for (; SimulinkModelPath[start] != '\\'; --start) ;
            string simMdl=SimulinkModelPath.Substring(start + 1);
            return simMdl.Replace(".mdl","");
        }

        public string GetSimulinkModelDirectory()
        {
            if (SimulinkModelPath.Length == 0 ||
                !SimulinkModelPath.Contains('\\'))
                return "";
            int start = SimulinkModelPath.Length - 1;
            for (; SimulinkModelPath[start] != '\\'; --start) ;
            return SimulinkModelPath.Substring(0,start);
        }

        public ErrorResult CehckSettings()
        {
            ErrorResult errorReult = new ErrorResult();
            if (!File.Exists(MatlabExePath))
            {
                errorReult.errorCode = ErrorCode.ModelSettingsMatlabExeError;
                return errorReult;
            }
            if (!File.Exists(SimulinkModelPath))
            {
                errorReult.errorCode = ErrorCode.ModelSettingsSimulinkModelError;
                return errorReult;
            }
            for (int i = 0; i < MatlabPaths.Count; ++i)
            {
                if (!Directory.Exists(MatlabPaths[i]))
                {
                    errorReult.errorCode = ErrorCode.ModelSettingsMatlabPathError;
                    errorReult.errorParemeter = i;
                    return errorReult;
                }
            }
            for (int i = 0; i < MatlabScriptsPaths.Count; ++i)
            {
                if (!File.Exists(MatlabScriptsPaths[i]))
                {
                    errorReult.errorCode = ErrorCode.ModelSettingsMatlabScriptError;
                    errorReult.errorParemeter = i;
                    return errorReult;
                }
            }
            errorReult.errorCode = ErrorCode.Success;
            return errorReult;
        }


        public String MatlabExePath = "";
        public String SimulinkModelPath = "";
        public List<String> MatlabPaths = new List<String>();
        public List<String> MatlabScriptsPaths = new List<String>();
    }
}
