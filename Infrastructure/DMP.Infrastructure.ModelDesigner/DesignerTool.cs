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
        public enum ProjectState
        {
            New,
            Editing,
            Saved
        }

        /// <summary>当前项目状态</summary>
        public ProjectState CurrentProjectState { get; set; }

        public enum EditState
        {
            UnSave,
            Saved
        }

        /// <summary>当前文件编辑状态</summary>
        public EditState CurrentEditState { get; set; }

        public int SourceTag { get; set; }

        public int DocumentType { get; set; }

        public DesignerTool()
        {
            //默认项目状态和文件编辑状态为已保存。
            CurrentProjectState = ProjectState.Saved;
            CurrentEditState = EditState.Saved;
            InitializeComponent();
        }

        private void DesignerTool_Load(object sender, EventArgs e)
        {
            if (CurrentProjectState == ProjectState.New)
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
                treeModule.SelectedNode.Nodes.Add(new TreeNode { Text = "新建报表", Tag = "new" });
                treeModule.SelectedNode = treeModule.SelectedNode.Nodes[treeModule.SelectedNode.Nodes.Count - 1];

            }
        }


        private void treeModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ("new".Equals(e.Node.Tag))
            {
                if (e.Node.Parent != null && "reports".Equals(e.Node.Parent.Tag))
                {
                    ReportModel reportModel = new ReportModel();
                    pgridModelSetting.SelectedObject = reportModel;
                }
            }

        }
    }
}
