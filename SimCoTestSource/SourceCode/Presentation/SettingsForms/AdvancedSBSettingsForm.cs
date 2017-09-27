using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Bussiness.Settings;

namespace MiLTester.SourceCode.Presentation.SettingsForms
{
    public partial class AdvancedSBSettingsForm : Form
    {
        public AdvancedSBSettingsForm()
        {
            InitializeComponent();
            AdvancedSBSettings advancedSBSettings;
            if (SettingFilesManager.AdvancedSBSettingsExists(SettingFilesManager.SettingsFolderPath))
                advancedSBSettings = SettingFilesManager.LoadAdvancedSBSettings(
                    SettingFilesManager.SettingsFolderPath);
            else
                advancedSBSettings = new AdvancedSBSettings();

            parentAdvancedSBSettingsForm = new ParentAdvancedSBSettingsForm();
            parentAdvancedSBSettingsForm.LoadAdvancedSBSettings(advancedSBSettings);
            this.Controls.Add(parentAdvancedSBSettingsForm);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SettingFilesManager.SaveAdvancedSBSettings(
                SettingFilesManager.SettingsFolderPath,
                parentAdvancedSBSettingsForm.ReadAdvancedSBSettings());
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ParentAdvancedSBSettingsForm parentAdvancedSBSettingsForm;
    }
}
