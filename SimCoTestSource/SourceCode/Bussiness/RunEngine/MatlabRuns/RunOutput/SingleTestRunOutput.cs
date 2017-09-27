using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;
using System.IO;
using System.Text.RegularExpressions;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput
{
    public class SingleTestRunOutput : MatlabRunOutput
    {
        public SingleTestRunOutput(string outputLogPath)
        {
            this.outputLogPath = outputLogPath;
        }

        public override ErrorResult CheckOutput()
        {
            bool SuccessOrError;
            IsReady(out SuccessOrError);
            ErrorResult errorResult = new ErrorResult();
            if (!SuccessOrError)
            {
                errorResult.errorCode = ErrorCode.TestRunError;
                return errorResult;
            }
            string fileStr = File.ReadAllText(outputLogPath);
            string fileText = File.ReadAllText(outputLogPath);
            int indexModelRunningTime = fileStr.IndexOf(SingleTestRun.ModelRunningTimeStr);
            if (indexModelRunningTime < 0)
            {
                errorResult.errorCode = ErrorCode.TestRunError;
                return errorResult;
            }
            MatchCollection matches = Regex.Matches(fileStr.Substring(indexModelRunningTime), @"\d+");
            if (matches.Count <= 0)
            {
                errorResult.errorCode = ErrorCode.TestRunError;
                return errorResult;
            }
            int modelRunningTime = Int32.Parse(matches[0].Value);
            errorResult.errorCode = ErrorCode.Success;
            errorResult.errorParemeter = modelRunningTime;
            return errorResult;
        }
    }
}
