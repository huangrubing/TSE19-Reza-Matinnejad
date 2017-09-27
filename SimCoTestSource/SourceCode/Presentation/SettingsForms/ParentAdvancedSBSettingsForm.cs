using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    class ParentAdvancedSBSettingsForm : Panel
    {
        private TextBox tbCandidates;
        private Label label2;
    
        public ParentAdvancedSBSettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.tbCandidates = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Number of candidates:";
            // 
            // tbCandidates
            // 
            this.tbCandidates.Location = new System.Drawing.Point(145, 9);
            this.tbCandidates.Name = "tbCandidates";
            this.tbCandidates.Size = new System.Drawing.Size(132, 20);
            this.tbCandidates.TabIndex = 69;
            // 
            // ParentAdvancedSBSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(294, 51);
            this.Controls.Add(this.tbCandidates);
            this.Controls.Add(this.label2);
            this.Name = "ParentAdvancedSBSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void LoadAdvancedSBSettings(AdvancedSBSettings advancedSBSettings)
        {
            tbCandidates.Text = advancedSBSettings.candidates.ToString();
        }

        public AdvancedSBSettings ReadAdvancedSBSettings()
        {
            AdvancedSBSettings advancedSBSettings = new AdvancedSBSettings();
            advancedSBSettings.candidates = Int16.Parse(tbCandidates.Text);
            return advancedSBSettings;
        }

    }
}
