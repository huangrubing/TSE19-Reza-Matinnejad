using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;
using MiLTester.SourceCode.Presentation.Components;
using MiLTester.SourceCode.Bussiness.Workspace;
using System.Drawing;
using System.Globalization;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    public class ParentCCSettingsForm: Panel
    {

        public ParentCCSettingsForm(ICCSettingsChangeListener ccSettingsChnageListener)
        {
            this.showLabels = false;
            this.ccSettingsChnageListener = ccSettingsChnageListener;
            InitializeComponent();
        }

        public ParentCCSettingsForm(ICCSettingsChangeListener ccSettingsChnageListener,float desiredValueStart,
            float desiredValueEnd)
        {
            this.showLabels = true;
            this.desiredValueStart = desiredValueStart;
            this.desiredValueEnd = desiredValueEnd;
            this.ccSettingsChnageListener = ccSettingsChnageListener;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.gbHeatMap = new System.Windows.Forms.GroupBox();
            this.sbHMAxesDivisionFactor = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.sbPointsInRegion = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chlbRequirements = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbWorstTestCases = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbUnionSliders = new System.Windows.Forms.RadioButton();
            this.rbIntersectionSliders = new System.Windows.Forms.RadioButton();
            this.HeatMapPanel = new System.Windows.Forms.Panel();
            this.lblGuideHeatMap = new System.Windows.Forms.Label();
            this.rbIncludeRegions = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbExcludeRegions = new System.Windows.Forms.RadioButton();
            this.sbWorstTestCasesNumber = new System.Windows.Forms.NumericUpDown();
            this.cbReportWostCases = new System.Windows.Forms.CheckBox();
            this.gbHeatMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbHMAxesDivisionFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPointsInRegion)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbWorstTestCases.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbWorstTestCasesNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHeatMap
            // 
            this.gbHeatMap.Controls.Add(this.sbHMAxesDivisionFactor);
            this.gbHeatMap.Controls.Add(this.label6);
            this.gbHeatMap.Controls.Add(this.sbPointsInRegion);
            this.gbHeatMap.Controls.Add(this.label5);
            this.gbHeatMap.Location = new System.Drawing.Point(2, 1);
            this.gbHeatMap.Name = "gbHeatMap";
            this.gbHeatMap.Size = new System.Drawing.Size(394, 78);
            this.gbHeatMap.TabIndex = 83;
            this.gbHeatMap.TabStop = false;
            this.gbHeatMap.Text = "HeatMaps";
            // 
            // sbHMAxesDivisionFactor
            // 
            this.sbHMAxesDivisionFactor.Location = new System.Drawing.Point(252, 23);
            this.sbHMAxesDivisionFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbHMAxesDivisionFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbHMAxesDivisionFactor.Name = "sbHMAxesDivisionFactor";
            this.sbHMAxesDivisionFactor.Size = new System.Drawing.Size(41, 20);
            this.sbHMAxesDivisionFactor.TabIndex = 56;
            this.sbHMAxesDivisionFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbHMAxesDivisionFactor.ValueChanged += new System.EventHandler(this.sbHMAxesDivisionFactor_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(5, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(318, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Generate HeatMap diagrams with axes divided into                parts";
            // 
            // sbPointsInRegion
            // 
            this.sbPointsInRegion.Location = new System.Drawing.Point(68, 43);
            this.sbPointsInRegion.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbPointsInRegion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbPointsInRegion.Name = "sbPointsInRegion";
            this.sbPointsInRegion.Size = new System.Drawing.Size(37, 20);
            this.sbPointsInRegion.TabIndex = 53;
            this.sbPointsInRegion.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbPointsInRegion.ValueChanged += new System.EventHandler(this.sbPointsInRegion_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(5, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Run at least              test cases in each region for creating the HeatMap";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chlbRequirements);
            this.groupBox2.Location = new System.Drawing.Point(398, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 599);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Requirements";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Test These Requirements";
            // 
            // chlbRequirements
            // 
            this.chlbRequirements.CheckOnClick = true;
            this.chlbRequirements.FormattingEnabled = true;
            this.chlbRequirements.Location = new System.Drawing.Point(5, 43);
            this.chlbRequirements.Name = "chlbRequirements";
            this.chlbRequirements.Size = new System.Drawing.Size(142, 544);
            this.chlbRequirements.TabIndex = 0;
            this.chlbRequirements.SelectedIndexChanged += new System.EventHandler(this.chlbRequirements_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gbWorstTestCases);
            this.groupBox4.Controls.Add(this.sbWorstTestCasesNumber);
            this.groupBox4.Controls.Add(this.cbReportWostCases);
            this.groupBox4.Location = new System.Drawing.Point(2, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(394, 521);
            this.groupBox4.TabIndex = 84;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Worst Test Cases";
            // 
            // gbWorstTestCases
            // 
            this.gbWorstTestCases.Controls.Add(this.panel1);
            this.gbWorstTestCases.Controls.Add(this.HeatMapPanel);
            this.gbWorstTestCases.Controls.Add(this.lblGuideHeatMap);
            this.gbWorstTestCases.Controls.Add(this.rbIncludeRegions);
            this.gbWorstTestCases.Controls.Add(this.label1);
            this.gbWorstTestCases.Controls.Add(this.rbExcludeRegions);
            this.gbWorstTestCases.Enabled = false;
            this.gbWorstTestCases.Location = new System.Drawing.Point(5, 35);
            this.gbWorstTestCases.Name = "gbWorstTestCases";
            this.gbWorstTestCases.Size = new System.Drawing.Size(386, 480);
            this.gbWorstTestCases.TabIndex = 59;
            this.gbWorstTestCases.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbUnionSliders);
            this.panel1.Controls.Add(this.rbIntersectionSliders);
            this.panel1.Location = new System.Drawing.Point(30, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 25);
            this.panel1.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(235, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "of the sliders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Select regions in the";
            // 
            // rbUnionSliders
            // 
            this.rbUnionSliders.AutoSize = true;
            this.rbUnionSliders.Location = new System.Drawing.Point(109, 4);
            this.rbUnionSliders.Name = "rbUnionSliders";
            this.rbUnionSliders.Size = new System.Drawing.Size(53, 17);
            this.rbUnionSliders.TabIndex = 1;
            this.rbUnionSliders.TabStop = true;
            this.rbUnionSliders.Text = "Union";
            this.rbUnionSliders.UseVisualStyleBackColor = true;
            // 
            // rbIntersectionSliders
            // 
            this.rbIntersectionSliders.AutoSize = true;
            this.rbIntersectionSliders.Location = new System.Drawing.Point(163, 4);
            this.rbIntersectionSliders.Name = "rbIntersectionSliders";
            this.rbIntersectionSliders.Size = new System.Drawing.Size(74, 17);
            this.rbIntersectionSliders.TabIndex = 0;
            this.rbIntersectionSliders.TabStop = true;
            this.rbIntersectionSliders.Text = "Intersction";
            this.rbIntersectionSliders.UseVisualStyleBackColor = true;
            this.rbIntersectionSliders.CheckedChanged += new System.EventHandler(this.rbIntersectionSliders_CheckedChanged);
            // 
            // HeatMapPanel
            // 
            this.HeatMapPanel.BackColor = System.Drawing.Color.White;
            this.HeatMapPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeatMapPanel.Location = new System.Drawing.Point(56, 109);
            this.HeatMapPanel.Name = "HeatMapPanel";
            this.HeatMapPanel.Size = new System.Drawing.Size(320, 320);
            this.HeatMapPanel.TabIndex = 3;
            // 
            // lblGuideHeatMap
            // 
            this.lblGuideHeatMap.AutoSize = true;
            this.lblGuideHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGuideHeatMap.Location = new System.Drawing.Point(21, 50);
            this.lblGuideHeatMap.Name = "lblGuideHeatMap";
            this.lblGuideHeatMap.Size = new System.Drawing.Size(274, 13);
            this.lblGuideHeatMap.TabIndex = 65;
            this.lblGuideHeatMap.Text = "Click on a region to include/exclude it in/from the search";
            // 
            // rbIncludeRegions
            // 
            this.rbIncludeRegions.AutoSize = true;
            this.rbIncludeRegions.Location = new System.Drawing.Point(5, 30);
            this.rbIncludeRegions.Name = "rbIncludeRegions";
            this.rbIncludeRegions.Size = new System.Drawing.Size(319, 17);
            this.rbIncludeRegions.TabIndex = 1;
            this.rbIncludeRegions.Text = "Only include the selected regions in the worst test case search";
            this.rbIncludeRegions.UseVisualStyleBackColor = true;
            this.rbIncludeRegions.CheckedChanged += new System.EventHandler(this.rbIncludeRegions_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(21, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Use sliders to include/exclude more than one region in the search";
            // 
            // rbExcludeRegions
            // 
            this.rbExcludeRegions.AutoSize = true;
            this.rbExcludeRegions.Checked = true;
            this.rbExcludeRegions.Location = new System.Drawing.Point(5, 10);
            this.rbExcludeRegions.Name = "rbExcludeRegions";
            this.rbExcludeRegions.Size = new System.Drawing.Size(311, 17);
            this.rbExcludeRegions.TabIndex = 0;
            this.rbExcludeRegions.TabStop = true;
            this.rbExcludeRegions.Text = "Exclude the selected regions from the worst test case search";
            this.rbExcludeRegions.UseVisualStyleBackColor = true;
            this.rbExcludeRegions.CheckedChanged += new System.EventHandler(this.rbIgnoreRegions_CheckedChanged);
            // 
            // sbWorstTestCasesNumber
            // 
            this.sbWorstTestCasesNumber.Location = new System.Drawing.Point(189, 17);
            this.sbWorstTestCasesNumber.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbWorstTestCasesNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbWorstTestCasesNumber.Name = "sbWorstTestCasesNumber";
            this.sbWorstTestCasesNumber.Size = new System.Drawing.Size(38, 20);
            this.sbWorstTestCasesNumber.TabIndex = 57;
            this.sbWorstTestCasesNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.sbWorstTestCasesNumber.ValueChanged += new System.EventHandler(this.sbWorstTestCasesNumber_ValueChanged);
            // 
            // cbReportWostCases
            // 
            this.cbReportWostCases.AutoSize = true;
            this.cbReportWostCases.Location = new System.Drawing.Point(5, 19);
            this.cbReportWostCases.Name = "cbReportWostCases";
            this.cbReportWostCases.Size = new System.Drawing.Size(325, 17);
            this.cbReportWostCases.TabIndex = 58;
            this.cbReportWostCases.Text = "Report worst test cases within the                most critical regions";
            this.cbReportWostCases.UseVisualStyleBackColor = true;
            this.cbReportWostCases.CheckedChanged += new System.EventHandler(this.cbReportWostCases_CheckedChanged);
            // 
            // ParentCCSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(552, 606);
            this.Controls.Add(this.gbHeatMap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "ParentCCSettingsForm";
            this.gbHeatMap.ResumeLayout(false);
            this.gbHeatMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbHMAxesDivisionFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbPointsInRegion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbWorstTestCases.ResumeLayout(false);
            this.gbWorstTestCases.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbWorstTestCasesNumber)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadCCSettings(CCSettings ccSettings)
        {
            for (int i = 0; i < ccSettings.Requirements.Count; ++i)
                chlbRequirements.Items.Add(ccSettings.Requirements.ElementAt(i).Key,
                    ccSettings.Requirements.ElementAt(i).Value);

            sbHMAxesDivisionFactor.Minimum = CCSettings.MinHMDivisionFactor;
            sbHMAxesDivisionFactor.Maximum = CCSettings.MaxHMDivisionFactor;
            sbHMAxesDivisionFactor.Value = ccSettings.heatMapDiagramDivisionFactor;

            sbPointsInRegion.Minimum = CCSettings.MinPointsInEachRegion;
            sbPointsInRegion.Maximum = CCSettings.MaxPointsInEachRegion;
            sbPointsInRegion.Value = ccSettings.numberOfPointsInEachRegion;


            cbReportWostCases.Checked = ccSettings.reportWorstTestCases;

            sbWorstTestCasesNumber.Minimum = CCSettings.MinWorstTestCases;
            sbWorstTestCasesNumber.Maximum = sbHMAxesDivisionFactor.Value * sbHMAxesDivisionFactor.Value;
            sbWorstTestCasesNumber.Value = ccSettings.numberOfWorstTestCases;

            rbExcludeRegions.Checked = !ccSettings.includeOrExcludeRegions;
            rbIncludeRegions.Checked = ccSettings.includeOrExcludeRegions;

            rbIntersectionSliders.Checked = !ccSettings.unionOrIntersectionOfRegions;
            rbUnionSliders.Checked = ccSettings.unionOrIntersectionOfRegions;
            
            for (int i = 0; i < ccSettings.heatMapDiagramDivisionFactor; ++i)
                for (int j=0;j<ccSettings.heatMapDiagramDivisionFactor;++j)
                {
                    if (ccSettings.normalOrIncludedExcludedRegion[i][j])
                        HeatMapLayout.ChangeLayoutRegionToNormal(i,j);
                    else
                        HeatMapLayout.ChangeLayoutRegionToIncludeorExlcude(i,j);
                }
            CreateAndShowHeatMapSliders(ccSettings.heatMapDiagramDivisionFactor,
                ccSettings.includeOrExcludeRegions);
            if(showLabels)
                CreateAndShowLabels(labels, HeatMapPanel, ccSettings.heatMapDiagramDivisionFactor, 
                    desiredValueStart, desiredValueEnd, gbWorstTestCases);
            ChangeInReportWorstCases(ccSettings.reportWorstTestCases);
            ChangeInIncludeorExcludeRegions(ccSettings.includeOrExcludeRegions);
            for (int i = 0; i < ccSettings.heatMapDiagramDivisionFactor; ++i)
                for (int j = 0; j < ccSettings.heatMapDiagramDivisionFactor; ++j)
                {
                    if (ccSettings.normalOrIncludedExcludedRegion[i][j])
                        HeatMapLayout.ChangeLayoutRegionToNormal(i, j);
                    else
                        HeatMapLayout.ChangeLayoutRegionToIncludeorExlcude(i, j);
                }
        }
        public void CreateLabelsWithNewRanges(float from, float to)
        {
            desiredValueStart = from;
            desiredValueEnd = to;
            CreateAndShowLabels(labels, HeatMapPanel, (int)sbHMAxesDivisionFactor.Value, 
                desiredValueStart, desiredValueEnd, gbWorstTestCases);
        }

        public CCSettings ReadCCSettings()
        {
            CCSettings ccSettings = new CCSettings(false);

            for (int i = 0; i < chlbRequirements.Items.Count; ++i)
                ccSettings.Requirements[chlbRequirements.Items[i].ToString()] = (chlbRequirements.GetItemChecked(i));

            ccSettings.heatMapDiagramDivisionFactor = (int)sbHMAxesDivisionFactor.Value;

            ccSettings.numberOfPointsInEachRegion = (int)sbPointsInRegion.Value;


            ccSettings.reportWorstTestCases = cbReportWostCases.Checked;

            ccSettings.numberOfWorstTestCases = (int)sbWorstTestCasesNumber.Value;

            ccSettings.includeOrExcludeRegions = rbIncludeRegions.Checked;

            ccSettings.unionOrIntersectionOfRegions = rbUnionSliders.Checked;

            for (int i = 0; i < ccSettings.heatMapDiagramDivisionFactor; ++i)
                for (int j = 0; j < ccSettings.heatMapDiagramDivisionFactor; ++j)
                    ccSettings.normalOrIncludedExcludedRegion[i][j]=
                        HeatMapLayout.GetLayoutRegionNormalOrIncludeExcluded(i,j);
            return ccSettings;
        }

        private void modifySliderColors(bool IncludeOrExclude)
        {
            Color FirstColor, SecondColor;
            if (IncludeOrExclude)
            {
                FirstColor = Color.Red;
                SecondColor = Color.Green;
            }
            else
            {
                FirstColor = Color.Green;
                SecondColor = Color.Red;
            }

            horizontalUp.ElapsedInnerColor = horizontalUp.ElapsedOuterColor = FirstColor;
            horizontalUp.BarInnerColor = horizontalUp.BarOuterColor = SecondColor;
            horizontalDown.ElapsedInnerColor = horizontalDown.ElapsedOuterColor = SecondColor;
            horizontalDown.BarInnerColor = horizontalDown.BarOuterColor = FirstColor;

            verticalRight.ElapsedInnerColor = verticalRight.ElapsedOuterColor = SecondColor;
            verticalRight.BarInnerColor = verticalRight.BarOuterColor = FirstColor;
            verticalLeft.ElapsedInnerColor = verticalLeft.ElapsedOuterColor = FirstColor;
            verticalLeft.BarInnerColor = verticalLeft.BarOuterColor = SecondColor;
        }

        public static void CreateAndShowLabels(List<Label> labels, Panel heatMapPanel,
            int HMAxesDivisionFactor, float initialValue,float finalValue,GroupBox heatMapPanlGroupBox)
        {
            foreach (Label label in labels)
                label.Hide();
            labels.Clear();
            int heatMapPanelWidth = (heatMapPanel.Size.Width / HMAxesDivisionFactor) * HMAxesDivisionFactor;
            int heatMapPanelHeight = (heatMapPanel.Size.Height / HMAxesDivisionFactor) * HMAxesDivisionFactor;
            for (int i=0;i<=HMAxesDivisionFactor;++i)
            {
                float value = ((finalValue - initialValue) / HMAxesDivisionFactor) * i + initialValue;
                value = (float)Math.Round(value, 2);
                Point StartLocation = new Point(heatMapPanel.Location.X +
                    (heatMapPanelWidth / HMAxesDivisionFactor) * i - (i!=0?11:4),
                    heatMapPanel.Location.Y + heatMapPanelHeight + 3);
                labels.Add(CreateLabel(heatMapPanlGroupBox,StartLocation, value,true));
                StartLocation = new Point(heatMapPanel.Location.X - 19,
                    heatMapPanel.Location.Y + heatMapPanelHeight -
                    (heatMapPanelHeight / HMAxesDivisionFactor) * i - (i!=0?7:9));
                labels.Add(CreateLabel(heatMapPanlGroupBox,StartLocation, value,false));
            }
        }

        private void CreateAndShowHeatMapSliders(int HMAxesDivisionFactor, bool includeOrExclude)
        {
            Point StartLocation;
            if (horizontalUp != null)
                horizontalUp.Hide();
            StartLocation = new Point(HeatMapPanel.Location.X, HeatMapPanel.Location.Y +
                HeatMapPanel.Size.Height + 18);
            horizontalUp = CreateSlider(Orientation.Horizontal, HMAxesDivisionFactor, StartLocation);
            horizontalUp.Value = (horizontalUp.Maximum + 1) / 2 + 1;
            horizontalUp.OnUsefullValueChange += OnHorizontalUpValueChange;

            if (horizontalDown != null)
                horizontalDown.Hide();
            StartLocation = new Point(horizontalUp.Location.X + HeatMapPanel.Size.Width / (HMAxesDivisionFactor), 
                horizontalUp.Location.Y + horizontalUp.Size.Height );
            horizontalDown = CreateSlider(Orientation.Horizontal, HMAxesDivisionFactor, StartLocation);
            horizontalDown.Value = (horizontalDown.Maximum + 1) / 2;
            horizontalDown.OnUsefullValueChange += OnHorizontalDownValueChange;


            if (verticalRight != null)
                verticalRight.Hide();
            StartLocation = new Point(HeatMapPanel.Location.X - CustomizedSlider.colorSliderWidth - 20, 
                HeatMapPanel.Location.Y + HeatMapPanel.Size.Height / HMAxesDivisionFactor);
            verticalRight = CreateSlider(Orientation.Vertical, HMAxesDivisionFactor, StartLocation);
            verticalRight.Value = (verticalRight.Maximum + 1) / 2;
            verticalRight.OnUsefullValueChange += OnVerticalRightValueChange;

            if (verticalLeft != null)
                verticalLeft.Hide();
            StartLocation = new Point(verticalRight.Location.X - CustomizedSlider.colorSliderWidth , HeatMapPanel.Location.Y);
            verticalLeft = CreateSlider(Orientation.Vertical, HMAxesDivisionFactor, StartLocation);
            verticalLeft.Value = (verticalLeft.Maximum + 1) / 2 + 1;
            verticalLeft.OnUsefullValueChange += OnVerticaltLeftValueChange;

            modifySliderColors(includeOrExclude);
        }

        private static Label CreateLabel(GroupBox heatMapPanelGroupbox,Point Location,float value,bool HorOrVert)
        {
            RotatbleLabel regionLabel = new RotatbleLabel();
            regionLabel.Parent = heatMapPanelGroupbox;
            regionLabel.Location = Location;
            string valueString = value.ToString();
            regionLabel.Font = new Font(regionLabel.Font.Name, (float)8);
            Size newTextSize = TextRenderer.MeasureText(valueString, regionLabel.Font);
            if(HorOrVert)
                newTextSize = new Size(newTextSize.Width + 1, newTextSize.Height + 1);
            else
                newTextSize = new Size(newTextSize.Height + 5, newTextSize.Width + 1);
            regionLabel.Size = newTextSize;
            if (HorOrVert)
                regionLabel.Text = valueString;
            else
                regionLabel.NewText = valueString;
            regionLabel.Show();
            if (!HorOrVert)
                regionLabel.RotateAngle = 90;
            regionLabel.BringToFront();
            return regionLabel;
        }

        private CustomizedSlider CreateSlider(Orientation orientation, int StepsNo,
            Point Location)
        {
            CustomizedSlider colorSlider = new CustomizedSlider();
            colorSlider.Parent = gbWorstTestCases;
            colorSlider.Orientation = orientation;
            if (orientation == Orientation.Horizontal)
                colorSlider.Size = new Size(HeatMapPanel.Size.Width - HeatMapPanel.Size.Width / (StepsNo),
                    CustomizedSlider.colorSliderWidth);
            else
                colorSlider.Size = new Size(CustomizedSlider.colorSliderWidth,
                    HeatMapPanel.Size.Height - HeatMapPanel.Size.Height / (StepsNo));
            colorSlider.Minimum = 1;
            colorSlider.Location = Location;
            colorSlider.Maximum = StepsNo;
            colorSlider.ThumbInnerColor = colorSlider.ThumbOuterColor = Color.White;
            colorSlider.Show();

            return colorSlider;
        }

        private void OnVerticaltLeftValueChange(UsefulValueChangeArgs args)
        {
            int rangeXStart, rangeXEnd;
            int rangeYStart, rangeYEnd;

            rangeXStart = horizontalUp.Value;
            rangeXEnd = horizontalDown.Value + 1;
            if (args.CurrentValue > (verticalRight.Value + 1))
            {
                verticalRight.OnUsefullValueChange -= OnVerticalRightValueChange;
                verticalRight.Value = args.CurrentValue - 1;
                verticalRight.OnUsefullValueChange += OnVerticalRightValueChange;
            }
            rangeYEnd = verticalRight.Value + 1;

            if (args.CurrentValue > args.PreviousValue)
            {
                if (args.PreviousValue > rangeYEnd)
                    return;
                rangeYStart = args.PreviousValue;
                rangeYEnd = Math.Min(args.CurrentValue, rangeYEnd);
                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToNormal(1, (int)sbHMAxesDivisionFactor.Value + 1, rangeYStart, rangeYEnd);
                else
                    HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
            else
            {
                if (args.CurrentValue > rangeYEnd)
                    return;
                rangeYStart = args.CurrentValue;
                rangeYEnd = Math.Min(args.PreviousValue, rangeYEnd);
                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(1, (int)sbHMAxesDivisionFactor.Value + 1, rangeYStart, rangeYEnd);
                else
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
        }

        private void OnVerticalRightValueChange(UsefulValueChangeArgs args)
        {
            int rangeXStart, rangeXEnd;
            int rangeYStart, rangeYEnd;

            rangeXStart = horizontalUp.Value;
            rangeXEnd = horizontalDown.Value + 1;
            if (args.CurrentValue < (verticalLeft.Value - 1))
            {
                verticalLeft.OnUsefullValueChange -= OnVerticaltLeftValueChange;
                verticalLeft.Value = args.CurrentValue + 1;
                verticalLeft.OnUsefullValueChange += OnVerticaltLeftValueChange;
            }
            rangeYStart = verticalLeft.Value;

            if (args.CurrentValue < args.PreviousValue)
            {
                if ((args.PreviousValue + 1) < rangeYStart)
                    return;
                rangeYStart = Math.Max(args.CurrentValue + 1, rangeYStart);
                rangeYEnd = args.PreviousValue + 1;
                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToNormal(1, (int)sbHMAxesDivisionFactor.Value + 1, rangeYStart, rangeYEnd);
                else
                    HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
            else
            {
                if ((args.CurrentValue + 1) < rangeYStart)
                    return;
                rangeYStart = Math.Max(args.PreviousValue + 1, rangeYStart);
                rangeYEnd = args.CurrentValue + 1;
                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(1, (int)sbHMAxesDivisionFactor.Value + 1, rangeYStart, rangeYEnd);
                else
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
        }

        private void OnHorizontalUpValueChange(UsefulValueChangeArgs args)
        {
            int rangeXStart, rangeXEnd;
            int rangeYStart, rangeYEnd;

            rangeYStart = verticalLeft.Value;
            rangeYEnd = verticalRight.Value + 1;
            if (args.CurrentValue > (horizontalDown.Value + 1))
            {
                horizontalDown.OnUsefullValueChange -= OnHorizontalDownValueChange;
                horizontalDown.Value = args.CurrentValue - 1;
                horizontalDown.OnUsefullValueChange += OnHorizontalDownValueChange;
            }
            rangeXEnd = horizontalDown.Value + 1;

            if (args.CurrentValue > args.PreviousValue)
            {
                if (args.PreviousValue > rangeXEnd)
                    return;
                rangeXStart = args.PreviousValue;
                rangeXEnd = Math.Min(args.CurrentValue, rangeXEnd);
                if(rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, 1, (int)sbHMAxesDivisionFactor.Value + 1);
                else
                    HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
            else
            {
                if (args.CurrentValue > rangeXEnd)
                    return;
                rangeXStart = args.CurrentValue;
                rangeXEnd = Math.Min(args.PreviousValue, rangeXEnd);
                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, 1, (int)sbHMAxesDivisionFactor.Value + 1);
                else
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
        }

        private void OnHorizontalDownValueChange(UsefulValueChangeArgs args)
        {
            int rangeXStart, rangeXEnd;
            int rangeYStart, rangeYEnd;

            rangeYStart = verticalLeft.Value;
            rangeYEnd = verticalRight.Value + 1;
            if (args.CurrentValue < (horizontalUp.Value - 1))
            {
                horizontalUp.OnUsefullValueChange -= OnHorizontalUpValueChange;
                horizontalUp.Value = args.CurrentValue + 1;
                horizontalUp.OnUsefullValueChange += OnHorizontalUpValueChange;
            }
            rangeXStart = horizontalUp.Value;

            if (args.CurrentValue < args.PreviousValue)
            {
                if ((args.PreviousValue + 1) < rangeXStart)
                    return;
                rangeXStart = Math.Max(args.CurrentValue + 1, rangeXStart);
                rangeXEnd = args.PreviousValue + 1;
                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, 1, (int)sbHMAxesDivisionFactor.Value + 1);
                else
                    HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
            else
            {
                if ((args.CurrentValue + 1) < rangeXStart)
                    return;
                rangeXStart = Math.Max(args.PreviousValue + 1, rangeXStart);
                rangeXEnd = args.CurrentValue + 1;

                if (rbUnionSliders.Checked)
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, 1, (int)sbHMAxesDivisionFactor.Value + 1);
                else
                    HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
        }

        private void sbHMAxesDivisionFactor_ValueChanged(object sender, EventArgs e)
        {
            HeatMapLayout.CreateHeatMapLayoutDiagram(HeatMapPanel,
                (int)sbHMAxesDivisionFactor.Value, rbIncludeRegions.Checked);
            CreateAndShowHeatMapSliders((int)sbHMAxesDivisionFactor.Value, rbIncludeRegions.Checked);
            if (showLabels)
                CreateAndShowLabels(labels,HeatMapPanel,(int)sbHMAxesDivisionFactor.Value, 
                    desiredValueStart, desiredValueEnd, gbWorstTestCases);
            sbWorstTestCasesNumber.Maximum = sbHMAxesDivisionFactor.Value * sbHMAxesDivisionFactor.Value;
            ccSettingsChnageListener.SettingsChanged();
        }

        private void cbReportWostCases_CheckedChanged(object sender, EventArgs e)
        {
            ChangeInReportWorstCases(cbReportWostCases.Checked);
            ccSettingsChnageListener.SettingsChanged();
        }

        private void ChangeInReportWorstCases(bool reportWorstCases)
        {
            sbWorstTestCasesNumber.Enabled = reportWorstCases;
            gbWorstTestCases.Enabled = reportWorstCases;
        }

        private void rbIgnoreRegions_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExcludeRegions.Checked)
                ChangeInIncludeorExcludeRegions(false);
        }

        private void rbIncludeRegions_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncludeRegions.Checked)
                ChangeInIncludeorExcludeRegions(true);
        }

        private void ChangeInIncludeorExcludeRegions(bool includeOrExclude)
        {
            HeatMapLayout.SetIncludeOrExcludeLayoutRegions(includeOrExclude);
            modifySliderColors(includeOrExclude);
        }

        private void chlbRequirements_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccSettingsChnageListener.SettingsChanged();
        }

        private void sbPointsInRegion_ValueChanged(object sender, EventArgs e)
        {
            ccSettingsChnageListener.SettingsChanged();
        }


        private void sbWorstTestCasesNumber_ValueChanged(object sender, EventArgs e)
        {
            ccSettingsChnageListener.SettingsChanged();
        }

        private List<Label> labels = new List<Label>();
        private CustomizedSlider horizontalUp = null, horizontalDown = null;
        private CustomizedSlider verticalRight = null, verticalLeft = null;

        private void rbIntersectionSliders_CheckedChanged(object sender, EventArgs e)
        {
            int rangeXStart, rangeXEnd;
            int rangeYStart, rangeYEnd;

            rangeXStart = horizontalUp.Value;
            rangeXEnd = horizontalDown.Value + 1;

            rangeYStart = verticalLeft.Value;
            rangeYEnd = verticalRight.Value + 1;
            
            if (rbUnionSliders.Checked)
            {
                HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(1, (int)sbHMAxesDivisionFactor.Value + 1, rangeYStart, rangeYEnd);
                HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, 1, (int)sbHMAxesDivisionFactor.Value + 1);
            }
            else
            {
                HeatMapLayout.ChangeLayoutRegionsToNormal(1, (int)sbHMAxesDivisionFactor.Value + 1, rangeYStart, rangeYEnd);
                HeatMapLayout.ChangeLayoutRegionsToNormal(rangeXStart, rangeXEnd, 1, (int)sbHMAxesDivisionFactor.Value + 1);
                HeatMapLayout.ChangeLayoutRegionsToIncludeorExlcude(rangeXStart, rangeXEnd, rangeYStart, rangeYEnd);
            }
        }
        
        private GroupBox gbHeatMap;
        private NumericUpDown sbHMAxesDivisionFactor;
        private Label label6;
        private NumericUpDown sbPointsInRegion;
        private Label label5;
        private GroupBox groupBox2;
        private Label label4;
        private CheckedListBox chlbRequirements;
        private GroupBox groupBox4;
        private GroupBox gbWorstTestCases;
        private Panel HeatMapPanel;
        private RadioButton rbIncludeRegions;
        private RadioButton rbExcludeRegions;
        private NumericUpDown sbWorstTestCasesNumber;
        private CheckBox cbReportWostCases;
        private ICCSettingsChangeListener ccSettingsChnageListener;
        private bool showLabels;
        private float desiredValueStart;
        private float desiredValueEnd;
        private Label lblGuideHeatMap;
        private Label label1;
        private Panel panel1;
        private RadioButton rbUnionSliders;
        private RadioButton rbIntersectionSliders;
        private Label label2;
        private Label label3;

    }
}
