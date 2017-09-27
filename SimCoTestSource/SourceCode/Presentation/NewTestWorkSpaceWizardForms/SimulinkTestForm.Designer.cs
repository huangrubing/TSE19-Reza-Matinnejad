namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    partial class SimulinkTestForm
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
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbUseDefForConfig = new System.Windows.Forms.CheckBox();
            this.tbDefValue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbVarMaxTest = new System.Windows.Forms.TextBox();
            this.tbVarMinTest = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbVarType = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbVarType = new System.Windows.Forms.ComboBox();
            this.tbVarTo = new System.Windows.Forms.TextBox();
            this.tbVarFrom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbVarDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVarName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lvVariables = new System.Windows.Forms.ListView();
            this.VariableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DTName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DTFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DTTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BlockPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.tbSimulationTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRunModel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(330, 385);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(486, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbModelName);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbUseDefForConfig);
            this.groupBox2.Controls.Add(this.tbDefValue);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbVarMaxTest);
            this.groupBox2.Controls.Add(this.tbVarMinTest);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbVarType);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.cmbVarType);
            this.groupBox2.Controls.Add(this.tbVarTo);
            this.groupBox2.Controls.Add(this.tbVarFrom);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbVarDT);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbVarName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lvVariables);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbSimulationTime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnRunModel);
            this.groupBox2.Location = new System.Drawing.Point(2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 377);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulink Model Variables";
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(92, 27);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.ReadOnly = true;
            this.tbModelName.Size = new System.Drawing.Size(172, 20);
            this.tbModelName.TabIndex = 98;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 97;
            this.label15.Text = "Filter the list by Variable Type:";
            // 
            // cbUseDefForConfig
            // 
            this.cbUseDefForConfig.AutoSize = true;
            this.cbUseDefForConfig.Enabled = false;
            this.cbUseDefForConfig.Location = new System.Drawing.Point(8, 349);
            this.cbUseDefForConfig.Name = "cbUseDefForConfig";
            this.cbUseDefForConfig.Size = new System.Drawing.Size(144, 17);
            this.cbUseDefForConfig.TabIndex = 96;
            this.cbUseDefForConfig.Text = "Use default value for test";
            this.cbUseDefForConfig.UseVisualStyleBackColor = true;
            this.cbUseDefForConfig.CheckedChanged += new System.EventHandler(this.cbUseDefForConfig_CheckedChanged);
            // 
            // tbDefValue
            // 
            this.tbDefValue.Location = new System.Drawing.Point(296, 262);
            this.tbDefValue.Name = "tbDefValue";
            this.tbDefValue.ReadOnly = true;
            this.tbDefValue.Size = new System.Drawing.Size(153, 20);
            this.tbDefValue.TabIndex = 95;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "Default:";
            // 
            // tbVarMaxTest
            // 
            this.tbVarMaxTest.Location = new System.Drawing.Point(297, 319);
            this.tbVarMaxTest.Name = "tbVarMaxTest";
            this.tbVarMaxTest.Size = new System.Drawing.Size(153, 20);
            this.tbVarMaxTest.TabIndex = 93;
            // 
            // tbVarMinTest
            // 
            this.tbVarMinTest.Location = new System.Drawing.Point(69, 319);
            this.tbVarMinTest.Name = "tbVarMinTest";
            this.tbVarMinTest.Size = new System.Drawing.Size(152, 20);
            this.tbVarMinTest.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(229, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "Max for test:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 90;
            this.label13.Text = "Min for test:";
            // 
            // tbVarType
            // 
            this.tbVarType.Location = new System.Drawing.Point(296, 235);
            this.tbVarType.Name = "tbVarType";
            this.tbVarType.ReadOnly = true;
            this.tbVarType.Size = new System.Drawing.Size(153, 20);
            this.tbVarType.TabIndex = 89;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(455, 232);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(99, 23);
            this.btnOpen.TabIndex = 87;
            this.btnOpen.Text = "Highlight in Model";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbVarType
            // 
            this.cmbVarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVarType.FormattingEnabled = true;
            this.cmbVarType.Items.AddRange(new object[] {
            "All",
            "Input",
            "Configuration",
            "Output"});
            this.cmbVarType.Location = new System.Drawing.Point(161, 57);
            this.cmbVarType.Name = "cmbVarType";
            this.cmbVarType.Size = new System.Drawing.Size(84, 21);
            this.cmbVarType.TabIndex = 86;
            this.cmbVarType.SelectedIndexChanged += new System.EventHandler(this.cmbVarType_SelectedIndexChanged);
            // 
            // tbVarTo
            // 
            this.tbVarTo.Location = new System.Drawing.Point(296, 290);
            this.tbVarTo.Name = "tbVarTo";
            this.tbVarTo.ReadOnly = true;
            this.tbVarTo.Size = new System.Drawing.Size(153, 20);
            this.tbVarTo.TabIndex = 85;
            // 
            // tbVarFrom
            // 
            this.tbVarFrom.Location = new System.Drawing.Point(68, 290);
            this.tbVarFrom.Name = "tbVarFrom";
            this.tbVarFrom.ReadOnly = true;
            this.tbVarFrom.Size = new System.Drawing.Size(152, 20);
            this.tbVarFrom.TabIndex = 84;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 83;
            this.label11.Text = "Max:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 82;
            this.label10.Text = "Min:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "Type:";
            // 
            // tbVarDT
            // 
            this.tbVarDT.Location = new System.Drawing.Point(68, 262);
            this.tbVarDT.Name = "tbVarDT";
            this.tbVarDT.ReadOnly = true;
            this.tbVarDT.Size = new System.Drawing.Size(153, 20);
            this.tbVarDT.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "DataType:";
            // 
            // tbVarName
            // 
            this.tbVarName.Location = new System.Drawing.Point(68, 234);
            this.tbVarName.Name = "tbVarName";
            this.tbVarName.ReadOnly = true;
            this.tbVarName.Size = new System.Drawing.Size(153, 20);
            this.tbVarName.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Model Name:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(127, 361);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 71;
            // 
            // lvVariables
            // 
            this.lvVariables.AutoArrange = false;
            this.lvVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VariableName,
            this.Type,
            this.DTName,
            this.DTFrom,
            this.DTTo,
            this.BlockPath});
            this.lvVariables.FullRowSelect = true;
            this.lvVariables.GridLines = true;
            this.lvVariables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvVariables.HideSelection = false;
            this.lvVariables.Location = new System.Drawing.Point(8, 85);
            this.lvVariables.MultiSelect = false;
            this.lvVariables.Name = "lvVariables";
            this.lvVariables.Size = new System.Drawing.Size(546, 141);
            this.lvVariables.TabIndex = 64;
            this.lvVariables.UseCompatibleStateImageBehavior = false;
            this.lvVariables.View = System.Windows.Forms.View.Details;
            this.lvVariables.SelectedIndexChanged += new System.EventHandler(this.lvCalibrationVariables_SelectedIndexChanged);
            this.lvVariables.DoubleClick += new System.EventHandler(this.lvVariables_DoubleClick);
            // 
            // VariableName
            // 
            this.VariableName.Text = "Name";
            this.VariableName.Width = 152;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 85;
            // 
            // DTName
            // 
            this.DTName.Text = "DataType";
            this.DTName.Width = 74;
            // 
            // DTFrom
            // 
            this.DTFrom.Text = "From";
            this.DTFrom.Width = 55;
            // 
            // DTTo
            // 
            this.DTTo.Text = "To";
            this.DTTo.Width = 71;
            // 
            // BlockPath
            // 
            this.BlockPath.Text = "Block Path";
            this.BlockPath.Width = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Seconds";
            // 
            // tbSimulationTime
            // 
            this.tbSimulationTime.Location = new System.Drawing.Point(406, 27);
            this.tbSimulationTime.Name = "tbSimulationTime";
            this.tbSimulationTime.Size = new System.Drawing.Size(38, 20);
            this.tbSimulationTime.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Model Simulation Time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(121, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 34;
            // 
            // btnRunModel
            // 
            this.btnRunModel.Location = new System.Drawing.Point(439, 345);
            this.btnRunModel.Name = "btnRunModel";
            this.btnRunModel.Size = new System.Drawing.Size(115, 23);
            this.btnRunModel.TabIndex = 10;
            this.btnRunModel.Text = "Run Model for Test";
            this.btnRunModel.UseVisualStyleBackColor = true;
            this.btnRunModel.Click += new System.EventHandler(this.btnRunModel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(408, 385);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // SimulinkTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 413);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNext);
            this.Name = "SimulinkTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Extraction Results";
            this.Shown += new System.EventHandler(this.SimulinkTestForm_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListView lvVariables;
        private System.Windows.Forms.ColumnHeader VariableName;
        private System.Windows.Forms.ColumnHeader DTName;
        private System.Windows.Forms.ColumnHeader DTFrom;
        private System.Windows.Forms.ColumnHeader DTTo;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSimulationTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRunModel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ColumnHeader BlockPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVarDT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVarName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbVarTo;
        private System.Windows.Forms.TextBox tbVarFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cmbVarType;
        private System.Windows.Forms.TextBox tbVarType;
        private System.Windows.Forms.TextBox tbVarMaxTest;
        private System.Windows.Forms.TextBox tbVarMinTest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDefValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbUseDefForConfig;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbModelName;
    }
}