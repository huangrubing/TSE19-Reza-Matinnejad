using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms;
using MiLTester.SourceCode.Presentation.SettingsForms;
using MiLTester.SourceCode.Presentation.Results;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Data;
using MiLTester.SourceCode.Bussiness;
using MiLTester.SourceCode.Common;
using System.IO;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Bussiness.Settings;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace MiLTester.SourceCode.Presentation
{
    public partial class MainForm : Form,ITestWorkspaceAddRemoveListener
    {

        private TestWorkspace activeTestWorkSpace=null;
        private ContextMenu cmListBoxTestWorkspaces;

        public MainForm()
        {
            InitializeComponent();
            MenuItem[] menuItems = new MenuItem[5];
            menuItems[0] = new MenuItem("ViewResults", btnViewResults_Click);
            menuItems[1] = new MenuItem("Rename", btnRename_Click);
            menuItems[2] = new MenuItem("Delete", btnDelete_Click);
            menuItems[3] = new MenuItem("Duplicate", btnDuplicate_Click);
            menuItems[4] = new MenuItem("Export", btnExport_Click);
            cmListBoxTestWorkspaces = new ContextMenu(menuItems);
            CreateNewDataProviderAndUpdateTestWorkspacesList();
        }
        
        private void CreateNewDataProviderAndUpdateTestWorkspacesList()
        {
            lbTestWorkspaces.Items.Clear();
            tbDetails.Clear();
            TestWorkspaceDataProvider testWorkspaceDataProvider =
                TestWorkspaceDataProvider.CreateTestWorkspaceDataProvider(GetProgramSettings().
                TestWorkspacesLastPath, this);
            List<string> workspacesList = testWorkspaceDataProvider.GetTestWorkspaceList();
            foreach (string workspaceName in workspacesList)
                lbTestWorkspaces.Items.Add(workspaceName);
        }

        private void SetSoftwareMode()
        {
            SoftwareModeForm softwareModeForm = new SoftwareModeForm();
            DialogResult result = softwareModeForm.ShowDialog();
            if (result == DialogResult.Abort)
                Application.Exit();
            if (SettingFilesManager.softwareRunningMode == SoftwareModeEnum.MaintenanceMode)
            {
                btnAdCCTestSettings.Visible = true;
                btnAdSLTestSettings.Visible = true;
                advancedTestSettingsToolStripMenuItem.Visible = true;
            }
        }

        private void SetShortcutTooltips()
        {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnNewTestWorkspace,"New Test Workspace Wizard");
            tooltip.SetToolTip(btnModelSetting,"Model Settings");
            tooltip.SetToolTip(btnCCTestSettings,"Continuous Controllers Test Settings");
            tooltip.SetToolTip(btnSLTestSettings, "Simulink Test Settings");
            tooltip.SetToolTip(btnAdCCTestSettings,"Advanced Continuous Controllers Test Settings");
            tooltip.SetToolTip(btnAdSLTestSettings, "Advanced Simulink Test Settings");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SetSoftwareMode();
            SetShortcutTooltips();
            lbTestWorkspaces.SelectedIndex = (lbTestWorkspaces.Items.Count > 0) ? 0 : -1;
        }

        private void btnNewTestWorkspace_Click(object sender, EventArgs e)
        {
            newTestWorkspaceWizard();
        }

        private void newTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newTestWorkspaceWizard();
        }

        private void newTestWorkspaceWizard()
        {
            FunctionTypeForm functionTypeForm = new FunctionTypeForm();
            functionTypeForm.ShowDialog();
        }

        private void aboutMiLTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ShowModelSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miLTesterSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowModelSettings();
        }

        private void btnCCTestSettings_Click(object sender, EventArgs e)
        {
            ShowCCSettings();
        }

        private void continuousControllersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCCSettings();
        }

        private void ShowModelSettings()
        {
            ModelSettingsForm modelSettingsForm = new ModelSettingsForm();
            modelSettingsForm.ShowDialog();
        }

        private void ShowCCSettings()
        {
            CCSettingsForm ccSettingsForm = new CCSettingsForm();
            ccSettingsForm.ShowDialog();
        }

        private void ShowSBSettings()
        {
            SLSettingsForm sbSettingsForm = new SLSettingsForm();
            sbSettingsForm.ShowDialog();
        }

        private void ShowAdvancedCCSettings()
        {
            AdvanceCCSettingsForm advancedCCSettingsForm = new AdvanceCCSettingsForm();
            advancedCCSettingsForm.ShowDialog();
        }

        private void ShowAdvanceSBSettings()
        {
            AdvancedSBSettingsForm advancedSBSettingsForm = new AdvancedSBSettingsForm();
            advancedSBSettingsForm.ShowDialog();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            if(activeTestWorkSpace.functionType==FunctionTypeEnum.Continuous_Controller)
                new CCTestWorkspaceResultsForm((CCTestWorkspace)activeTestWorkSpace).ShowDialog();
            if (activeTestWorkSpace.functionType == FunctionTypeEnum.State_Based_Controller)
                new SLTestWorkspaceResultsForm((SLTestWorkspace)activeTestWorkSpace).ShowDialog();
        }

        private void lbTestWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTestWorkspaces.SelectedIndex == -1)
            {
                btnDelete.Enabled = btnRename.Enabled = btnViewResults.Enabled = btnDuplicate.Enabled = btnExport.Enabled = false;
                tbDetails.Text = "";
                return;
            }
            btnDelete.Enabled = btnRename.Enabled = btnViewResults.Enabled = btnDuplicate.Enabled = btnExport.Enabled = true;
            activeTestWorkSpace=TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                LoadTestWorkspace(lbTestWorkspaces.SelectedItem.ToString());
            tbDetails.Text = activeTestWorkSpace.GetDetailsString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to delete the selected test workspace?", 
                "Confirm Test Wrokspace Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                DeleteTestWorkspace(activeTestWorkSpace);
        }

        public void TestWorkspaceAdded(TestWorkspace testWorkspace)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lbTestWorkspaces.Items.Add(testWorkspace);
                lbTestWorkspaces.SelectedItem = testWorkspace;
            });
        }

        public void TestWorkspaceRemoved(TestWorkspace testWorkspace)
        {
            if (activeTestWorkSpace != testWorkspace ||
                !lbTestWorkspaces.SelectedItem.ToString().Equals(testWorkspace.ToString()))
                return;//Log Error
            int selectedIndex = lbTestWorkspaces.SelectedIndex;
            lbTestWorkspaces.Items.RemoveAt(selectedIndex);            
            if (lbTestWorkspaces.Items.Count == 0)
                return;
            if (selectedIndex < lbTestWorkspaces.Items.Count)
                lbTestWorkspaces.SelectedIndex = selectedIndex;
            else
                lbTestWorkspaces.SelectedIndex = selectedIndex - 1;
        }

        public void TestWorkspaceRenamed(TestWorkspace testWorkspace,string newTestWorkspaceName)
        {
            if (activeTestWorkSpace != testWorkspace ||
                !lbTestWorkspaces.SelectedItem.ToString().Equals(testWorkspace.ToString()))
                return;//Log Error
            int selectedIndex = lbTestWorkspaces.SelectedIndex;
            lbTestWorkspaces.Items.RemoveAt(selectedIndex);
            lbTestWorkspaces.Items.Insert(selectedIndex,newTestWorkspaceName);
            lbTestWorkspaces.SelectedIndex = selectedIndex;
        }

        private void btnAdCCTestSettings_Click(object sender, EventArgs e)
        {
            ShowAdvancedCCSettings();
        }

        private void continuousControllersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowAdvancedCCSettings();
        }

        private void tbDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            TestWorkspaceRenameForm testWorkspaceRenameForm=new TestWorkspaceRenameForm(
                activeTestWorkSpace.ToString());
            DialogResult dialogResult=testWorkspaceRenameForm.ShowDialog();
            if(dialogResult == DialogResult.OK)
                TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                    RenameTestWorkspace(activeTestWorkSpace,
                        testWorkspaceRenameForm.GetNewTestWorkspaceName());
        }
        
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            FunctionTypeForm functionTypeForm = new FunctionTypeForm(activeTestWorkSpace);
            functionTypeForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbTestWorkspaces_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lbTestWorkspaces.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    lbTestWorkspaces.SelectedIndex = item;
                    cmListBoxTestWorkspaces.Show(lbTestWorkspaces, e.Location);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = eximportFolderDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().ExportTestWorkspace(
                activeTestWorkSpace,eximportFolderDialog.SelectedPath);
            MessageBox.Show("Export Finished Successfully!",
                "Export Finished", MessageBoxButtons.OK);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = eximportFolderDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            if (TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                IsTestWorkspacePath(eximportFolderDialog.SelectedPath))
            {
                if(TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                    ImportTestWorkspace(eximportFolderDialog.SelectedPath).errorCode==ErrorCode.Success)
                    MessageBox.Show("Import Finished Successfully!",
                        "Import Finished", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Not possible to import workspae with a duplicate name!",
                        "Error in Import", MessageBoxButtons.OK);
                return;
            }

            List<string> inDirectories = new List<string>(
                Directory.EnumerateDirectories(eximportFolderDialog.SelectedPath));
            foreach(string inDirectory in inDirectories)
                if (TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                    IsTestWorkspacePath(inDirectory))
                {
                    if (TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                        ImportTestWorkspace(inDirectory).errorCode == ErrorCode.Success)
                        MessageBox.Show("Import Finished Successfully!",
                            "Import Finished", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Not possible to import workspae with a duplicate name!",
                            "Error in Import", MessageBoxButtons.OK);
                    return;
                }


        }

        private void lbTestWorkspaces_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnViewResults_Click(null,null);
        }

        private ProgramSettings GetProgramSettings()
        {
            ProgramSettings programSettings;
            if (SettingFilesManager.programSettingsExists(SettingFilesManager.SettingsFolderPath))
                programSettings = SettingFilesManager.LoadProgramSettings(SettingFilesManager.SettingsFolderPath);
            else
            {
                programSettings = new ProgramSettings();
                SettingFilesManager.SaveProgramSettings(SettingFilesManager.SettingsFolderPath,programSettings);
            }
            return programSettings;
        }

        private void openWorkspacesFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openWorkspacesBrowserDialog.SelectedPath = GetProgramSettings().TestWorkspacesLastPath;
            if (openWorkspacesBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            ProgramSettings programSettings = new ProgramSettings();
            programSettings.TestWorkspacesLastPath = openWorkspacesBrowserDialog.SelectedPath;
            if (programSettings.TestWorkspacesLastPath.LastIndexOf("\\") != 
                (programSettings.TestWorkspacesLastPath.Length - 1))
                programSettings.TestWorkspacesLastPath += "\\";
            SettingFilesManager.SaveProgramSettings(SettingFilesManager.SettingsFolderPath, programSettings);
            CreateNewDataProviderAndUpdateTestWorkspacesList();
        }

        private void statebasedControllersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowAdvanceSBSettings();
        }

        private void btnAdSBTestSettings_Click(object sender, EventArgs e)
        {
            ShowAdvanceSBSettings();
        }

        private void btnSBTestSettings_Click(object sender, EventArgs e)
        {
            ShowSBSettings();
        }

        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);

        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);


        private void button1_Click(object sender, EventArgs e)
        {

            /*IRunningObjectTable rot;
            IEnumMoniker enumMoniker;
            int retVal = GetRunningObjectTable(0, out rot);

            if (retVal == 0)
            {
                rot.EnumRunning(out enumMoniker);

                IntPtr fetched = IntPtr.Zero;
                IMoniker[] moniker = new IMoniker[1];
                while (enumMoniker.Next(1, moniker, fetched) == 0)
                {
                    IBindCtx bindCtx;
                    CreateBindCtx(0, out bindCtx);
                    string displayName;
                    moniker[0].GetDisplayName(bindCtx, null, out displayName);
                    Console.WriteLine("Display Name: {0}", displayName);
                }
            }*/


            //MLApp.MLApp matlab = (MLApp.MLApp)Marshal.GetActiveObject("matlab.application");

            //Process matprocess = Process.GetProcessesByName("Matlab")[0];
            //Type t=matprocess.GetType();
            //MLApp.MLApp matApp = (MLApp.MLApp)Marshal.GetActiveObject();

            try
            {
                Type t = Type.GetTypeFromProgID("PowerPoint.Application");
                //object o = Activator.CreateInstance(t);
                //int processID = (int)Process.GetProcessById(matprocess[0].Id).progMainWindowHandle;
                //MLApp.MLApp matApp = (MLApp.MLApp)Marshal.GetActiveObject("MATLAB.Application");
                //Type activationContext = matprocess[0].GetType();
                //var matlab = (MLApp.MLApp)Activator.CreateInstance(activationContext);

                //Type MatlabType = Type.GetTypeFromProgID("Matlab.Desktop.Application");
                //MLApp.MLApp matlab = (MLApp.MLApp)Activator.CreateInstance(MatlabType);
                //matlab = (MLApp.MLApp)Marshal.GetActiveObject("Matlab.Desktop.Application");
                //matlab.Quit();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                //this happens if no Matlab instances were running
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
           
        }
    }
}
    