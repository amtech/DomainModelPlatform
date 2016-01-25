using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DMP.Infrastructure.ModelDesigner.Common
{
    public partial class NewProjectDialog : BaseForm
    {
        public string Folder { get { return txtFolder.Text; } }

        public string ProjectName { get { return txtName.Text; } }

        public string DisplayName { get { return txtDisplayName.Text; } }

        public NewProjectDialog()
        {
            InitializeComponent();
            txtFolder.Text = AppDomain.CurrentDomain.BaseDirectory;
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            txtFolder.Text = Utils.SelectFolder();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
