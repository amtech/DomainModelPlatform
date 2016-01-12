using System.IO;
using System.Windows.Forms;

namespace ModelDesigner.Common
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            ShowIcon = false;
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

    }
}
