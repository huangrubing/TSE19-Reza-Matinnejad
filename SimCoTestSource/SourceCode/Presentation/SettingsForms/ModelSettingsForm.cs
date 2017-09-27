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
    public partial class ModelSettingsForm : Form
    {
        public ModelSettingsForm()
        {
            InitializeComponent();
            ModelSettings modelSettings;
            if (SettingFilesManager.modelSettingsExists(SettingFilesManager.SettingsFolderPath))
                modelSettings = SettingFilesManager.LoadModelSettings(SettingFilesManager.SettingsFolderPath);
            else
                modelSettings= new ModelSettings();
            parentModelSettingsForm = new ParentModelSettingsForm(
                modelSettings);
            this.Controls.Add(parentModelSettingsForm);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!parentModelSettingsForm.CheckModelSettings())
                return;
            ModelSettings modelSettings=parentModelSettingsForm.ReadModelSettings();            
            SettingFilesManager.SaveModelSettings(SettingFilesManager.SettingsFolderPath,modelSettings);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        ParentModelSettingsForm parentModelSettingsForm;
    }
}
