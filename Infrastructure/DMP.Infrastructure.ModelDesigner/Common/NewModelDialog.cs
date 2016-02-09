
using System.Windows.Forms;
using DMP.Infrastructure.Common.Model;

namespace DMP.Infrastructure.ModelDesigner.Common
{

    #region 窗体设计
    partial class NewModelDialog : BaseForm
    {


        private System.Windows.Forms.TextBox txtSourceTag;
        private System.Windows.Forms.TextBox txtDocumentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceTag = new System.Windows.Forms.TextBox();
            this.txtDocumentType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SourceTag：";
            // 
            // txtSourceTag
            // 
            this.txtSourceTag.Location = new System.Drawing.Point(114, 52);
            this.txtSourceTag.Name = "txtSourceTag";
            this.txtSourceTag.Size = new System.Drawing.Size(190, 21);
            this.txtSourceTag.TabIndex = 1;
            // 
            // txtDocumentType
            // 
            this.txtDocumentType.Location = new System.Drawing.Point(114, 79);
            this.txtDocumentType.Name = "txtDocumentType";
            this.txtDocumentType.Size = new System.Drawing.Size(190, 21);
            this.txtDocumentType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "DocumentType：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(245, 169);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(114, 106);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 21);
            this.txtName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name：";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(114, 133);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(190, 21);
            this.txtDisplayName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "DisplayName：";
            // 
            // NewModelDialog
            // 
            this.ClientSize = new System.Drawing.Size(332, 240);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDocumentType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSourceTag);
            this.Controls.Add(this.label1);
            this.Name = "NewModelDialog";
            this.Load += new System.EventHandler(this.NewModelDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
    #endregion

    partial class NewModelDialog
    {
        public EnumValue.ModelType NewModelType { get; set; }

        public ModelBase Model { get; set; }

        public NewModelDialog()
        {
            InitializeComponent();
        }

        private void NewModelDialog_Load(object sender, System.EventArgs e)
        {
            if (NewModelType == EnumValue.ModelType.Business)
            {
                Text = "新建-业务模型";
            }
            else
            {
                Text = "新建-报表模型";
            }
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

            if (NewModelType == EnumValue.ModelType.Report)
            {
                Model = new ReportModel();
            }
            else
            {
                Model = new BusinessModel();
            }
            Model.Name = txtName.Text;
            Model.DisplayName = txtDisplayName.Text;
            Model.SourceTag = int.Parse(txtSourceTag.Text);
            Model.DocumentType = int.Parse(txtDocumentType.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
