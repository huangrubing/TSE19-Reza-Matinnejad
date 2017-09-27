using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Common
{
    public enum ErrorCode
    {
        Success,
        ModelSettingsMatlabExeError,
        ModelSettingsSimulinkModelError,
        ModelSettingsMatlabPathError,
        ModelSettingsMatlabScriptError,
        TestRunCanceled,
        TestRunError,
        RandomExplorationResultsNotFound,
        HeatMapDiagramsNotFound,
        HeatMapRegionsNotFound,
        DupicateWorkspaceName
    }
    public class ErrorResult
    {   
        public ErrorCode errorCode;
        public int errorParemeter;

        public ErrorResult()
        {
            errorCode=ErrorCode.Success;
        }
    }
}
