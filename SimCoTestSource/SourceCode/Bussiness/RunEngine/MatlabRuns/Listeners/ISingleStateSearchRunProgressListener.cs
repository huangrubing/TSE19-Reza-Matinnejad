using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners
{
    public interface ISingleStateSearchRunProgressListener
    {
        void SingleStateSearchFinished(ErrorResult testErrorResult);
        void SingleStateSearchFinished(ErrorResult testErrorResult,
            string singleStateSearchResultsDirectory);
    }
}
