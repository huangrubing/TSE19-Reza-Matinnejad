namespace MiLTester.SourceCode.Presentation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.programMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkspacesFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miLTesterSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continuousControllersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statebasedControllersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedTestSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continuousControllersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statebasedControllersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inputOutputFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMiLTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdSLTestSettings = new System.Windows.Forms.Button();
            this.btnSLTestSettings = new System.Windows.Forms.Button();
            this.btnAdCCTestSettings = new System.Windows.Forms.Button();
            this.btnCCTestSettings = new System.Windows.Forms.Button();
            this.btnNewTestWorkspace = new System.Windows.Forms.Button();
            this.btnModelSetting = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTestWorkspaces = new System.Windows.Forms.ListBox();
            this.eximportFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openWorkspacesBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.programMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // programMenu
            // 
            this.programMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.programMenu.Location = new System.Drawing.Point(0, 0);
            this.programMenu.Name = "programMenu";
            this.programMenu.Size = new System.Drawing.Size(665, 24);
            this.programMenu.TabIndex = 2;
            this.programMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWorkspacesFromToolStripMenuItem,
            this.newTestToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openWorkspacesFromToolStripMenuItem
            // 
            this.openWorkspacesFromToolStripMenuItem.Name = "openWorkspacesFromToolStripMenuItem";
            this.openWorkspacesFromToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.openWorkspacesFromToolStripMenuItem.Text = "Open Workspaces From";
            this.openWorkspacesFromToolStripMenuItem.Click += new System.EventHandler(this.openWorkspacesFromToolStripMenuItem_Click);
            // 
            // newTestToolStripMenuItem
            // 
            this.newTestToolStripMenuItem.Name = "newTestToolStripMenuItem";
            this.newTestToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.newTestToolStripMenuItem.Text = "New Test Workspace";
            this.newTestToolStripMenuItem.Click += new System.EventHandler(this.newTestToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLTesterSettingToolStripMenuItem,
            this.testSettingsToolStripMenuItem,
            this.advancedTestSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // miLTesterSettingToolStripMenuItem
            // 
            this.miLTesterSettingToolStripMenuItem.Name = "miLTesterSettingToolStripMenuItem";
            this.miLTesterSettingToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.miLTesterSettingToolStripMenuItem.Text = "Model Settings";
            this.miLTesterSettingToolStripMenuItem.Click += new System.EventHandler(this.miLTesterSettingToolStripMenuItem_Click);
            // 
            // testSettingsToolStripMenuItem
            // 
            this.testSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continuousControllersToolStripMenuItem,
            this.statebasedControllersToolStripMenuItem,
            this.inputOutputToolStripMenuItem});
            this.testSettingsToolStripMenuItem.Name = "testSettingsToolStripMenuItem";
            this.testSettingsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.testSettingsToolStripMenuItem.Text = "Test Settings";
            // 
            // continuousControllersToolStripMenuItem
            // 
            this.continuousControllersToolStripMenuItem.Name = "continuousControllersToolStripMenuItem";
            this.continuousControllersToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.continuousControllersToolStripMenuItem.Text = "Continuous Controllers";
            this.continuousControllersToolStripMenuItem.Click += new System.EventHandler(this.continuousControllersToolStripMenuItem_Click);
            // 
            // statebasedControllersToolStripMenuItem
            // 
            this.statebasedControllersToolStripMenuItem.Name = "statebasedControllersToolStripMenuItem";
            this.statebasedControllersToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.statebasedControllersToolStripMenuItem.Text = "State-based Controllers";
            this.statebasedControllersToolStripMenuItem.Visible = false;
            // 
            // inputOutputToolStripMenuItem
            // 
            this.inputOutputToolStripMenuItem.Enabled = false;
            this.inputOutputToolStripMenuItem.Name = "inputOutputToolStripMenuItem";
            this.inputOutputToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.inputOutputToolStripMenuItem.Text = "Input/Output Functions";
            this.inputOutputToolStripMenuItem.Visible = false;
            // 
            // advancedTestSettingsToolStripMenuItem
            // 
            this.advancedTestSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continuousControllersToolStripMenuItem1,
            this.statebasedControllersToolStripMenuItem1,
            this.inputOutputFunctionsToolStripMenuItem});
            this.advancedTestSettingsToolStripMenuItem.Name = "advancedTestSettingsToolStripMenuItem";
            this.advancedTestSettingsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.advancedTestSettingsToolStripMenuItem.Text = "Advanced Test Settings";
            this.advancedTestSettingsToolStripMenuItem.Visible = false;
            // 
            // continuousControllersToolStripMenuItem1
            // 
            this.continuousControllersToolStripMenuItem1.Name = "continuousControllersToolStripMenuItem1";
            this.continuousControllersToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.continuousControllersToolStripMenuItem1.Text = "Continuous Controllers";
            this.continuousControllersToolStripMenuItem1.Click += new System.EventHandler(this.continuousControllersToolStripMenuItem1_Click);
            // 
            // statebasedControllersToolStripMenuItem1
            // 
            this.statebasedControllersToolStripMenuItem1.Name = "statebasedControllersToolStripMenuItem1";
            this.statebasedControllersToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.statebasedControllersToolStripMenuItem1.Text = "State-based Controllers";
            this.statebasedControllersToolStripMenuItem1.Visible = false;
            this.statebasedControllersToolStripMenuItem1.Click += new System.EventHandler(this.statebasedControllersToolStripMenuItem1_Click);
            // 
            // inputOutputFunctionsToolStripMenuItem
            // 
            this.inputOutputFunctionsToolStripMenuItem.Enabled = false;
            this.inputOutputFunctionsToolStripMenuItem.Name = "inputOutputFunctionsToolStripMenuItem";
            this.inputOutputFunctionsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.inputOutputFunctionsToolStripMenuItem.Text = "Input/Output Functions";
            this.inputOutputFunctionsToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMiLTesterToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutMiLTesterToolStripMenuItem
            // 
            this.aboutMiLTesterToolStripMenuItem.Name = "aboutMiLTesterToolStripMenuItem";
            this.aboutMiLTesterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.aboutMiLTesterToolStripMenuItem.Text = "About SimCoTest";
            this.aboutMiLTesterToolStripMenuItem.Click += new System.EventHandler(this.aboutMiLTesterToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdSLTestSettings);
            this.groupBox1.Controls.Add(this.btnSLTestSettings);
            this.groupBox1.Controls.Add(this.btnAdCCTestSettings);
            this.groupBox1.Controls.Add(this.btnCCTestSettings);
            this.groupBox1.Controls.Add(this.btnNewTestWorkspace);
            this.groupBox1.Controls.Add(this.btnModelSetting);
            this.groupBox1.Location = new System.Drawing.Point(5, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 60);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnAdSLTestSettings
            // 
            this.btnAdSLTestSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdSLTestSettings.BackgroundImage")));
            this.btnAdSLTestSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdSLTestSettings.Location = new System.Drawing.Point(195, 12);
            this.btnAdSLTestSettings.Name = "btnAdSLTestSettings";
            this.btnAdSLTestSettings.Size = new System.Drawing.Size(44, 42);
            this.btnAdSLTestSettings.TabIndex = 28;
            this.btnAdSLTestSettings.UseVisualStyleBackColor = true;
            this.btnAdSLTestSettings.Visible = false;
            this.btnAdSLTestSettings.Click += new System.EventHandler(this.btnAdSBTestSettings_Click);
            // 
            // btnSLTestSettings
            // 
            this.btnSLTestSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSLTestSettings.BackgroundImage")));
            this.btnSLTestSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSLTestSettings.Location = new System.Drawing.Point(100, 12);
            this.btnSLTestSettings.Name = "btnSLTestSettings";
            this.btnSLTestSettings.Size = new System.Drawing.Size(44, 42);
            this.btnSLTestSettings.TabIndex = 27;
            this.btnSLTestSettings.UseVisualStyleBackColor = true;
            this.btnSLTestSettings.Click += new System.EventHandler(this.btnSBTestSettings_Click);
            // 
            // btnAdCCTestSettings
            // 
            this.btnAdCCTestSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdCCTestSettings.BackgroundImage")));
            this.btnAdCCTestSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdCCTestSettings.Location = new System.Drawing.Point(242, 12);
            this.btnAdCCTestSettings.Name = "btnAdCCTestSettings";
            this.btnAdCCTestSettings.Size = new System.Drawing.Size(44, 42);
            this.btnAdCCTestSettings.TabIndex = 26;
            this.btnAdCCTestSettings.UseVisualStyleBackColor = true;
            this.btnAdCCTestSettings.Visible = false;
            this.btnAdCCTestSettings.Click += new System.EventHandler(this.btnAdCCTestSettings_Click);
            // 
            // btnCCTestSettings
            // 
            this.btnCCTestSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCCTestSettings.BackgroundImage")));
            this.btnCCTestSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCCTestSettings.Location = new System.Drawing.Point(148, 12);
            this.btnCCTestSettings.Name = "btnCCTestSettings";
            this.btnCCTestSettings.Size = new System.Drawing.Size(44, 42);
            this.btnCCTestSettings.TabIndex = 25;
            this.btnCCTestSettings.UseVisualStyleBackColor = true;
            this.btnCCTestSettings.Click += new System.EventHandler(this.btnCCTestSettings_Click);
            // 
            // btnNewTestWorkspace
            // 
            this.btnNewTestWorkspace.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewTestWorkspace.BackgroundImage")));
            this.btnNewTestWorkspace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNewTestWorkspace.Location = new System.Drawing.Point(6, 12);
            this.btnNewTestWorkspace.Name = "btnNewTestWorkspace";
            this.btnNewTestWorkspace.Size = new System.Drawing.Size(44, 42);
            this.btnNewTestWorkspace.TabIndex = 24;
            this.btnNewTestWorkspace.UseVisualStyleBackColor = true;
            this.btnNewTestWorkspace.Click += new System.EventHandler(this.btnNewTestWorkspace_Click);
            // 
            // btnModelSetting
            // 
            this.btnModelSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModelSetting.BackgroundImage")));
            this.btnModelSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModelSetting.Location = new System.Drawing.Point(53, 12);
            this.btnModelSetting.Name = "btnModelSetting";
            this.btnModelSetting.Size = new System.Drawing.Size(44, 42);
            this.btnModelSetting.TabIndex = 23;
            this.btnModelSetting.UseVisualStyleBackColor = true;
            this.btnModelSetting.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnDuplicate);
            this.groupBox2.Controls.Add(this.btnRename);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnViewResults);
            this.groupBox2.Controls.Add(this.tbDetails);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbTestWorkspaces);
            this.groupBox2.Location = new System.Drawing.Point(5, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 395);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "btnTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(292, 367);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(64, 23);
            this.btnExport.TabIndex = 40;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(588, 367);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 23);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Enabled = false;
            this.btnDuplicate.Location = new System.Drawing.Point(224, 367);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(64, 23);
            this.btnDuplicate.TabIndex = 38;
            this.btnDuplicate.Text = "Duplicate";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnRename
            // 
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(90, 367);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(64, 23);
            this.btnRename.TabIndex = 37;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(157, 367);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Enabled = false;
            this.btnViewResults.Location = new System.Drawing.Point(5, 367);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(82, 23);
            this.btnViewResults.TabIndex = 35;
            this.btnViewResults.Text = "View Results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // tbDetails
            // 
            this.tbDetails.BackColor = System.Drawing.Color.White;
            this.tbDetails.Location = new System.Drawing.Point(180, 35);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ReadOnly = true;
            this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetails.Size = new System.Drawing.Size(472, 329);
            this.tbDetails.TabIndex = 34;
            this.tbDetails.TextChanged += new System.EventHandler(this.tbDetails_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Test Workspaces";
            // 
            // lbTestWorkspaces
            // 
            this.lbTestWorkspaces.FormattingEnabled = true;
            this.lbTestWorkspaces.Location = new System.Drawing.Point(6, 35);
            this.lbTestWorkspaces.Name = "lbTestWorkspaces";
            this.lbTestWorkspaces.Size = new System.Drawing.Size(170, 329);
            this.lbTestWorkspaces.TabIndex = 19;
            this.lbTestWorkspaces.SelectedIndexChanged += new System.EventHandler(this.lbTestWorkspaces_SelectedIndexChanged);
            this.lbTestWorkspaces.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTestWorkspaces_MouseDoubleClick);
            this.lbTestWorkspaces.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbTestWorkspaces_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(665, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.programMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.programMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimCoTest";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.programMenu.ResumeLayout(false);
            this.programMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip programMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMiLTesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miLTesterSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continuousControllersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedTestSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continuousControllersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statebasedControllersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inputOutputFunctionsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdCCTestSettings;
        private System.Windows.Forms.Button btnCCTestSettings;
        private System.Windows.Forms.Button btnNewTestWorkspace;
        private System.Windows.Forms.Button btnModelSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog eximportFolderDialog;
        private System.Windows.Forms.ToolStripMenuItem statebasedControllersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWorkspacesFromToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog openWorkspacesBrowserDialog;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.ListBox lbTestWorkspaces;
        private System.Windows.Forms.Button btnAdSLTestSettings;
        private System.Windows.Forms.Button btnSLTestSettings;
        private System.Windows.Forms.Button button1;
    }
}