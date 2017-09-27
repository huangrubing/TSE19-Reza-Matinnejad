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
    public partial class SLSettingsForm : Form, ISBSettingsChangeListener
    {
        public SLSettingsForm()
        {
            InitializeComponent();
            SLSettings sbSettings;
            if (SettingFilesManager.SBSettingsExists(SettingFilesManager.SettingsFolderPath))
                sbSettings = SettingFilesManager.LoadSBSettings(SettingFilesManager.SettingsFolderPath);
            else
                sbSettings = new SLSettings(true);

            parentSBSettingsForm = new ParentSLSettingsForm(this);
            parentSBSettingsForm.LoadSLSettings(sbSettings);
            this.Controls.Add(parentSBSettingsForm);
        }

        public void SettingsChanged()
        {
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            SLSettings sbSettings = parentSBSettingsForm.ReadSLSettings();
            SettingFilesManager.SaveSBSettings(SettingFilesManager.SettingsFolderPath, sbSettings);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        ParentSLSettingsForm parentSBSettingsForm;
    }
}
