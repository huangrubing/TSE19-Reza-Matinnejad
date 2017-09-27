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
    public partial class CCSettingsForm : Form,ICCSettingsChangeListener
    {
        public CCSettingsForm()
        {

            InitializeComponent();
            CCSettings ccSettings;
            if (SettingFilesManager.CCSettingsExists(SettingFilesManager.SettingsFolderPath))
                ccSettings = SettingFilesManager.LoadCCSettings(SettingFilesManager.SettingsFolderPath);
            else
                ccSettings = new CCSettings(true);

            parentCCSettingsForm = new ParentCCSettingsForm(this);
            parentCCSettingsForm.LoadCCSettings(ccSettings);
            this.Controls.Add(parentCCSettingsForm);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CCSettings ccSettings = parentCCSettingsForm.ReadCCSettings();
            SettingFilesManager.SaveCCSettings(SettingFilesManager.SettingsFolderPath,ccSettings);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SettingsChanged()
        {
        }
        private ParentCCSettingsForm parentCCSettingsForm;
    }
}
