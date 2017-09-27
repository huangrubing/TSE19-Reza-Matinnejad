using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Presentation.Results;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Data;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.Listeners;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.RunEngine;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class TestProgressForm : Form, IRandomExplorationProgressListener, ISingleStateSearchRunProgressListener
    {
        public TestProgressForm(TestWorkspace testWorkspace)
        {
            InitializeComponent();
            this.testWorkspace = testWorkspace;
            lastEstimatedRemainingTime = testWorkspace.GetTestEstimatedRunningTime();
            currentActivityLastEstimatedRemainingTime = ((CCTestWorkspace)testWorkspace).GetRandomExplorationEstimatedRunningTime();
            lblElapsedTime.Text = elapsedTime.ToString();
            lblRemainingTime.Text = lastEstimatedRemainingTime.ToString();
            lblFinishTime.Text = (DateTime.Now + lastEstimatedRemainingTime).ToString();
        }

        private void TestProgressForm_Shown(object sender, EventArgs e)
        {
            lblCurrentActivity.Text = "Generating HeatMap Diagrams";
            CreateCloseAndElapseTimer();
            if (!((CCTestWorkspace)testWorkspace).advancedCCSettings.escapeRandomExploration)
            {
                randomExplorationRun = new RandomExplorationRun(testWorkspace, this);
                randomExplorationRun.RunAsync();
            }
            else
            {
                ErrorResult errorResult = new ErrorResult();
                errorResult.errorCode = ErrorCode.Success;
                RandomExplorationFinished(errorResult, RandomExplorationRun.randomExplorationResultsFolderPath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(!randomExplorationIsFinished)
                randomExplorationRun.CancelRun();
            else
                singleStateSearchRun.CancelRun();
            closeAndElapseTimer.Stop();
            Close();
        }

        private void CreateCloseAndElapseTimer()
        {
            closeAndElapseTimer = new Timer();
            closeAndElapseTimer.Interval = 1000;
            closeAndElapseTimer.Tick += CloseFormAndCount;
            closeAndElapseTimer.Start();
        }

        private void CloseFormAndCount(object Sender, EventArgs e)
        {
            if (testFinished)
            {
                closeAndElapseTimer.Stop();
                if (testErrorResult.errorCode == ErrorCode.Success)
                {
                    MatlabAsyncProgram.KillMatlab();
                    Hide();
                    if (testWorkspace.functionType == FunctionTypeEnum.Continuous_Controller)
                        new CCTestWorkspaceResultsForm((CCTestWorkspace)testWorkspace).ShowDialog();
                    return;
                }
                else
                {
                    MessageBox.Show("Error in running test! See more details about the error in Matlab!",
                        "Error in Running the Test", MessageBoxButtons.OK);
                    Close();
                    return;
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                UpdateProgressBars();
            });
        }

        private void UpdateProgressBars()
        {
            elapsedTime = elapsedTime.Add(oneSecondTimeSpan);
            currentActivityElapsedTime = currentActivityElapsedTime.Add(oneSecondTimeSpan);
            lblElapsedTime.Text = elapsedTime.ToString();
            if(currentActivityLastEstimatedRemainingTime.TotalSeconds>0)
                currentActivityLastEstimatedRemainingTime = 
                    currentActivityLastEstimatedRemainingTime.Subtract(oneSecondTimeSpan);
            if (lastEstimatedRemainingTime.TotalSeconds > 0)
                lastEstimatedRemainingTime = lastEstimatedRemainingTime.Subtract(oneSecondTimeSpan);
            lblRemainingTime.Text = lastEstimatedRemainingTime.ToString();
            lblFinishTime.Text = (DateTime.Now + lastEstimatedRemainingTime).ToString();
            pbTotal.Value =(int) ((elapsedTime.TotalSeconds * 100) / 
                (elapsedTime + lastEstimatedRemainingTime).TotalSeconds);
            lblTotalPercent.Text = pbTotal.Value.ToString() + " %"; ;
            pbCurrentActivity.Value = (int)((currentActivityElapsedTime.TotalSeconds * 100) /
                (currentActivityElapsedTime + currentActivityLastEstimatedRemainingTime).TotalSeconds);
            lblCurrentActivityPercent.Text = pbCurrentActivity.Value.ToString() + " %";
        }

        private void TestProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (testFinished)
                return;
            btnCancel_Click(null, null);
        }

        public void TestFinished(ErrorResult testErrorResult)
        {
            this.testErrorResult = testErrorResult;
            testFinished = true;
        }

        public void SingleStateSearchFinished(ErrorResult testErrorResult)
        {
            this.testErrorResult = testErrorResult;
            testFinished = true;
        }

        public void SingleStateSearchFinished(ErrorResult testErrorResult, string singleStateSearchResultsDirectory)
        {
            if (testErrorResult.errorCode == ErrorCode.Success)
            {
                TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().SaveSearchResultsToTestWorkspace(
                    testWorkspace.ToString(), singleStateSearchResultsDirectory);
                this.testErrorResult = testErrorResult;
                testFinished = true;
            }
            else
            {
                this.testErrorResult = testErrorResult;
                testFinished = true;
            }
        }

        public void RandomExplorationFinished(ErrorResult testErrorResult,
            string randomExplorationResultsDirectory)
        {
            if(testErrorResult.errorCode==ErrorCode.Success)
            {
                TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().SaveTestWorkspace(testWorkspace);
                TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().SaveSearchResultsToTestWorkspace(
                    testWorkspace.ToString(), randomExplorationResultsDirectory);
                if (!((CCTestWorkspace)testWorkspace).ccSettings.reportWorstTestCases)
                {
                    this.testErrorResult = testErrorResult;
                    testFinished = true;
                    return;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    lastEstimatedRemainingTime = ((CCTestWorkspace)testWorkspace).GetSingleStateSearchEstimatedRunningTime();
                    currentActivityLastEstimatedRemainingTime = ((CCTestWorkspace)testWorkspace).GetSingleStateSearchEstimatedRunningTime();
                    currentActivityElapsedTime = new TimeSpan(0, 0, 0);
                    lblCurrentActivity.Text = "Finding Worst Test Cases";
                });
                singleStateSearchRun = new SingleStateSearchRun(testWorkspace, this,
                    TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().LoadHeatMapRegionsToTestWorkspace(
                    testWorkspace.ToString()));
                singleStateSearchRun.RunAsync();
                randomExplorationIsFinished = true;
            }
            else
            {                
                this.testErrorResult = testErrorResult;
                testFinished=true;
            }
        }

        private static TimeSpan oneSecondTimeSpan = new TimeSpan(0, 0, 1);
        private ErrorResult testErrorResult = null;
        private bool testFinished = false;
        private TimeSpan currentActivityLastEstimatedRemainingTime;
        private TimeSpan currentActivityElapsedTime = new TimeSpan();
        private TimeSpan lastEstimatedRemainingTime;
        private TimeSpan elapsedTime = new TimeSpan();
        private Timer closeAndElapseTimer;
        private TestWorkspace testWorkspace;
        private RandomExplorationRun randomExplorationRun;
        private SingleStateSearchRun singleStateSearchRun;
        private bool randomExplorationIsFinished = false;
    }
}
