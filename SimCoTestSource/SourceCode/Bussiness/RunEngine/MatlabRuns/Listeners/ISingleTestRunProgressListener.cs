using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners
{
    public interface ISingleTestRunProgressListener
    {
        void TestFinished(ErrorResult testErrorResult);
    }
}
