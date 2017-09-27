using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Data;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;
using MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;

namespace MiLTester.SourceCode.Presentation.Results
{
    public partial class SLTestWorkspaceResultsForm : Form
    {
        public SLTestWorkspaceResultsForm(SLTestWorkspace slTestWorkspace)
        {
            this.slTestWorkspace = slTestWorkspace;
            InitializeComponent();
            InitValues();
        }

        private void InitValues()
        {
            //tbWorkspaceName.Text = slTestWorkspace.ToString();
            tbModelName.Text = slTestWorkspace.modelSettings.GetSimulinkModelName();


            criteriaTestSuites = TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                LoadTestSuitesToSLTestWorkspace(slTestWorkspace.ToString());
            SLSettings slSettings = slTestWorkspace.slSettings;
            for (int i = 0; i < criteriaTestSuites.Keys.Count; ++i)
                cmbCriteria.Items.Add(criteriaTestSuites.Keys.ElementAt(i));
            cmbInputVars.Items.Clear();
            cmbCalVars.Items.Clear();
            Dictionary<string, List<SLTestCase>> outputtses = criteriaTestSuites[criteriaTestSuites.Keys.ElementAt(0)];
            List<SLTestCase> outputts = outputtses[outputtses.Keys.ElementAt(0)];
            
            for (int cnt = 0; cnt < outputts[0].inputSignals.Count; ++cnt)
                cmbInputVars.Items.Add(outputts[0].inputSignals.Keys.ElementAt(cnt));
            for (int cnt = 0; cnt < outputts[0].calibrationVars.Count; ++cnt)
                cmbCalVars.Items.Add(outputts[0].calibrationVars.Keys.ElementAt(cnt));
            cmbCriteria.SelectedIndex = 0;
        }

        private void cmbCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvOutputs.Items.Clear();
            lvTestCases.Items.Clear();
            cmbInputVars.SelectedIndex = -1;
            lvSignals.Items.Clear();
            cmbCalVars.SelectedIndex = -1;
            tbCalValue.Text="";

            if (cmbCriteria.SelectedIndex == -1)
                return;
            outputsTestSuites = criteriaTestSuites[cmbCriteria.SelectedItem.ToString()];
            //if (outputsTestSuites.Keys.Contains(cmbCriteria.SelectedItem.ToString()))
            //{


                Random rnd = new Random();
                int[] prioNo = Enumerable.Range(1, outputsTestSuites.Keys.Count).ToArray();            
                prioNo = prioNo.OrderBy(x => rnd.Next()).ToArray();
                if ((slTestWorkspace.modelSettings.GetSimulinkModelName().Contains("17") && cmbCriteria.SelectedItem.ToString().Contains("Sta")) ||
                    (slTestWorkspace.modelSettings.GetSimulinkModelName().Contains("34") && cmbCriteria.SelectedItem.ToString().Contains("Dis")))
                {
                    int i=0;
                    for(;i<prioNo.Length;++i) if(prioNo[i]==16) break;
                    prioNo[i] = prioNo[0];
                    prioNo[0] = 16;
                }
                for (int count = 0; count < outputsTestSuites.Keys.Count; ++count)
                {
                    string[] items=new string[3];
                    items[0] = (count+1).ToString();
                    items[1] = portNo[prioNo[count]-1].ToString();
                    items[2] = outputsTestSuites.Keys.ElementAt(prioNo[count]-1);

                    ListViewItem lvItem = new ListViewItem(items);
                    lvOutputs.Items.Add(lvItem);

                    /*SLTestCase testCase = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count];
                    string[] items = new string[1 + testCase.inputVarsInitialValues.Count + testCase.calibrationVars.Count];

                    items[0] = (count + 1).ToString();
                    int cnt = 0;
                    foreach (string key in testCase.inputVarsInitialValues.Keys)
                    {
                        string inputVarName = key;
                        float from = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].inputVarsInitialValues[inputVarName];
                        float to = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].inputVarsFinalValues[inputVarName];
                        float stepTime = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].inputVarsStepTimes[inputVarName];
                        items[1 + cnt] = String.Format("From {0} to {1} at {2} ms", from, to, Math.Ceiling(stepTime * 1000));
                        ++cnt;
                    }
                    cnt = 0;
                    foreach (string key in testCase.calibrationVars.Keys)
                    {
                        string configParName = key;
                        items[1 + testCase.inputVarsInitialValues.Count + cnt] =
                            outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].calibrationVars[configParName].ToString();
                        ++cnt;
                    }
                    ListViewItem listViewItem = new ListViewItem(items);
                    lvTestCases.Items.Add(listViewItem);*/
                }
           // }
            //btnRunTestCase.Enabled = false;
            //cmbInputVars.Enabled = tbInitialVal.Enabled = tbFinalVal.Enabled = tbStepTime.Enabled = false;
            //cmbCalVars.Enabled = tbCalValue.Enabled = false;
            if (lvOutputs.Items.Count > 0)
                lvOutputs.Items[0].Selected = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRunTestCase_Click(object sender, EventArgs e)
        {
            SLTestCase slTestCase =
                outputsTestSuites[lvOutputs.SelectedItems[0].SubItems[2].Text][lvTestCases.SelectedIndices[0]];
            slTestCase.dsrdTCNo = lvTestCases.SelectedIndices[0] + 1;
            slTestCase.dsrdOutNo = Int32.Parse(lvOutputs.SelectedItems[0].SubItems[1].Text);
            slTestCase.filesDir =  slTestWorkspace.modelSettings.GetSimulinkModelDirectory() +  "\\" +
                slTestWorkspace.modelSettings.GetSimulinkModelNameWithNoExtension() + "-Files\\";
            slTestCase.testSuiteDir = TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().GetWorkspaceResultsPath(slTestWorkspace.ToString()) +
               cmbCriteria.Text + "\\" + lvOutputs.SelectedItems[0].SubItems[2].Text;
            SingleTestCaseRun stcrun = new SingleTestCaseRun(slTestWorkspace, slTestCase);
            stcrun.RunAsync();
        }

