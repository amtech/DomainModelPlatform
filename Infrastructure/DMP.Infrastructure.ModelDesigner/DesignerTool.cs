using DMP.Infrastructure.Common;
using DMP.Infrastructure.Common.Model;
using DMP.Infrastructure.ModelDesigner.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DMP.Infrastructure.Common.Xml;

namespace DMP.Infrastructure.ModelDesigner
{
    public partial class DesignerTool : BaseForm
    {

        #region Members 

        /// <summary>当前项目mprj文件xml结构</summary>
        private readonly XmlDocumentEx _projectContent = new XmlDocumentEx();

        #endregion

        #region Properties

        /// <summary>项目文件路径</summary>
        public string ProjectFilePath { get; set; }

        public ModelBase CurrentModel { get; set; }

        #endregion

        #region Constructs

        public DesignerTool()
        {
            InitializeComponent();
            //不隐藏选中节点
            treeModel.HideSelection = treeModule.HideSelection = false;
        }

        #endregion

        private void DesignerTool_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProjectFilePath))
            {
                _projectContent.Load(ProjectFilePath); //加载xml文件
            }
            InitTreeModule();
        }

        /// <summary>初始化模块信息的树形控件</summary>
        private void InitTreeModule()
        {
            if (_projectContent != null)
            {
                treeModule.Nodes.Clear();
                if (_projectContent.DocumentElement != null)
                {
                    foreach (XmlNode xmlNode in _projectContent.DocumentElement.ChildNodes)
                    {
                        if (StaticValue.PrjNodesNameMapping.Keys.Contains(xmlNode.Name))
                        {
                            TreeNode treeNode = new TreeNode
                            {
                                Text = StaticValue.PrjNodesNameMapping[xmlNode.Name],
                                Tag = xmlNode.Name
                            };
                            treeModule.Nodes.Add(treeNode);
                        }
                    }
                }
            }
        }

        /// <summary>TreeNode AfterSelect事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeNodeAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {

            }
        }

        /// <summary>PropertyGrid PropertyValueChanged 事件</summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void PropertyGridPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            PropertyGrid propertyGrid = (s as PropertyGrid);
            if (propertyGrid != null && propertyGrid.SelectedObject != null)
            {
                if (propertyGrid.SelectedObject is Table)
                {
                    treeModel.SelectedNode.Text = ((Table)propertyGrid.SelectedObject).DisplayName;
                }
                else if (propertyGrid.SelectedObject is Column)
                {
                    treeModel.SelectedNode.Text = ((Column)propertyGrid.SelectedObject).DisplayName;
                }
                else if (propertyGrid.SelectedObject is ModelBase)
                {
                    treeModule.SelectedNode.Text = ((ModelBase)propertyGrid.SelectedObject).DisplayName;
                }
            }
        }

        /// <summary>TreeView BeforeSelect</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            if (treeView == null) return;
            if (treeView.Name == treeModule.Name)
            {
                var tn = e.Node;
                //一层节点，展开，收缩等操作都不响应。
                if (tn.Parent == null
                    || e.Action == TreeViewAction.Collapse
                    || e.Action == TreeViewAction.Expand)
                {
                    return;
                }
                //如果当前没有编辑的模型就没有提示
                if (CurrentModel == null) return;
                switch (MessageBox.Show("单据已经修改，要保存吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Yes:
                        {
                        }
                        break;
                    case DialogResult.No:
                        {

                        }
                        break;
                }
            }

        }

        /// <summary>树形节点click事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return; //无节点 
            if (e.Button == MouseButtons.Right)
            {
                TreeViewEx treeView = sender as TreeViewEx;
                if (treeView != null)
                {
                    treeView.SelectedNode = e.Node;
                }
                nodeRightMenu.Tag = e.Node.Tag;
                nodeRightMenu.Show(treeView, e.X, e.Y);
            }
        }

        /// <summary>右键菜单项click事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightMenuClick(object sender, EventArgs e)
        {
            var toolStripDropDownItem = sender as ToolStripDropDownItem;
            if (toolStripDropDownItem != null)
            {
                switch (toolStripDropDownItem.Tag.ToString())
                {
                    case StaticValue.Add:
                        {
                            if (nodeRightMenu.Tag == null) return;
                            if (StaticValue.PrjReportsNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {
                                CreateNewReportModel();
                            }
                            else if (StaticValue.ModelTablesNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {
                                CreateNewTable();
                            }
                            else if (StaticValue.ModelColumnsNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {
                                CreateNewColumn();
                            }
                        }
                        break;
                    case StaticValue.Delete:
                        {

                        }
                        break;
                }
            }
        }

        /// <summary>保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_projectContent.IsEditing)
            {
                if (Confirm("是否保存项目？"))
                {
                    _projectContent.Save(ProjectFilePath);
                }
            }
            /*
            if (treeModule.SelectedNode != null)
            {
                if (treeModule.SelectedNode.Tag is ReportModel)
                {
                    var reportModel = treeModule.SelectedNode.Tag as ReportModel;
                    foreach (TreeNode modelElement in treeModel.Nodes)
                    {
                        if ("tables".Equals(modelElement.Tag))
                        {
                            reportModel.Tables.Clear();
                            foreach (TreeNode table in modelElement.Nodes)
                            {
                                reportModel.Tables.Add(table.Tag as Table);
                            }
                        }
                    }

                    string xml = XmlUtils.Serializer(reportModel);
                    string savePath = GetSaveXmlPath();
                    if (!string.IsNullOrEmpty(savePath))
                    {
                        SaveFile(xml, savePath);
                    }
                }
            }
            */
        }

        /// <summary>新建报表模型</summary>
        private void CreateNewReportModel()
        {
            //todo:新增一个报表模型文件。 
            var newModelDialog = new NewModelDialog();
            newModelDialog.NewModelType = EnumValue.ModelType.Report;
            if (newModelDialog.ShowDialog() == DialogResult.OK)
            {
                //todo:往项目文件里面加一个节点。 
                XmlElement xmlElement = _projectContent.CreateElement(newModelDialog.Model.Name);
                xmlElement.SetAttribute("DisplayName", newModelDialog.Model.DisplayName);
                if (_projectContent.DocumentElement != null)
                {
                    xmlElement.SetAttribute("Path", _projectContent.DocumentElement.GetAttribute("Folder") + newModelDialog.Model.Name + ".xml");
                }
                XmlNode reportsXmlNode = _projectContent.SelectSingleNode("/Project/Reports");
                if (reportsXmlNode != null)
                {
                    reportsXmlNode.AppendChild(xmlElement);
                }
                CurrentModel = newModelDialog.Model;
                //todo:更新树形控件。
                TreeNode reportsNode = treeModule.GetTreeNodeByTag("reports");
                if (reportsNode != null)
                {
                    reportsNode.Nodes.Add(new TreeNode { Text = CurrentModel.DisplayName, Tag = CurrentModel.SourceTag.ToString() + "," + CurrentModel.DocumentType.ToString() });
                    treeModule.SelectedNode = reportsNode.Nodes[reportsNode.Nodes.Count - 1];
                }
                ReportModelToTreeView();
                pgridModelSetting.SelectedObject = CurrentModel;
            }
        }

        /// <summary>将报表模型转成树状控件</summary>
        private void ReportModelToTreeView()
        {
            treeModel.Nodes.Clear();

            if (CurrentModel != null)
            {
                //创建表-根节点
                TreeNode tablesNode =
                    new TreeNode { Text = StaticValue.ModelTablesNodeDisplayName, Tag = StaticValue.ModelTablesNodeName };
                treeModel.Nodes.Add(tablesNode);
                //整个模型对象结构
                foreach (Table tbl in (CurrentModel as ReportModel).Tables)
                {
                    TreeNodeModelElement tableNode = Utils.NewTableTreeNode(tbl.Name, tbl.DisplayName);
                    tablesNode.Nodes.Add(tableNode);
                    //创建字段-根节点
                    TreeNode columnsNode = new TreeNode { Text = StaticValue.ModelColumnsNodeDisplayName, Tag = StaticValue.ModelColumnsNodeName };
                    tableNode.Nodes.Add(columnsNode);
                    foreach (Column col in tbl.Columns)
                    {
                        TreeNodeModelElement columnNode = Utils.NewColumnTreeNode(col.Name, col.DisplayName);
                        columnsNode.Nodes.Add(columnNode);
                    }
                }
            }
        }

        /// <summary>新建数据表</summary>
        private void CreateNewTable()
        {
            if (CurrentModel is ReportModel)
            {
                //todo:创建表对象
                Table tblNew = ModelUtils.AddNewTable(CurrentModel as ReportModel);
                //todo:树形控件增加一个表节点
                TreeNodeModelElement tnNewTable = Utils.NewTableTreeNode(tblNew.Name, tblNew.DisplayName);
                treeModel.SelectedNode.Nodes.Add(tnNewTable);
                //选中新增的表节点
                treeModel.SelectedNode = treeModel.SelectedNode.Nodes[treeModel.SelectedNode.Nodes.Count - 1];

                //todo:表节点底下加一个字段根节点
                tnNewTable.Nodes.Add(new TreeNode { Text = StaticValue.ModelColumnsNodeDisplayName, Tag = StaticValue.ModelColumnsNodeName });
                //todo:属性窗口对象绑定当前新增的table对象。
                pgridModelSetting.SelectedObject = (CurrentModel as ReportModel).Tables[(CurrentModel as ReportModel).Tables.Count - 1];
            }

        }


        /// <summary>新建字段</summary>
        private void CreateNewColumn()
        {
            if (CurrentModel is ReportModel)
            {
                if(treeModel.SelectedNode.Parent is TreeNodeModelElement)
                {
                    //todo:根据当前选中TreeNode找到表对象，添加字段对象。
                    string tableName = (treeModel.SelectedNode.Parent as TreeNodeModelElement).ElementName;
                    Table tbl = (CurrentModel as ReportModel).FindTable(tableName);
                    //todo:创建字段对象
                    Column col = ModelUtils.AddNewColumn(tbl);
                    //todo:树形控件增加一个表节点
                    TreeNodeModelElement tnCol = Utils.NewColumnTreeNode(col.Name, col.DisplayName);
                    treeModel.SelectedNode.Nodes.Add(tnCol);
                    //todo:属性窗格绑定字段对象。
                    pgridModelSetting.SelectedObject = tbl.Columns[tbl.Columns.Count - 1];
                }
                
            }
        }



    }
}
