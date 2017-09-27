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
using MiLTester.SourceCode.Bussiness.RunEngine;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class TestRunProgressForm : Form, ISingleTestRunProgressListener
    {
        public TestRunProgressForm()
        {
            InitializeComponent();
            pbProgressBar.MarqueeAnimationSpeed /= 2; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            testErrorResult = new ErrorResult();
            testErrorResult.errorCode = ErrorCode.TestRunCanceled;
            singleTestRun.CancelRun();
            closeTimer.Stop();
            Close();
        }

        public void TestFinished(ErrorResult testErrorResult)
        {
            this.testErrorResult = testErrorResult;
            testFinished = true;
        }

        public ErrorResult TestRunModel(TestWorkspace testWorkspace, CCTestCase ccTestCase)
        {
            singleTestRun = new SingleTestRun(testWorkspace, ccTestCase, this);
            singleTestRun.RunAsync();
            CreateCloseTimer();
            ShowDialog();
            return testErrorResult;
        }

        public ErrorResult TestRunModel(TestWorkspace testWorkspace, SLTestCase sbTestCase)
        {
            singleTestRun = new SingleTestRun(testWorkspace, sbTestCase, this);
            singleTestRun.RunAsync();
            CreateCloseTimer();
            ShowDialog();
            return testErrorResult;
        }

        private void CreateCloseTimer()
        {
            closeTimer = new Timer();
            closeTimer.Interval = 1000;
            closeTimer.Tick += CloseForm;
            closeTimer.Start();
        }

        private void CloseForm(object Sender, EventArgs e)
        {
            if (testFinished)
            {
                closeTimer.Stop();
                Close();
            }
        }
        
        private void TestRunProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (testFinished)
                return;
            btnCancel_Click(null, null);
        }

        private SingleTestRun singleTestRun;
        private Timer closeTimer;
        private ErrorResult testErrorResult = null;
        private bool testFinished = false;
    }
}
