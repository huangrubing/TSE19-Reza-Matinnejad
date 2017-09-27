using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput
{
    public class SingleStateSearchRunOutput : MatlabRunOutput
    {
        public SingleStateSearchRunOutput(string outputLogPath,
            string singleStateSearchResultsFolderPath)
        {
            this.outputLogPath = outputLogPath;
            this.singleStateSearchResultsFolderPath = singleStateSearchResultsFolderPath;
        }

        public string GetSingleStateSearchResultsFolderPath()
        {
            return singleStateSearchResultsFolderPath;
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
            errorResult.errorCode = ErrorCode.Success;
            return errorResult;
        }

        protected string singleStateSearchResultsFolderPath;
    }
}