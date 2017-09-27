using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class ExtractInfoForm : Form
    {
        public ExtractInfoForm()
        {
            InitializeComponent();
        }

        public ErrorResult ExtractInfo(TestWorkspace testWorkspace)
        {
            ExtractInfoRun extractInfoRun = new ExtractInfoRun(testWorkspace);
            return extractInfoRun.RunSync();

        }
    }
}
