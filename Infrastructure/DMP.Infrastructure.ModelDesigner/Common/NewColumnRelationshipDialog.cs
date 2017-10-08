
using System.Windows.Forms;
using Infrastructure.WindowsForm;
using Domain.Model.Elements;


namespace Domain.ModelDesigner.Common
{
    public partial class NewColumnRelationshipDialog : BaseForm
    {
        public ColumnRelationship Relationship { get; set; }

        public NewColumnRelationshipDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            foreach (var ctrl in Controls)
            {
                if (ctrl is TextBox && string.IsNullOrEmpty((ctrl as TextBox).Text))
                {
                    Alert("所有栏位必填！");
                    return;
                }
            }
            Relationship = new ColumnRelationship
            {
                Name = txtName.Text,
                DisplayName = txtDisplayName.Text,
                SourceTag = int.Parse(txtSourceTag.Text),
                DocumentType = int.Parse(txtDocumentType.Text)
            };
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
