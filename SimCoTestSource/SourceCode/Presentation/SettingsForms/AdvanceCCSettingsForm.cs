using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Service;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    public partial class AdvanceCCSettingsForm : Form
    {
        public AdvanceCCSettingsForm()
        {
            InitializeComponent();

            AdvancedCCSettings advancedCCSettings;
            if (SettingFilesManager.AdvancedCCSettingsExists(SettingFilesManager.SettingsFolderPath))
                advancedCCSettings = SettingFilesManager.LoadAdvancedCCSettings(
                    SettingFilesManager.SettingsFolderPath);
            else
                advancedCCSettings = new AdvancedCCSettings();

            parentAdvancedCCSettingsForm = new ParentAdvancedCCSettingsForm();
            parentAdvancedCCSettingsForm.LoadAdvancedCCSettings(advancedCCSettings);
            this.Controls.Add(parentAdvancedCCSettingsForm);
        }

        
        private void btnOk_Click(object sender, EventArgs e)
        {
            SettingFilesManager.SaveAdvancedCCSettings(
                SettingFilesManager.SettingsFolderPath, 
                parentAdvancedCCSettingsForm.ReadAdvancedCCSettings());            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ParentAdvancedCCSettingsForm parentAdvancedCCSettingsForm;
    }
}
