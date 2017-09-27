using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Workspace
{
    public interface ITestWorkspaceAddRemoveListener
    {
        void TestWorkspaceAdded(TestWorkspace testWorkspace);
        void TestWorkspaceRemoved(TestWorkspace testWorkspace);
        void TestWorkspaceRenamed(TestWorkspace testWorkspace, string newTestWorkspaceName);
    }
}
