using DMP.Infrastructure.Common;
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

        public DesignerTool()
        {
            //默认项目状态和文件编辑状态为已保存。
            CurrentProjectState = ProjectState.Saved;
            CurrentEditState = EditState.Saved;

            InitializeComponent();
            //不隐藏选中节点
            treeModel.HideSelection = treeModule.HideSelection = false;
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
                tmiEditRoutStation.Click += ModuleRightMenu_Click;
                rightMenu.Items.Add(tmiEditRoutStation);
                rightMenu.Show(treeModule, e.X, e.Y);
            }
            else
            { }

        }

        /// <summary>右键菜单-模块</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleRightMenu_Click(object sender, EventArgs e)
        {
            //报表
            if ("reports".Equals(treeModule.SelectedNode.Tag))
            {
                treeModule.SelectedNode.Nodes.Add(new TreeNode { Text = "新建报表", Tag = new ReportModel() });
                treeModule.SelectedNode = treeModule.SelectedNode.Nodes[treeModule.SelectedNode.Nodes.Count - 1];

            }
        }

        /// <summary>tree-模块选中后</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag is ReportModel)
                {
                    if (e.Node.Parent != null && "reports".Equals(e.Node.Parent.Tag))
                    {
                        pgridModelSetting.SelectedObject = e.Node.Tag as ReportModel;
                    }
                }
            }
        }

        /// <summary>右键菜单-模型</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeModel_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return; //无节点
            treeModel.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if ("tables".Equals(treeModel.SelectedNode.Tag) || treeModel.SelectedNode.Tag is Table)
                {
                    ContextMenuStrip rightMenu = new ContextMenuStrip();
                    ToolStripMenuItem tmiEditRoutStation = new ToolStripMenuItem("新建");
                    tmiEditRoutStation.Click += ModelRightMenu_Click;
                    rightMenu.Items.Add(tmiEditRoutStation);
                    rightMenu.Show(treeModel, e.X, e.Y);
                }
            }
            else
            { }

        }

        /// <summary>模型-右键按钮点击</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelRightMenu_Click(object sender, EventArgs e)
        {
            //表
            if ("tables".Equals(treeModel.SelectedNode.Tag))
            {
                treeModel.SelectedNode.Nodes.Add(new TreeNode { Text = "新建表", Tag = new Table() });
                treeModel.SelectedNode = treeModel.SelectedNode.Nodes[treeModel.SelectedNode.Nodes.Count - 1];
            }
            else if (treeModel.SelectedNode.Tag is Table)
            {
                treeModel.SelectedNode.Nodes.Add(new TreeNode { Text = "新建字段", Tag = new Column() });
                treeModel.SelectedNode = treeModel.SelectedNode.Nodes[treeModel.SelectedNode.Nodes.Count - 1];
            }

        }

        /// <summary>tree-模型选中后</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag is Column)
                {
                    pgridModelSetting.SelectedObject = e.Node.Tag;
                }
                else if (e.Node.Tag is Table)
                {
                    pgridModelSetting.SelectedObject = e.Node.Tag;
                }
            }


        }

        /// <summary>属性窗格值改变事件</summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void pgridModelSetting_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if ((s as PropertyGrid).SelectedObject is Table)
            {
                treeModel.SelectedNode.Text = ((s as PropertyGrid).SelectedObject as Table).DisplayName;
            }
            else if ((s as PropertyGrid).SelectedObject is Column)
            {
                treeModel.SelectedNode.Text = ((s as PropertyGrid).SelectedObject as Column).DisplayName;
            }
            else if ((s as PropertyGrid).SelectedObject is ModelBase)
            {
                treeModule.SelectedNode.Text = ((s as PropertyGrid).SelectedObject as ModelBase).Name;
            }
        }

        /// <summary>保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treeModule.SelectedNode != null)
            {
                if (treeModule.SelectedNode.Tag is ReportModel)
                {
                    var reportModel = treeModule.SelectedNode.Tag as ReportModel;
                    foreach (TreeNode modelElement in treeModel.Nodes)
                    {
                        if ("tables".Equals(modelElement.Tag))
                        {
                            foreach (TreeNode table in modelElement.Nodes)
                            {
                                reportModel.Tables.Add((table.Tag as Table).Name, (table.Tag as Table));
                            }
                        }
                    }

                    string xml = XmlUtils.Serializer(typeof(ReportModel), reportModel);

                }
            }
        }
    }
}
