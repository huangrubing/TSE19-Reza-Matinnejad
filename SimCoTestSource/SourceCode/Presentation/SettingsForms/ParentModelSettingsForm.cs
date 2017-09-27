using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    public class ParentModelSettingsForm : Panel
    {
        private GroupBox groupBox1;
        private Button btnMatlabAddtoPath;
        private Button btnRemovePath;
        private ListBox lbMatlabPaths;
        private Button btnAddPath;
        private TextBox tbMatlabPath;
        private Label label4;
        private Button btnSUTPath;
        private TextBox tbSimulinkModelPath;
        private Button btnMatlabPath;
        private TextBox tbMatlabExePath;
        private Label label2;
        private OpenFileDialog fileBrowserDialog;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox tbScript;
        private Button btnMatlabScriptFile;
        private Button btnDelScript;
        private ListBox lbScripts;
        private Button btnAddScript;
        private Label label3;
        private Button btnMatlabPathDown;
        private Button btnMatlabPathUp;
        private Button btnMatlabScriptDown;
        private Button btnMatlabScriptUp;
        private Label label1;

        public ParentModelSettingsForm(ModelSettings modelSettings)
        {
            InitializeComponent();
            LoadModelSettings(modelSettings);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentModelSettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.btnMatlabAddtoPath = new System.Windows.Forms.Button();
            this.btnRemovePath = new System.Windows.Forms.Button();
            this.lbMatlabPaths = new System.Windows.Forms.ListBox();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.tbMatlabPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMatlabScriptFile = new System.Windows.Forms.Button();
            this.btnDelScript = new System.Windows.Forms.Button();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.btnAddScript = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSUTPath = new System.Windows.Forms.Button();
            this.tbSimulinkModelPath = new System.Windows.Forms.TextBox();
            this.btnMatlabPath = new System.Windows.Forms.Button();
            this.tbMatlabExePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileBrowserDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnMatlabPathUp = new System.Windows.Forms.Button();
            this.btnMatlabPathDown = new System.Windows.Forms.Button();
            this.btnMatlabScriptDown = new System.Windows.Forms.Button();
            this.btnMatlabScriptUp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMatlabScriptDown);
            this.groupBox1.Controls.Add(this.btnMatlabScriptUp);
            this.groupBox1.Controls.Add(this.btnMatlabPathDown);
            this.groupBox1.Controls.Add(this.btnMatlabPathUp);
            this.groupBox1.Controls.Add(this.tbScript);
            this.groupBox1.Controls.Add(this.btnMatlabAddtoPath);
            this.groupBox1.Controls.Add(this.btnRemovePath);
            this.groupBox1.Controls.Add(this.lbMatlabPaths);
            this.groupBox1.Controls.Add(this.btnAddPath);
            this.groupBox1.Controls.Add(this.tbMatlabPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnMatlabScriptFile);
            this.groupBox1.Controls.Add(this.btnDelScript);
            this.groupBox1.Controls.Add(this.lbScripts);
            this.groupBox1.Controls.Add(this.btnAddScript);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSUTPath);
            this.groupBox1.Controls.Add(this.tbSimulinkModelPath);
            this.groupBox1.Controls.Add(this.btnMatlabPath);
            this.groupBox1.Controls.Add(this.tbMatlabExePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 384);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MATLAB and Model Paths";
            // 
            // tbScript
            // 
            this.tbScript.Location = new System.Drawing.Point(134, 230);
            this.tbScript.Name = "tbScript";
            this.tbScript.Size = new System.Drawing.Size(526, 20);
            this.tbScript.TabIndex = 7;
            this.tbScript.MouseEnter += new System.EventHandler(this.tbScript_MouseEnter);
            // 
            // btnMatlabAddtoPath
            // 
            this.btnMatlabAddtoPath.Location = new System.Drawing.Point(665, 78);
            this.btnMatlabAddtoPath.Name = "btnMatlabAddtoPath";
            this.btnMatlabAddtoPath.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabAddtoPath.TabIndex = 6;
            this.btnMatlabAddtoPath.Text = "...";
            this.btnMatlabAddtoPath.UseVisualStyleBackColor = true;
            this.btnMatlabAddtoPath.Click += new System.EventHandler(this.btnMatlabAddtoPath_Click);
            // 
            // btnRemovePath
            // 
            this.btnRemovePath.Enabled = false;
            this.btnRemovePath.Location = new System.Drawing.Point(665, 131);
            this.btnRemovePath.Name = "btnRemovePath";
            this.btnRemovePath.Size = new System.Drawing.Size(24, 23);
            this.btnRemovePath.TabIndex = 46;
            this.btnRemovePath.Text = "-";
            this.btnRemovePath.UseVisualStyleBackColor = true;
            this.btnRemovePath.Click += new System.EventHandler(this.btnRemovePath_Click);
            // 
            // lbMatlabPaths
            // 
            this.lbMatlabPaths.FormattingEnabled = true;
            this.lbMatlabPaths.Location = new System.Drawing.Point(134, 102);
            this.lbMatlabPaths.Name = "lbMatlabPaths";
            this.lbMatlabPaths.Size = new System.Drawing.Size(526, 121);
            this.lbMatlabPaths.TabIndex = 45;
            this.lbMatlabPaths.MouseLeave += new System.EventHandler(this.lbMatlabPaths_MouseLeave);
            this.lbMatlabPaths.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbMatlabPaths_MouseMove);
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(665, 104);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(24, 23);
            this.btnAddPath.TabIndex = 44;
            this.btnAddPath.Text = "+";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // tbMatlabPath
            // 
            this.tbMatlabPath.Location = new System.Drawing.Point(134, 78);
            this.tbMatlabPath.Name = "tbMatlabPath";
            this.tbMatlabPath.Size = new System.Drawing.Size(526, 20);
            this.tbMatlabPath.TabIndex = 5;
            this.tbMatlabPath.MouseEnter += new System.EventHandler(this.tbMatlabPath_MouseEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Add to MATLAB Paths:";
            // 
            // btnMatlabScriptFile
            // 
            this.btnMatlabScriptFile.Location = new System.Drawing.Point(665, 230);
            this.btnMatlabScriptFile.Name = "btnMatlabScriptFile";
            this.btnMatlabScriptFile.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabScriptFile.TabIndex = 8;
            this.btnMatlabScriptFile.Text = "...";
            this.btnMatlabScriptFile.UseVisualStyleBackColor = true;
            this.btnMatlabScriptFile.Click += new System.EventHandler(this.btnMatlabScriptFile_Click);
            // 
            // btnDelScript
            // 
            this.btnDelScript.Enabled = false;
            this.btnDelScript.Location = new System.Drawing.Point(665, 283);
            this.btnDelScript.Name = "btnDelScript";
            this.btnDelScript.Size = new System.Drawing.Size(24, 23);
            this.btnDelScript.TabIndex = 34;
            this.btnDelScript.Text = "-";
            this.btnDelScript.UseVisualStyleBackColor = true;
            this.btnDelScript.Click += new System.EventHandler(this.btnDelScript_Click);
            // 
            // lbScripts
            // 
            this.lbScripts.FormattingEnabled = true;
            this.lbScripts.Location = new System.Drawing.Point(134, 255);
            this.lbScripts.Name = "lbScripts";
            this.lbScripts.Size = new System.Drawing.Size(526, 121);
            this.lbScripts.TabIndex = 33;
            this.lbScripts.MouseLeave += new System.EventHandler(this.lbScripts_MouseLeave);
            this.lbScripts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbScripts_MouseMove);
            // 
            // btnAddScript
            // 
            this.btnAddScript.Location = new System.Drawing.Point(665, 256);
            this.btnAddScript.Name = "btnAddScript";
            this.btnAddScript.Size = new System.Drawing.Size(24, 23);
            this.btnAddScript.TabIndex = 32;
            this.btnAddScript.Text = "+";
            this.btnAddScript.UseVisualStyleBackColor = true;
            this.btnAddScript.Click += new System.EventHandler(this.btnAddScript_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Run Script Beofre Model:";
            // 
            // btnSUTPath
            // 
            this.btnSUTPath.Location = new System.Drawing.Point(665, 47);
            this.btnSUTPath.Name = "btnSUTPath";
            this.btnSUTPath.Size = new System.Drawing.Size(24, 23);
            this.btnSUTPath.TabIndex = 4;
            this.btnSUTPath.Text = "...";
            this.btnSUTPath.UseVisualStyleBackColor = true;
            this.btnSUTPath.Click += new System.EventHandler(this.btnSUTPath_Click);
            // 
            // tbSimulinkModelPath
            // 
            this.tbSimulinkModelPath.Location = new System.Drawing.Point(134, 49);
            this.tbSimulinkModelPath.Name = "tbSimulinkModelPath";
            this.tbSimulinkModelPath.Size = new System.Drawing.Size(526, 20);
            this.tbSimulinkModelPath.TabIndex = 3;
            this.tbSimulinkModelPath.MouseEnter += new System.EventHandler(this.tbSimulinkModelPath_MouseEnter);
            // 
            // btnMatlabPath
            // 
            this.btnMatlabPath.Location = new System.Drawing.Point(665, 19);
            this.btnMatlabPath.Name = "btnMatlabPath";
            this.btnMatlabPath.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabPath.TabIndex = 2;
            this.btnMatlabPath.Text = "...";
            this.btnMatlabPath.UseVisualStyleBackColor = true;
            this.btnMatlabPath.Click += new System.EventHandler(this.btnMatlabPath_Click);
            // 
            // tbMatlabExePath
            // 
            this.tbMatlabExePath.Location = new System.Drawing.Point(134, 20);
            this.tbMatlabExePath.Name = "tbMatlabExePath";
            this.tbMatlabExePath.Size = new System.Drawing.Size(526, 20);
            this.tbMatlabExePath.TabIndex = 1;
            this.tbMatlabExePath.MouseEnter += new System.EventHandler(this.tbMatlabExePath_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Simulink Model:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "MATLAB Executable:";
            // 
            // btnMatlabPathUp
            // 
            this.btnMatlabPathUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMatlabPathUp.BackgroundImage")));
            this.btnMatlabPathUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatlabPathUp.Location = new System.Drawing.Point(665, 158);
            this.btnMatlabPathUp.Name = "btnMatlabPathUp";
            this.btnMatlabPathUp.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabPathUp.TabIndex = 47;
            this.btnMatlabPathUp.UseVisualStyleBackColor = true;
            this.btnMatlabPathUp.Click += new System.EventHandler(this.btnMatlabPathUp_Click);
            // 
            // btnMatlabPathDown
            // 
            this.btnMatlabPathDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMatlabPathDown.BackgroundImage")));
            this.btnMatlabPathDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatlabPathDown.Location = new System.Drawing.Point(666, 185);
            this.btnMatlabPathDown.Name = "btnMatlabPathDown";
            this.btnMatlabPathDown.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabPathDown.TabIndex = 48;
            this.btnMatlabPathDown.Text = "+";
            this.btnMatlabPathDown.UseVisualStyleBackColor = true;
            this.btnMatlabPathDown.Click += new System.EventHandler(this.btnMatlabPathDown_Click);
            // 
            // btnMatlabScriptDown
            // 
            this.btnMatlabScriptDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMatlabScriptDown.BackgroundImage")));
            this.btnMatlabScriptDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatlabScriptDown.Location = new System.Drawing.Point(666, 335);
            this.btnMatlabScriptDown.Name = "btnMatlabScriptDown";
            this.btnMatlabScriptDown.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabScriptDown.TabIndex = 50;
            this.btnMatlabScriptDown.Text = "+";
            this.btnMatlabScriptDown.UseVisualStyleBackColor = true;
            this.btnMatlabScriptDown.Click += new System.EventHandler(this.btnMatlabScriptDown_Click);
            // 
            // btnMatlabScriptUp
            // 
            this.btnMatlabScriptUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMatlabScriptUp.BackgroundImage")));
            this.btnMatlabScriptUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatlabScriptUp.Location = new System.Drawing.Point(665, 309);
            this.btnMatlabScriptUp.Name = "btnMatlabScriptUp";
            this.btnMatlabScriptUp.Size = new System.Drawing.Size(24, 23);
            this.btnMatlabScriptUp.TabIndex = 49;
            this.btnMatlabScriptUp.UseVisualStyleBackColor = true;
            this.btnMatlabScriptUp.Click += new System.EventHandler(this.btnMatlabScriptUp_Click);
            // 
            // ParentModelSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(698, 386);
            this.Controls.Add(this.groupBox1);
            this.Name = "ParentModelSettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoadModelSettings(ModelSettings modelSettings)
        {
            tbMatlabExePath.Text = modelSettings.MatlabExePath;
            tbSimulinkModelPath.Text = modelSettings.SimulinkModelPath;
            for (int i = 0; i < modelSettings.MatlabScriptsPaths.Count; ++i)
                lbScripts.Items.Add(modelSettings.MatlabScriptsPaths[i]);
            if (modelSettings.MatlabScriptsPaths.Count > 0)
                btnRemovePath.Enabled = true;
            for (int i = 0; i < modelSettings.MatlabPaths.Count; ++i)
                lbMatlabPaths.Items.Add(modelSettings.MatlabPaths[i]);
            if (modelSettings.MatlabPaths.Count > 0)
                btnRemovePath.Enabled = true;
            if (modelSettings.MatlabScriptsPaths.Count > 0)
                btnDelScript.Enabled = true;
        }

        public bool CheckModelSettings()
        {
            ModelSettings modelSettings = ReadModelSettings();
            ErrorResult errorResult = modelSettings.CehckSettings();
            if (errorResult.errorCode == ErrorCode.Success)
                return true;
            lbMatlabPaths.SelectedIndex = lbScripts.SelectedIndex = -1;
            switch (errorResult.errorCode)
            {
                case ErrorCode.ModelSettingsMatlabExeError:
                    tbMatlabExePath.Focus();
                    tbMatlabExePath.SelectAll();
                    break;
                case ErrorCode.ModelSettingsSimulinkModelError:
                    tbSimulinkModelPath.Focus();
                    tbSimulinkModelPath.SelectAll();
                    break;
                case ErrorCode.ModelSettingsMatlabScriptError:
                    lbScripts.SelectedItem = lbScripts.Items[errorResult.errorParemeter];
                    break;
                case ErrorCode.ModelSettingsMatlabPathError:
                    lbMatlabPaths.SelectedItem = lbMatlabPaths.Items[errorResult.errorParemeter];
                    break;
            }
            MessageBox.Show("The highlighted directory/file does not exist!",
                "Error Accessing File/Directory", MessageBoxButtons.OK);
            return false;
        }

        public ModelSettings ReadModelSettings()
        {
            ModelSettings modelSettings = new ModelSettings();
            modelSettings.MatlabExePath = tbMatlabExePath.Text;
            modelSettings.SimulinkModelPath = tbSimulinkModelPath.Text;
            for (int i = 0; i < lbScripts.Items.Count; ++i)
                modelSettings.MatlabScriptsPaths.Add(lbScripts.Items[i].ToString());
            for (int i = 0; i < lbMatlabPaths.Items.Count; ++i)
                modelSettings.MatlabPaths.Add(lbMatlabPaths.Items[i].ToString());
            return modelSettings;
        }

        private void btnMatlabPath_Click(object sender, EventArgs e)
        {
            fileBrowserDialog.FileName = "matlab.exe";
            fileBrowserDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            DialogResult result = fileBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                tbMatlabExePath.Text = fileBrowserDialog.FileName;
        }

        private void btnSUTPath_Click(object sender, EventArgs e)
        {
            fileBrowserDialog.FileName = "";
            fileBrowserDialog.Filter = "model files (*.mdl)|*.mdl|model files (*.slx)|*.slx|All files (*.*)|*.*";
            DialogResult result = fileBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                tbSimulinkModelPath.Text = fileBrowserDialog.FileName;
        }

        private void btnMatlabScriptFile_Click(object sender, EventArgs e)
        {
            fileBrowserDialog.FileName = "";
            fileBrowserDialog.Filter = "matlab files (*.m)|*.m|All files (*.*)|*.*";
            DialogResult result = fileBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbScript.Text = fileBrowserDialog.FileName;
                btnAddScript_Click(null, null);
            }
        }

        private void btnAddScript_Click(object sender, EventArgs e)
        {
            if (tbScript.Text == "")
                return;
            lbScripts.Items.Add(tbScript.Text);
            tbScript.Text="";
            btnDelScript.Enabled = true;
        }

        private void btnDelScript_Click(object sender, EventArgs e)
        {
            if (lbScripts.SelectedIndex == -1)
                lbScripts.SelectedIndex=0;
            int indexToDel = lbScripts.SelectedIndex;
            lbScripts.Items.RemoveAt(lbScripts.SelectedIndex);
            if (lbScripts.Items.Count == 0)
                btnDelScript.Enabled = false;
            else
            {
                if (lbScripts.Items.Count > indexToDel)
                    lbScripts.SelectedIndex = indexToDel;
                else
                    lbScripts.SelectedIndex = indexToDel - 1;
            }
        }

        private void btnMatlabAddtoPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbMatlabPath.Text = folderBrowserDialog.SelectedPath;
                btnAddPath_Click(null,null);
            }
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            if (tbMatlabPath.Text == "")
                return;            
            lbMatlabPaths.Items.Add(tbMatlabPath.Text);
            tbMatlabPath.Text = "";
            btnRemovePath.Enabled = true;
        }

        private void btnRemovePath_Click(object sender, EventArgs e)
        {
            if (lbMatlabPaths.SelectedIndex == -1)
                lbMatlabPaths.SelectedIndex=0;
            int indexToDel = lbMatlabPaths.SelectedIndex;
            lbMatlabPaths.Items.RemoveAt(lbMatlabPaths.SelectedIndex);
            if (lbMatlabPaths.Items.Count == 0)
                btnRemovePath.Enabled = false;
            else
            {
                if (lbMatlabPaths.Items.Count > indexToDel)
                    lbMatlabPaths.SelectedIndex = indexToDel;
                else
                    lbMatlabPaths.SelectedIndex = indexToDel - 1;
            }
        }

        private void tbMatlabExePath_MouseEnter(object sender, EventArgs e)
        {
            if(tbMatlabExePath.Text!="")
                pathTooltip.SetToolTip(tbMatlabExePath, tbMatlabExePath.Text);
        }

        private void tbSimulinkModelPath_MouseEnter(object sender, EventArgs e)
        {
            if (tbSimulinkModelPath.Text != "")
                pathTooltip.SetToolTip(tbSimulinkModelPath, tbSimulinkModelPath.Text);
        }

        private void tbMatlabPath_MouseEnter(object sender, EventArgs e)
        {
            if (tbMatlabPath.Text != "")
                pathTooltip.SetToolTip(tbMatlabPath, tbMatlabPath.Text);
        }

        private void tbScript_MouseEnter(object sender, EventArgs e)
        {
            if (tbScript.Text != "")
                pathTooltip.SetToolTip(tbScript, tbScript.Text);
        }

        private void lbScripts_MouseMove(object sender, MouseEventArgs e)
        {
            int curIndex=lbScripts.IndexFromPoint(e.Location);
            if (curIndex < 0)
                return;
            if (curIndex != preIndex)
            {
                preIndex = curIndex;
                pathTooltip.SetToolTip(lbScripts, lbScripts.Items[curIndex].ToString());

            }
        }

        private void lbScripts_MouseLeave(object sender, EventArgs e)
        {
            preIndex = -1;
            pathTooltip.RemoveAll();
        }

        private void lbMatlabPaths_MouseLeave(object sender, EventArgs e)
        {
            preIndex = -1;
            pathTooltip.RemoveAll();
        }

        private void lbMatlabPaths_MouseMove(object sender, MouseEventArgs e)
        {
            int curIndex = lbMatlabPaths.IndexFromPoint(e.Location);
            if (curIndex < 0)
                return;
            if (curIndex != preIndex)
            {
                preIndex = curIndex;
                pathTooltip.SetToolTip(lbMatlabPaths, lbMatlabPaths.Items[curIndex].ToString());
            }
        }

        private int preIndex;
        private ToolTip pathTooltip = new ToolTip();

        private void btnMatlabPathUp_Click(object sender, EventArgs e)
        {
            if (lbMatlabPaths.SelectedIndex == -1)
                return;
            int indexToMove = lbMatlabPaths.SelectedIndex;
            if (indexToMove == 0)
                return;
            int slectedIndex=lbMatlabPaths.SelectedIndex;
            Object item=lbMatlabPaths.Items[lbMatlabPaths.SelectedIndex];
            lbMatlabPaths.Items.RemoveAt(lbMatlabPaths.SelectedIndex);
            lbMatlabPaths.Items.Insert(slectedIndex-1, item);
            lbMatlabPaths.SelectedIndex = slectedIndex - 1;
        }
        
        private void btnMatlabPathDown_Click(object sender, EventArgs e)
        {
            if (lbMatlabPaths.SelectedIndex == -1)
                return;
            int indexToMove = lbMatlabPaths.SelectedIndex;
            if (indexToMove == (lbMatlabPaths.Items.Count-1))
                return;
            int slectedIndex = lbMatlabPaths.SelectedIndex;
            Object item = lbMatlabPaths.Items[lbMatlabPaths.SelectedIndex];
            lbMatlabPaths.Items.RemoveAt(lbMatlabPaths.SelectedIndex);
            lbMatlabPaths.Items.Insert(slectedIndex +1, item);
            lbMatlabPaths.SelectedIndex = slectedIndex + 1;
        }

        private void btnMatlabScriptUp_Click(object sender, EventArgs e)
        {
            if (lbScripts.SelectedIndex == -1)
                return;
            int indexToMove = lbScripts.SelectedIndex;
            if (indexToMove == 0)
                return;
            int slectedIndex = lbScripts.SelectedIndex;
            Object item = lbScripts.Items[lbScripts.SelectedIndex];
            lbScripts.Items.RemoveAt(lbScripts.SelectedIndex);
            lbScripts.Items.Insert(slectedIndex - 1, item);
            lbScripts.SelectedIndex = slectedIndex - 1;

        }

        private void btnMatlabScriptDown_Click(object sender, EventArgs e)
        {
            if (lbScripts.SelectedIndex == -1)
                return;
            int indexToMove = lbScripts.SelectedIndex;
            if (indexToMove == (lbScripts.Items.Count - 1))
                return;
            int slectedIndex = lbScripts.SelectedIndex;
            Object item = lbScripts.Items[lbScripts.SelectedIndex];
            lbScripts.Items.RemoveAt(lbScripts.SelectedIndex);
            lbScripts.Items.Insert(slectedIndex + 1, item);
            lbScripts.SelectedIndex = slectedIndex + 1;
        }

    }
}
