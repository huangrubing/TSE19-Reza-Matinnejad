namespace MiLTester.SourceCode.Presentation.Results
{
    partial class CCTestWorkspaceResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCTestWorkspaceResultsForm));
            this.gbWorstTestCases = new System.Windows.Forms.GroupBox();
            this.lvTestCases = new System.Windows.Forms.ListView();
            this.TestCaseNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InitialDesired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FinalDesired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRunTestCase = new System.Windows.Forms.Button();
            this.HeatMapPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRequirements = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbHeatMap = new System.Windows.Forms.GroupBox();
            this.tbFinalDsrdTest = new System.Windows.Forms.TextBox();
            this.tbInitialDsrdTest = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRunModel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblWorkspaceName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbWorstTestCases.SuspendLayout();
            this.gbHeatMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbWorstTestCases
            // 
            this.gbWorstTestCases.Controls.Add(this.lvTestCases);
            this.gbWorstTestCases.Controls.Add(this.btnRunTestCase);
            this.gbWorstTestCases.Location = new System.Drawing.Point(4, 507);
            this.gbWorstTestCases.Name = "gbWorstTestCases";
            this.gbWorstTestCases.Size = new System.Drawing.Size(395, 150);
            this.gbWorstTestCases.TabIndex = 17;
            this.gbWorstTestCases.TabStop = false;
            this.gbWorstTestCases.Text = "Worst-case Test Scenarios";
            // 
            // lvTestCases
            // 
            this.lvTestCases.AutoArrange = false;
            this.lvTestCases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TestCaseNumber,
            this.InitialDesired,
            this.FinalDesired});
            this.lvTestCases.FullRowSelect = true;
            this.lvTestCases.GridLines = true;
            this.lvTestCases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTestCases.HideSelection = false;
            this.lvTestCases.Location = new System.Drawing.Point(13, 19);
            this.lvTestCases.MultiSelect = false;
            this.lvTestCases.Name = "lvTestCases";
            this.lvTestCases.Size = new System.Drawing.Size(378, 96);
            this.lvTestCases.TabIndex = 1;
            this.lvTestCases.UseCompatibleStateImageBehavior = false;
            this.lvTestCases.View = System.Windows.Forms.View.Details;
            this.lvTestCases.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvTestCases_ColumnWidthChanging);
            this.lvTestCases.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvTestCases_ItemSelectionChanged);
            this.lvTestCases.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvTestCases_MouseClick);
            this.lvTestCases.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTestCases_MouseDoubleClick);
            // 
            // TestCaseNumber
            // 
            this.TestCaseNumber.Text = "Number";
            this.TestCaseNumber.Width = 81;
            // 
            // InitialDesired
            // 
            this.InitialDesired.Text = "Initial Desired";
            this.InitialDesired.Width = 141;
            // 
            // FinalDesired
            // 
            this.FinalDesired.Text = "Final Desired";
            this.FinalDesired.Width = 152;
            // 
            // btnRunTestCase
            // 
            this.btnRunTestCase.Location = new System.Drawing.Point(240, 121);
            this.btnRunTestCase.Name = "btnRunTestCase";
            this.btnRunTestCase.Size = new System.Drawing.Size(151, 23);
            this.btnRunTestCase.TabIndex = 0;
            this.btnRunTestCase.Text = "Run the Selected Test Case";
            this.btnRunTestCase.UseVisualStyleBackColor = true;
            this.btnRunTestCase.Click += new System.EventHandler(this.btnRunTestCase_Click);
            // 
            // HeatMapPanel
            // 
            this.HeatMapPanel.BackColor = System.Drawing.SystemColors.Control;
            this.HeatMapPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeatMapPanel.Location = new System.Drawing.Point(32, 24);
            this.HeatMapPanel.Name = "HeatMapPanel";
            this.HeatMapPanel.Size = new System.Drawing.Size(344, 344);
            this.HeatMapPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Workspace Name:";
            // 
            // cmbRequirements
            // 
            this.cmbRequirements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequirements.FormattingEnabled = true;
            this.cmbRequirements.Location = new System.Drawing.Point(105, 30);
            this.cmbRequirements.Name = "cmbRequirements";
            this.cmbRequirements.Size = new System.Drawing.Size(168, 21);
            this.cmbRequirements.TabIndex = 1;
            this.cmbRequirements.SelectedIndexChanged += new System.EventHandler(this.cmbRequirements_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Requirement:";
            // 
            // gbHeatMap
            // 
            this.gbHeatMap.Controls.Add(this.tbFinalDsrdTest);
            this.gbHeatMap.Controls.Add(this.tbInitialDsrdTest);
            this.gbHeatMap.Controls.Add(this.HeatMapPanel);
            this.gbHeatMap.Controls.Add(this.label12);
            this.gbHeatMap.Controls.Add(this.btnRunModel);
            this.gbHeatMap.Controls.Add(this.label11);
            this.gbHeatMap.Location = new System.Drawing.Point(3, 52);
            this.gbHeatMap.Name = "gbHeatMap";
            this.gbHeatMap.Size = new System.Drawing.Size(396, 449);
            this.gbHeatMap.TabIndex = 18;
            this.gbHeatMap.TabStop = false;
            this.gbHeatMap.Text = "HeatMap Diagram";
            // 
            // tbFinalDsrdTest
            // 
            this.tbFinalDsrdTest.Location = new System.Drawing.Point(333, 409);
            this.tbFinalDsrdTest.Name = "tbFinalDsrdTest";
            this.tbFinalDsrdTest.Size = new System.Drawing.Size(57, 20);
            this.tbFinalDsrdTest.TabIndex = 4;
            this.tbFinalDsrdTest.TextChanged += new System.EventHandler(this.tbFinalDsrdTest_TextChanged);
            // 
            // tbInitialDsrdTest
            // 
            this.tbInitialDsrdTest.Location = new System.Drawing.Point(183, 409);
            this.tbInitialDsrdTest.Name = "tbInitialDsrdTest";
            this.tbInitialDsrdTest.Size = new System.Drawing.Size(55, 20);
            this.tbInitialDsrdTest.TabIndex = 3;
            this.tbInitialDsrdTest.TextChanged += new System.EventHandler(this.tbInitialDsrdTest_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(238, 412);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "and Final Desired = ";
            // 
            // btnRunModel
            // 
            this.btnRunModel.Location = new System.Drawing.Point(5, 406);
            this.btnRunModel.Name = "btnRunModel";
            this.btnRunModel.Size = new System.Drawing.Size(71, 23);
            this.btnRunModel.TabIndex = 2;
            this.btnRunModel.TabStop = false;
            this.btnRunModel.Text = "Run Model";
            this.btnRunModel.UseVisualStyleBackColor = true;
            this.btnRunModel.Click += new System.EventHandler(this.btnRunModel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 412);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "With Initial Desired = ";
            // 
            // lblWorkspaceName
            // 
            this.lblWorkspaceName.AutoSize = true;
            this.lblWorkspaceName.Location = new System.Drawing.Point(105, 11);
            this.lblWorkspaceName.Name = "lblWorkspaceName";
            this.lblWorkspaceName.Size = new System.Drawing.Size(90, 13);
            this.lblWorkspaceName.TabIndex = 22;
            this.lblWorkspaceName.Text = "WorkspaceName";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(325, 662);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CCTestWorkspaceResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 691);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblWorkspaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbRequirements);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbHeatMap);
            this.Controls.Add(this.gbWorstTestCases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CCTestWorkspaceResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Results";
            this.gbWorstTestCases.ResumeLayout(false);
            this.gbHeatMap.ResumeLayout(false);
            this.gbHeatMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWorstTestCases;
        private System.Windows.Forms.ListView lvTestCases;
        private System.Windows.Forms.Button btnRunTestCase;
        private System.Windows.Forms.Panel HeatMapPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRequirements;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbHeatMap;
        private System.Windows.Forms.Label lblWorkspaceName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader InitialDesired;
        private System.Windows.Forms.ColumnHeader FinalDesired;
        private System.Windows.Forms.ColumnHeader TestCaseNumber;
        private System.Windows.Forms.TextBox tbInitialDsrdTest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRunModel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFinalDsrdTest;

    }
}