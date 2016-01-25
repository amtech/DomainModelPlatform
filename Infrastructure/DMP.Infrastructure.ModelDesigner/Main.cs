using DMP.Infrastructure.ModelDesigner.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMP.Infrastructure.ModelDesigner
{
    /// <summary>主界面</summary>
    public partial class Main : BaseForm
    {
        public Main()
        {
            InitializeComponent();
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
    }
}
