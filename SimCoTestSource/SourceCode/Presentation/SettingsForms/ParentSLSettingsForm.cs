using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    class ParentSLSettingsForm : Panel
    {
        private Label label2;

        public ParentSLSettingsForm(ISBSettingsChangeListener sbSettingsChnageListener)
        {
            InitializeComponent();
            this.sbSettingsChnageListener = sbSettingsChnageListener;
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.slODBudget = new System.Windows.Forms.NumericUpDown();
            this.slOSBudget = new System.Windows.Forms.NumericUpDown();
            this.slOCBudget = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slODBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slOSBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slOCBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Output Diversity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Output Stability:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Output Continuity:";
            // 
            // sbODBudget
            // 
            this.slODBudget.Location = new System.Drawing.Point(101, 45);
            this.slODBudget.Name = "sbODBudget";
            this.slODBudget.Size = new System.Drawing.Size(37, 20);
            this.slODBudget.TabIndex = 72;
            this.slODBudget.ValueChanged += new System.EventHandler(this.sbODBudget_ValueChanged);
            // 
            // sbOSBudget
            // 
            this.slOSBudget.Location = new System.Drawing.Point(101, 75);
            this.slOSBudget.Name = "sbOSBudget";
            this.slOSBudget.Size = new System.Drawing.Size(37, 20);
            this.slOSBudget.TabIndex = 73;
            this.slOSBudget.ValueChanged += new System.EventHandler(this.sbOSBudget_ValueChanged);
            // 
            // sbOCBudget
            // 
            this.slOCBudget.Location = new System.Drawing.Point(101, 104);
            this.slOCBudget.Name = "sbOCBudget";
            this.slOCBudget.Size = new System.Drawing.Size(37, 20);
            this.slOCBudget.TabIndex = 74;
            this.slOCBudget.ValueChanged += new System.EventHandler(this.sbOCBudget_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Test Cases";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Test Cases";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Test Cases";
            // 
            // ParentSBSettingsForm
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.slOCBudget);
            this.Controls.Add(this.slOSBudget);
            this.Controls.Add(this.slODBudget);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Size = new System.Drawing.Size(256, 150);
            ((System.ComponentModel.ISupportInitialize)(this.slODBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slOSBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slOCBudget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void LoadSLSettings(SLSettings sbSettings)
        {
            slODBudget.Value = sbSettings.Criteria["Diversity"];
            slOSBudget.Value = sbSettings.Criteria["Stability"];
            slOCBudget.Value = sbSettings.Criteria["Continuity"];
        }

        public SLSettings ReadSLSettings()
        {
            SLSettings slSettings = new SLSettings(true);
            slSettings.Criteria["Diversity"] = (int)slODBudget.Value;
            slSettings.Criteria["Stability"] = (int)slOSBudget.Value;
            slSettings.Criteria["Continuity"] = (int)slOCBudget.Value;
            return slSettings;
        }

        private Label label1;
        private Label label3;
        private NumericUpDown slODBudget;
        private NumericUpDown slOSBudget;
        private NumericUpDown slOCBudget;
        private Label label4;
        private Label label5;
        private Label label6;
        private ISBSettingsChangeListener sbSettingsChnageListener;

        private void sbOCBudget_ValueChanged(object sender, EventArgs e)
        {
            sbSettingsChnageListener.SettingsChanged();
        }

        private void sbOSBudget_ValueChanged(object sender, EventArgs e)
        {
            sbSettingsChnageListener.SettingsChanged();
        }

        private void sbODBudget_ValueChanged(object sender, EventArgs e)
        {
            sbSettingsChnageListener.SettingsChanged();
        }
    }
}
