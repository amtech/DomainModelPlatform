using System.IO;
using System.Windows.Forms;

namespace DMP.Infrastructure.ModelDesigner.Common
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public string GetSaveXmlPath()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xml文件(*.xml)|";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return string.Empty;
        }

        public void SaveFile(string p_Text, string p_Path)
        {
            StreamWriter _StreamWriter = new StreamWriter(p_Path);
            _StreamWriter.Write(p_Text);
            _StreamWriter.Close();
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
