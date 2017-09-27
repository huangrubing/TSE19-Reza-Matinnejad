using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;
using System.IO;
using System.Text.RegularExpressions;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput
{
    public class MatlabRunOutput
    {
        public virtual bool IsReady(out bool SuccessOrError)
        {
            SuccessOrError = false;
            try
            {
                if (!File.Exists(outputLogPath))
                    return false;
                string fileText = File.ReadAllText(outputLogPath);
                if (fileText.Contains(SingleTestRun.SimulationFinishStr))
                {
                    SuccessOrError = true;
                    return true;
                }
                if (fileText.Contains(SingleTestRun.SimulationErrorStr))
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }


        public virtual ErrorResult CheckOutput()
        {
            ErrorResult errorResult = new ErrorResult();
            errorResult.errorCode = ErrorCode.Success;
            return errorResult;
        }

        protected string outputLogPath;

    }
}
