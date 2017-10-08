using Domain.ModelDesigner.Common;
using Infrastructure.WindowsForm;
using System; 
using System.Windows.Forms;

namespace Domain.ModelDesigner
{
    /// <summary>主界面</summary>
    public partial class Main : BaseForm
    {
        public Main()
        {
            InitializeComponent();
            SetStatus(string.Empty); 
        }

        /// <summary>提供给子窗体调用</summary>
        /// <param name="msg"></param>
        public void SetStatus(string msg)
        {
            lblCurrentState.Text = msg;
        }

        /// <summary>打开文件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenFile_Click(object sender, EventArgs e)
        {
        }

        /// <summary>新建文件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewFile_Click(object sender, EventArgs e)
        {

        }

        /// <summary>顶部菜单-项添加事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuTop_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0)
            {
                e.Item.Visible = false;
            }
        }

        /// <summary>新建项目</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewProject_Click(object sender, EventArgs e)
        {
            string prjPath = Utils.NewProject();
            if (!string.IsNullOrEmpty(prjPath))
            {
                DesignerTool designer = new DesignerTool
                {
                    ProjectFilePath = prjPath,
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                designer.Show();
            }
        }

        /// <summary>打开项目</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenProject_Click(object sender, EventArgs e)
        {
            string prjPath = Utils.OpenProject();
            if (!string.IsNullOrEmpty(prjPath))
            {
                DesignerTool designer = new DesignerTool
                {
                    ProjectFilePath = prjPath,
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                designer.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConfigHelper.OutFolder))
            {
                Alert("请选择输出路径");
                string outputFolder = Utils.SelectFolder();
                if (!string.IsNullOrEmpty(outputFolder))
                {
                    ConfigHelper.OutFolder = outputFolder;
                }
            }
        }
    }
}
