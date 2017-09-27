using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Workspace
{
    public class IOTestWorkspace : TestWorkspace
    {
        public IOTestWorkspace(String workspaceName)
            : base(workspaceName,FunctionTypeEnum.Input_Output )
        {

        }
    }
}
