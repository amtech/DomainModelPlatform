using System.IO;
using System.Windows.Forms;

namespace DMP.Infrastructure.WindowsForm
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected void Alert(string msg)
        {
            MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected bool Confirm(string msg)
        {
            DialogResult dr = MessageBox.Show(msg, "请确认", MessageBoxButtons.OKCancel);
            return dr == DialogResult.OK;
        }

        /// <summary>检查模型文件是否存在</summary>
        /// <returns></returns>
        protected bool CheckModelFileExists(string name, bool isReport)
        {
            return false;
        }

    }
}
