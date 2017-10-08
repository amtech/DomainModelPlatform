using DMP.Infrastructure.WindowsForm;
using System;
using System.Windows.Forms;

namespace Domain.ModelDesigner.Common
{
    public partial class NewProjectDialog : BaseForm
    {
        public string Folder { get { return txtFolder.Text; } }

        public string ProjectName { get { return txtName.Text; } }

        public string DisplayName { get { return txtDisplayName.Text; } }

        public NewProjectDialog()
        {
            InitializeComponent();
            txtFolder.Text = ConfigHelper.OutFolder;
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            txtFolder.Text = Utils.SelectFolder(txtFolder.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
