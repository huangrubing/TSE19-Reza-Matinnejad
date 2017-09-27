using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners
{
    public interface ISLTestGenerationProgressListener
    {
        void SLTestGenerationFinished(ErrorResult testErrorResult, 
            string slTestResultDirectory);
    }
}
