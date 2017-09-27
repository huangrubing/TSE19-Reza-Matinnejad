using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    class ParentAdvancedCCSettingsForm : Panel
    {
        public ParentAdvancedCCSettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAlgorihtmTypes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sbRoundsNum = new System.Windows.Forms.NumericUpDown();
            this.sbIterationsNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLocalSearchAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEscapeRandomExploration = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRandomExplorationAlgorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbRoundsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbIterationsNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAlgorihtmTypes);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.sbRoundsNum);
            this.groupBox2.Controls.Add(this.sbIterationsNum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbLocalSearchAlgorithm);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(2, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 139);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single-State Search";
            // 
            // cmbAlgorihtmTypes
            // 
            this.cmbAlgorihtmTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorihtmTypes.FormattingEnabled = true;
            this.cmbAlgorihtmTypes.Location = new System.Drawing.Point(174, 110);
            this.cmbAlgorihtmTypes.Name = "cmbAlgorihtmTypes";
            this.cmbAlgorihtmTypes.Size = new System.Drawing.Size(127, 21);
            this.cmbAlgorihtmTypes.Items.AddRange(new object[] {
            MiLTester.SourceCode.Bussiness.Settings.SingelStateSearchAlgorithmTypeEnum.Explorative,
            MiLTester.SourceCode.Bussiness.Settings.SingelStateSearchAlgorithmTypeEnum.Exploitative});
            this.cmbAlgorihtmTypes.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Type";
            // 
            // sbRoundsNum
            // 
            this.sbRoundsNum.Location = new System.Drawing.Point(174, 82);
            this.sbRoundsNum.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sbRoundsNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbRoundsNum.Name = "sbRoundsNum";
            this.sbRoundsNum.Size = new System.Drawing.Size(71, 20);
            this.sbRoundsNum.TabIndex = 7;
            this.sbRoundsNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sbIterationsNum
            // 
            this.sbIterationsNum.Location = new System.Drawing.Point(174, 55);
            this.sbIterationsNum.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sbIterationsNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbIterationsNum.Name = "sbIterationsNum";
            this.sbIterationsNum.Size = new System.Drawing.Size(71, 20);
            this.sbIterationsNum.TabIndex = 6;
            this.sbIterationsNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Algorithm Rounds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Algorithm Iterations";
            // 
            // cmbLocalSearchAlgorithm
            // 
            this.cmbLocalSearchAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalSearchAlgorithm.FormattingEnabled = true;
            this.cmbLocalSearchAlgorithm.Items.AddRange(new object[] {
            MiLTester.SourceCode.Bussiness.Settings.SingelStateSearchAlgorithmsEnum.RandomSearch,
            MiLTester.SourceCode.Bussiness.Settings.SingelStateSearchAlgorithmsEnum.HillClimbing,
            MiLTester.SourceCode.Bussiness.Settings.SingelStateSearchAlgorithmsEnum.HCRR,
            MiLTester.SourceCode.Bussiness.Settings.SingelStateSearchAlgorithmsEnum.SimulatedAnnealing});
            this.cmbLocalSearchAlgorithm.Location = new System.Drawing.Point(174, 23);
            this.cmbLocalSearchAlgorithm.Name = "cmbLocalSearchAlgorithm";
            this.cmbLocalSearchAlgorithm.Size = new System.Drawing.Size(201, 21);
            this.cmbLocalSearchAlgorithm.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Search Algorithm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEscapeRandomExploration);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbRandomExplorationAlgorithm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 76);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Random Exploration";
            // 
            // cbEscapeRandomExploration
            // 
            this.cbEscapeRandomExploration.AutoSize = true;
            this.cbEscapeRandomExploration.Location = new System.Drawing.Point(174, 53);
            this.cbEscapeRandomExploration.Name = "cbEscapeRandomExploration";
            this.cbEscapeRandomExploration.Size = new System.Drawing.Size(44, 17);
            this.cbEscapeRandomExploration.TabIndex = 4;
            this.cbEscapeRandomExploration.Text = "Yes";
            this.cbEscapeRandomExploration.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Escape Random Exploration";
            // 
            // cmbRandomExplorationAlgorithm
            // 
            this.cmbRandomExplorationAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRandomExplorationAlgorithm.FormattingEnabled = true;
            this.cmbRandomExplorationAlgorithm.Items.AddRange(new object[] {
            MiLTester.SourceCode.Bussiness.Settings.RandomExplorationAlgorithmsEnum.RandomSearch,
            MiLTester.SourceCode.Bussiness.Settings.RandomExplorationAlgorithmsEnum.AdaptiveRandomSearch});
            this.cmbRandomExplorationAlgorithm.Location = new System.Drawing.Point(174, 26);
            this.cmbRandomExplorationAlgorithm.Name = "cmbRandomExplorationAlgorithm";
            this.cmbRandomExplorationAlgorithm.Size = new System.Drawing.Size(201, 21);
            this.cmbRandomExplorationAlgorithm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Random Exploaration Algorithm";
            // 
            // ParentAdvancedCCSettingsForm
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Size = new System.Drawing.Size(385, 222);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbRoundsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbIterationsNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadAdvancedCCSettings(AdvancedCCSettings advancedCCSettings)
        {
            cmbRandomExplorationAlgorithm.SelectedItem = advancedCCSettings.randomExplorationAlgorithm;
            cbEscapeRandomExploration.Checked = advancedCCSettings.escapeRandomExploration;
            cmbLocalSearchAlgorithm.SelectedItem = advancedCCSettings.singelStateSearchAlgorithm;
            sbIterationsNum.Value = advancedCCSettings.algorithmIterations;
            sbRoundsNum.Value = advancedCCSettings.algorithmRounds;
            cmbAlgorihtmTypes.SelectedItem = advancedCCSettings.algorithmType;
        }

        public AdvancedCCSettings ReadAdvancedCCSettings()
        {
            AdvancedCCSettings advancedCCSettings = new AdvancedCCSettings();
            advancedCCSettings.randomExplorationAlgorithm = (RandomExplorationAlgorithmsEnum)cmbRandomExplorationAlgorithm.SelectedItem;
            advancedCCSettings.escapeRandomExploration = cbEscapeRandomExploration.Checked;
            advancedCCSettings.singelStateSearchAlgorithm = (SingelStateSearchAlgorithmsEnum)cmbLocalSearchAlgorithm.SelectedItem;
            advancedCCSettings.algorithmIterations = (int)sbIterationsNum.Value;
            advancedCCSettings.algorithmRounds = (int)sbRoundsNum.Value;
            advancedCCSettings.algorithmType = (SingelStateSearchAlgorithmTypeEnum)cmbAlgorihtmTypes.SelectedItem;
            return advancedCCSettings;
        }
        
        private GroupBox groupBox2;
        private NumericUpDown sbRoundsNum;
        private NumericUpDown sbIterationsNum;
        private Label label4;
        private Label label3;
        private ComboBox cmbLocalSearchAlgorithm;
        private Label label2;
        private GroupBox groupBox1;
        private ComboBox cmbRandomExplorationAlgorithm;
        private CheckBox cbEscapeRandomExploration;
        private Label label5;
        private Label label6;
        private ComboBox cmbAlgorihtmTypes;
        private Label label1;

    }
}
