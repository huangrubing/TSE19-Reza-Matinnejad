namespace MiLTester.SourceCode.Presentation.Results
{
    partial class SLTestWorkspaceResultsForm
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
            this.cmbCriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbWorstTestCases = new System.Windows.Forms.GroupBox();
            this.lvOutputs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvSignals = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbCalVars = new System.Windows.Forms.ComboBox();
            this.lvTestCases = new System.Windows.Forms.ListView();
            this.TestCaseNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRunTestCase = new System.Windows.Forms.Button();
            this.tbCalValue = new System.Windows.Forms.TextBox();
            this.cmbInputVars = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.gbWorstTestCases.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCriteria
            // 
            this.cmbCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriteria.FormattingEnabled = true;
            this.cmbCriteria.Location = new System.Drawing.Point(124, 31);
            this.cmbCriteria.Name = "cmbCriteria";
            this.cmbCriteria.Size = new System.Drawing.Size(168, 21);
            this.cmbCriteria.TabIndex = 23;
            this.cmbCriteria.SelectedIndexChanged += new System.EventHandler(this.cmbCriteria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Generation Algorithm:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(522, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbWorstTestCases
            // 
            this.gbWorstTestCases.Controls.Add(this.lvOutputs);
            this.gbWorstTestCases.Controls.Add(this.groupBox1);
            this.gbWorstTestCases.Location = new System.Drawing.Point(9, 54);
            this.gbWorstTestCases.Name = "gbWorstTestCases";
            this.gbWorstTestCases.Size = new System.Drawing.Size(588, 281);
            this.gbWorstTestCases.TabIndex = 27;
            this.gbWorstTestCases.TabStop = false;
            this.gbWorstTestCases.Text = "Prioritized Test Suites";
            // 
            // lvOutputs
            // 
            this.lvOutputs.AutoArrange = false;
            this.lvOutputs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5});
            this.lvOutputs.FullRowSelect = true;
            this.lvOutputs.GridLines = true;
            this.lvOutputs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOutputs.HideSelection = false;
            this.lvOutputs.Location = new System.Drawing.Point(6, 20);
            this.lvOutputs.MultiSelect = false;
            this.lvOutputs.Name = "lvOutputs";
            this.lvOutputs.Size = new System.Drawing.Size(267, 254);
            this.lvOutputs.TabIndex = 62;
            this.lvOutputs.UseCompatibleStateImageBehavior = false;
            this.lvOutputs.View = System.Windows.Forms.View.Details;
            this.lvOutputs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvOutputs_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Row";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Port";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 32;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Output Name";
            this.columnHeader5.Width = 193;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvSignals);
            this.groupBox1.Controls.Add(this.cmbCalVars);
            this.groupBox1.Controls.Add(this.lvTestCases);
            this.groupBox1.Controls.Add(this.btnRunTestCase);
            this.groupBox1.Controls.Add(this.tbCalValue);
            this.groupBox1.Controls.Add(this.cmbInputVars);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(275, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 256);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Cases";
            // 
            // lvSignals
            // 
            this.lvSignals.AutoArrange = false;
            this.lvSignals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvSignals.FullRowSelect = true;
            this.lvSignals.GridLines = true;
            this.lvSignals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSignals.HideSelection = false;
            this.lvSignals.Location = new System.Drawing.Point(90, 60);
            this.lvSignals.MultiSelect = false;
            this.lvSignals.Name = "lvSignals";
            this.lvSignals.Size = new System.Drawing.Size(216, 113);
            this.lvSignals.TabIndex = 66;
            this.lvSignals.UseCompatibleStateImageBehavior = false;
            this.lvSignals.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Value";
            this.columnHeader3.Width = 118;
            // 
            // cmbCalVars
            // 
            this.cmbCalVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalVars.FormattingEnabled = true;
            this.cmbCalVars.Location = new System.Drawing.Point(91, 204);
            this.cmbCalVars.Name = "cmbCalVars";
            this.cmbCalVars.Size = new System.Drawing.Size(214, 21);
            this.cmbCalVars.TabIndex = 63;
            this.cmbCalVars.SelectedIndexChanged += new System.EventHandler(this.cmbCalVars_SelectedIndexChanged);
            // 
            // lvTestCases
            // 
            this.lvTestCases.AutoArrange = false;
            this.lvTestCases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TestCaseNumber});
            this.lvTestCases.FullRowSelect = true;
            this.lvTestCases.GridLines = true;
            this.lvTestCases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTestCases.HideSelection = false;
            this.lvTestCases.Location = new System.Drawing.Point(7, 19);
            this.lvTestCases.MultiSelect = false;
            this.lvTestCases.Name = "lvTestCases";
            this.lvTestCases.Size = new System.Drawing.Size(79, 205);
            this.lvTestCases.TabIndex = 61;
            this.lvTestCases.UseCompatibleStateImageBehavior = false;
            this.lvTestCases.View = System.Windows.Forms.View.Details;
            this.lvTestCases.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvTestCases_ItemSelectionChanged);
            // 
            // TestCaseNumber
            // 
            this.TestCaseNumber.Text = "Test Case";
            this.TestCaseNumber.Width = 74;
            // 
            // btnRunTestCase
            // 
            this.btnRunTestCase.Location = new System.Drawing.Point(7, 229);
            this.btnRunTestCase.Name = "btnRunTestCase";
            this.btnRunTestCase.Size = new System.Drawing.Size(79, 23);
            this.btnRunTestCase.TabIndex = 60;
            this.btnRunTestCase.Text = "Run";
            this.btnRunTestCase.UseVisualStyleBackColor = true;
            this.btnRunTestCase.Click += new System.EventHandler(this.btnRunTestCase_Click);
            // 
            // tbCalValue
            // 
            this.tbCalValue.Location = new System.Drawing.Point(135, 231);
            this.tbCalValue.Name = "tbCalValue";
            this.tbCalValue.Size = new System.Drawing.Size(170, 20);
            this.tbCalValue.TabIndex = 65;
            // 
            // cmbInputVars
            // 
            this.cmbInputVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputVars.FormattingEnabled = true;
            this.cmbInputVars.Location = new System.Drawing.Point(89, 35);
            this.cmbInputVars.Name = "cmbInputVars";
            this.cmbInputVars.Size = new System.Drawing.Size(216, 21);
            this.cmbInputVars.TabIndex = 64;
            this.cmbInputVars.SelectedIndexChanged += new System.EventHandler(this.cmbInputVars_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Input Signal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Configuration Parameter:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Model Name:";
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(124, 6);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.ReadOnly = true;
            this.tbModelName.Size = new System.Drawing.Size(168, 20);
            this.tbModelName.TabIndex = 68;
            // 
            // SLTestWorkspaceResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 367);
            this.Controls.Add(this.tbModelName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbWorstTestCases);
            this.Controls.Add(this.cmbCriteria);
            this.Controls.Add(this.label1);
            this.Name = "SLTestWorkspaceResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Generation Results";
            this.gbWorstTestCases.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbWorstTestCases;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCalVars;
        private System.Windows.Forms.Button btnRunTestCase;
        private System.Windows.Forms.TextBox tbCalValue;
        private System.Windows.Forms.ComboBox cmbInputVars;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbModelName;
        private System.Windows.Forms.ListView lvTestCases;
        private System.Windows.Forms.ColumnHeader TestCaseNumber;
        private System.Windows.Forms.ListView lvOutputs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvSignals;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}