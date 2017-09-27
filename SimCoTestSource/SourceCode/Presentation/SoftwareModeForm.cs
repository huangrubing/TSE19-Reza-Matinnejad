using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Service;

namespace MiLTester.SourceCode.Presentation
{
    public partial class SoftwareModeForm : Form
    {
        public SoftwareModeForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SettingFilesManager.softwareRunningMode = (rbNormalMode.Checked) ? SoftwareModeEnum.NormalMode : SoftwareModeEnum.MaintenanceMode;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        
    }
}
