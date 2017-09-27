using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Presentation.SettingsForms;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;
using MiLTester.SourceCode.Data;
using MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;
using MiLTester.SourceCode.Bussiness.Output.HeatMap.GUI;

namespace MiLTester.SourceCode.Presentation.Results
{
    public partial class CCTestWorkspaceResultsForm : Form, IHeatMapTestCaseRunListener
    {
        
        
        public CCTestWorkspaceResultsForm(CCTestWorkspace ccTestWorkspace)
        {
            this.ccTestWorkspace = ccTestWorkspace;
            InitializeComponent();
            InitValues();
        }

        private void InitValues()
        {
            lblWorkspaceName.Text = ccTestWorkspace.ToString();
            heatMapDiagram = TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                LoadHeatMapDiagramToTestWorkspace(ccTestWorkspace.ToString());
            worstTestCases = TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                LoadWorstTestCasesToCCTestWorkspace(ccTestWorkspace.ToString());
            CCSettings ccSettings = ccTestWorkspace.ccSettings;
            for (int i = 0; i < ccSettings.Requirements.Count; ++i)
                if (ccSettings.Requirements.ElementAt(i).Value)
                    cmbRequirements.Items.Add(ccSettings.Requirements.ElementAt(i).Key);
            cmbRequirements.SelectedIndex = 0;
            if (!ccSettings.reportWorstTestCases)
                gbWorstTestCases.Enabled = false;
            ParentCCSettingsForm.CreateAndShowLabels(labels, HeatMapPanel, 
                ccTestWorkspace.ccSettings.heatMapDiagramDivisionFactor,
                ccTestWorkspace.GetDesiredValueVariable().from, ccTestWorkspace.GetDesiredValueVariable().to, gbHeatMap);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbRequirements_SelectedIndexChanged(object sender, EventArgs e)
        {
            HeatMapLayout.CreateHeatMapLayoutDiagram(HeatMapPanel,
                ccTestWorkspace.ccSettings.heatMapDiagramDivisionFactor,
                heatMapDiagram, cmbRequirements.SelectedItem.ToString(), ccTestWorkspace.GetDesiredValueVariable().from, 
                ccTestWorkspace.GetDesiredValueVariable().to, this);
            lvTestCases.Items.Clear();
            if (worstTestCases.Keys.Contains(cmbRequirements.SelectedItem.ToString()))
            {
                for (int count = 0; count < worstTestCases[cmbRequirements.SelectedItem.ToString()].Count; ++count)
                {
                    string[] items = new string[3];
                    items[0] = (count + 1).ToString();
                    items[1] = worstTestCases[cmbRequirements.SelectedItem.ToString()][count].initialDesired.ToString();
                    items[2] = worstTestCases[cmbRequirements.SelectedItem.ToString()][count].finalDesired.ToString();
                    ListViewItem listViewItem = new ListViewItem(items);
                    lvTestCases.Items.Add(listViewItem);
                }
            }
            btnRunTestCase.Enabled = false;
        }

        private void btnRunTestCase_Click(object sender, EventArgs e)
        {
            TestRunProgressForm testRunProgressForm = new TestRunProgressForm();
            ErrorResult errorResult = testRunProgressForm.TestRunModel(ccTestWorkspace,
                worstTestCases[cmbRequirements.SelectedItem.ToString()][lvTestCases.SelectedIndices[0]]);
            if (errorResult.errorCode != ErrorCode.Success)
            {
                if (errorResult.errorCode != ErrorCode.TestRunCanceled)
                    MessageBox.Show("Error in Running the Model with this Information!",
                        "Error Running the Model", MessageBoxButtons.OK);
                return;
            }
        }

        private void lvTestCases_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvTestCases.Columns[e.ColumnIndex].Width;
        }

        private void lvTestCases_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                ShowCurrentPoint(worstTestCases[cmbRequirements.SelectedItem.ToString()][e.ItemIndex].initialDesired,
                    worstTestCases[cmbRequirements.SelectedItem.ToString()][e.ItemIndex].finalDesired);
                btnRunTestCase.Enabled = true;
            }
        }

        private void lvTestCases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRunModel_Click(null, null);
        }

        public void ShowCurrentPoint(float xTestCase, float yTestCase)
        {
            tbInitialDsrdTest.Text = xTestCase.ToString("0.0000");
            tbFinalDsrdTest.Text = yTestCase.ToString("0.0000");
        }

        public void RunSelectedTestCase()
        {
            btnRunModel_Click(null, null);
        }

        public void RunSelectedTestCase(object sender, EventArgs e)
        {
            btnRunModel_Click(null, null);
        }

        private void btnRunModel_Click(object sender, EventArgs e)
        {
            TestRunProgressForm testRunProgressForm = new TestRunProgressForm();
            CCTestCase ccTestCase = new CCTestCase();
            ccTestCase.initialDesired = float.Parse(tbInitialDsrdTest.Text);
            ccTestCase.finalDesired = float.Parse(tbFinalDsrdTest.Text);
            ErrorResult errorResult = testRunProgressForm.TestRunModel(ccTestWorkspace, ccTestCase);
            if (errorResult.errorCode != ErrorCode.Success)
            {
                if (errorResult.errorCode != ErrorCode.TestRunCanceled)
                    MessageBox.Show("Error in Running the Model with this Information!",
                        "Error Running the Model", MessageBoxButtons.OK);
                return;
            }
        }

        private void tbInitialDsrdTest_TextChanged(object sender, EventArgs e)
        {
            SelectedPointChanged();
        }

        private void tbFinalDsrdTest_TextChanged(object sender, EventArgs e)
        {
            SelectedPointChanged();
        }

        private void SelectedPointChanged()
        {
            float initialDesired,finalDesired;
            if(!float.TryParse(tbInitialDsrdTest.Text,out initialDesired))
                return;
            if (!float.TryParse(tbFinalDsrdTest.Text, out finalDesired))
                return;
            HeatMapLayout.HighlightPoint(initialDesired/(ccTestWorkspace.GetDesiredValueVariable().to-ccTestWorkspace.GetDesiredValueVariable().from),
                finalDesired/ (ccTestWorkspace.GetDesiredValueVariable().to - ccTestWorkspace.GetDesiredValueVariable().from));
        }

        private void lvTestCases_MouseClick(object sender, MouseEventArgs e)
        {
            ShowCurrentPoint(worstTestCases[cmbRequirements.SelectedItem.ToString()][lvTestCases.SelectedIndices[0]].initialDesired,
                worstTestCases[cmbRequirements.SelectedItem.ToString()][lvTestCases.SelectedIndices[0]].finalDesired);
        }
        
        private CCTestWorkspace ccTestWorkspace;
        private Dictionary<string, List<CCTestCase>> worstTestCases;
        private HeatMap heatMapDiagram;
        private List<Label> labels = new List<Label>();
    }
}