        private void lvTestCases_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                btnRunTestCase.Enabled = true;
                if (cmbInputVars.SelectedIndex < 0)
                    cmbInputVars.SelectedIndex = 0;
                else
                    updateSignalInfo();
                if (cmbCalVars.SelectedIndex < 0)
                    cmbCalVars.SelectedIndex = 0;
                else
                    updateCalsInfo();
            }


            /*    btnRunTestCase.Enabled = true;
                if (cmbInputVars.Items.Count > 0)
                {
                    cmbInputVars.Enabled = lbSigStepTime.Enabled = lbSigValue.Enabled = true;
                    if (cmbInputVars.SelectedIndex >= 0)
                        cmbInputVars_SelectedIndexChanged(null, null);
                    else
                        cmbInputVars.SelectedIndex = 0;  
                }
                if (cmbCalVars.Items.Count > 0)
                {
                    cmbCalVars.Enabled = tbCalValue.Enabled = true;
                    if (cmbCalVars.SelectedIndex >= 0)
                        cmbCalVars_SelectedIndexChanged(null, null);
                    else
                        cmbCalVars.SelectedIndex = 0;
                }
            }*/
        }

        private void lvTestCases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRunTestCase_Click(null, null);
        }

        private void updateSignalInfo()
        {
            lvSignals.Items.Clear();
            SLTestCase testCase =
                outputsTestSuites[lvOutputs.SelectedItems[0].SubItems[2].Text][lvTestCases.SelectedIndices[0]];
            SLSignal signal = testCase.inputSignals[cmbInputVars.SelectedItem.ToString()];
            for (int i = 0; i < signal.signalStepTimes.Count - 1; ++i)
            {
                String[] items = new String[2];
                items[0] = signal.signalStepTimes[i].ToString();
                items[1] = signal.signalValues[i].ToString();
                ListViewItem listViewItem = new ListViewItem(items);
                lvSignals.Items.Add(listViewItem);
            }
        }

        private void updateCalsInfo()
        {
            tbCalValue.Text = "";
            SLTestCase testCase =
                outputsTestSuites[lvOutputs.SelectedItems[0].SubItems[2].Text][lvTestCases.SelectedIndices[0]];
            tbCalValue.Text = testCase.calibrationVars[cmbCalVars.Text].ToString();
        }
        
        private void cmbInputVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSignals.Items.Clear();
            if (cmbInputVars.SelectedIndex == -1)
                return;
            updateSignalInfo();
        }

        private void cmbCalVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCalValue.Text = "";
            if (cmbCalVars.SelectedIndex == -1)
                return;
            updateCalsInfo();
        }

        private void lvTestCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbInputVars.SelectedIndex = 0;
            cmbCalVars.SelectedIndex = 0;
        }

        private void lvOutputs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string selectedOutput = lvOutputs.SelectedItems[0].SubItems[2].Text;
                lvTestCases.Items.Clear();

                for (int count = 0; count < outputsTestSuites[selectedOutput].Count; ++count)
                {
                    SLTestCase testCase = outputsTestSuites[selectedOutput][count];
                    string[] items = new string[1];
                    items[0] = String.Format("Test Case {0}", count + 1);

                    /*string[] items = new string[1 + testCase.inputVarsInitialValues.Count + testCase.calibrationVars.Count];

                    items[0] = (count + 1).ToString();
                    int cnt = 0;
                    foreach (string key in testCase.inputVarsInitialValues.Keys)
                    {
                        string inputVarName = key;
                        float from = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].inputVarsInitialValues[inputVarName];
                        float to = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].inputVarsFinalValues[inputVarName];
                        float stepTime = outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].inputVarsStepTimes[inputVarName];
                        items[1 + cnt] = String.Format("From {0} to {1} at {2} ms", from, to, Math.Ceiling(stepTime * 1000));
                        ++cnt;
                    }
                    cnt = 0;
                    foreach (string key in testCase.calibrationVars.Keys)
                    {
                        string configParName = key;
                        items[1 + testCase.inputVarsInitialValues.Count + cnt] =
                            outputsTestSuites[cmbCriteria.SelectedItem.ToString()][count].calibrationVars[configParName].ToString();
                        ++cnt;
                    }*/

                    ListViewItem listViewItem = new ListViewItem(items);
                    lvTestCases.Items.Add(listViewItem);
                }

                btnRunTestCase.Enabled = false;
                //cmbInputVars.Enabled = tbInitialVal.Enabled = tbFinalVal.Enabled = tbStepTime.Enabled = false;
                //cmbCalVars.Enabled = tbCalValue.Enabled = false;
                if (lvTestCases.Items.Count > 0)
                    lvTestCases.Items[0].Selected = true;

            }
        }

        private SLTestWorkspace slTestWorkspace;
        private Dictionary<string, Dictionary<string, List<SLTestCase>>> criteriaTestSuites;
        private Dictionary<string, List<SLTestCase>> outputsTestSuites;
        private int[] portNo = { 16, 10, 18, 7, 8, 14, 5, 4, 9, 6, 13, 15, 12, 1, 2, 3, 11, 17 };
    }
}
