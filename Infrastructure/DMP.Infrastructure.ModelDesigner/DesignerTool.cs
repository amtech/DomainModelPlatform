using DMP.Infrastructure.Common.Model;
using ModelDesigner.Common;
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
    public partial class DesignerTool : BaseForm
    {
        public enum FileState
        {
            New,
            Editing,
            Saved
        }

        /// <summary>当前文件状态</summary>
        public FileState CurrentFileState { get; set; }

        public int SourceTag { get; set; }

        public int DocumentType { get; set; }

        public DesignerTool()
        {
            InitializeComponent();
        }

        private void DesignerTool_Load(object sender, EventArgs e)
        {
            if (CurrentFileState == FileState.New)
            {

            }
        }

        /// <summary>模块功能树形列表-节点鼠标点击事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeModule_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node == null) return; //无节点
            treeModule.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip rightMenu = new ContextMenuStrip();
                ToolStripMenuItem tmiEditRoutStation = new ToolStripMenuItem("新建");
                tmiEditRoutStation.Click += RightMenuNewModel_Click;
                rightMenu.Items.Add(tmiEditRoutStation);
                rightMenu.Show(treeModule, e.X, e.Y);
            }
            else
            { }

        }

        /// <summary>右键菜单-新建模型</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightMenuNewModel_Click(object sender, EventArgs e)
        {
            //报表
            if ("reports".Equals(treeModule.SelectedNode.Tag))
            {
                ReportModel reportModel = new ReportModel();
                pgridModelSetting.SelectedObject = reportModel;
            }
        }
    }
}
