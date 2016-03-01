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
using System.IO;

namespace DMP.Infrastructure.ModelDesigner
{
    public partial class DesignerTool : BaseForm
    {

        #region Members 

        /// <summary>当前项目mprj文件xml结构</summary>
        private readonly XmlDocumentEx ProjectContent = new XmlDocumentEx();
        private bool ModelEdited = false;
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
                ProjectContent.Load(ProjectFilePath); //加载xml文件
            }
            InitTreeModule();
        }

        /// <summary>初始化模块信息的树形控件</summary>
        private void InitTreeModule()
        {
            if (ProjectContent != null)
            {
                treeModule.Nodes.Clear();
                if (ProjectContent.DocumentElement != null)
                {
                    foreach (XmlNode xmlNode in ProjectContent.DocumentElement.ChildNodes)
                    {
                        if (StaticValue.PrjNodesNameMapping.Keys.Contains(xmlNode.Name))
                        {
                            TreeNode treeNode = new TreeNode
                            {
                                Text = StaticValue.PrjNodesNameMapping[xmlNode.Name],
                                Tag = xmlNode.Name
                            };
                            treeModule.Nodes.Add(treeNode);
                            InitTreeModuleChildNodes(xmlNode, treeNode);
                        }
                    }
                }
            }
        }

        private void InitTreeModuleChildNodes(XmlNode rootXmlNode, TreeNode rootTreeNode)
        {
            foreach (XmlNode xmlNode in rootXmlNode.ChildNodes)
            {
                TreeNode treeNode = new TreeNode
                {
                    Text = xmlNode.Attributes["DisplayName"].Value,
                    Tag = xmlNode.Attributes["Name"].Value
                };
                rootTreeNode.Nodes.Add(treeNode);
            }
        }

        /// <summary>TreeNode AfterSelect事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeNodeAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node is TreeNodeModelElement) //选中模型的元素
            {
                OnModelElementSelected((e.Node as TreeNodeModelElement));
            }
            else
            {
                if (e.Node.TreeView == treeModule && e.Node.Parent != null) //选中模型
                {
                    OnModelSelected(e.Node);
                }
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
                ModelEdited = true;
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
                if (e.Action == TreeViewAction.Collapse
                    || e.Action == TreeViewAction.Expand)
                {
                    return;
                }
                //如果当前没有编辑的模型就没有提示
                if (CurrentModel == null || !ModelEdited) return;
                switch (MessageBox.Show("单据已经修改，要保存吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Yes:
                        {
                            SaveModel();
                        }
                        break;
                    case DialogResult.No:
                        {

                        }
                        break;
                }
                //重置编辑状态
                ModelEdited = false;
                CurrentModel = null;
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
                if (nodeRightMenu.Tag == null) return;
                switch (toolStripDropDownItem.Tag.ToString())
                {
                    case StaticValue.Add:
                        {
                            if (StaticValue.PrjReportsNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {
                                CreateNewReportModel();
                            }
                            else if (StaticValue.ModelTablesNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {
                                CreateNewTable();
                                ModelEdited = true;
                            }
                            else if (StaticValue.ModelColumnsNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {
                                CreateNewColumn();
                                ModelEdited = true;
                            }
                        }
                        break;
                    case StaticValue.Delete:
                        {
                            if (StaticValue.PrjReportsNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {

                            }
                            else if (StaticValue.ModelTablesNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {

                                ModelEdited = true;
                            }
                            else if (StaticValue.ModelColumnsNodeName.Equals(nodeRightMenu.Tag.ToString()))
                            {

                                ModelEdited = true;
                            }
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
            SaveProject();
            SaveModel();
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
                XmlElement xmlElement = ProjectContent.CreateElement(StaticValue.PrjReportElementName);
                xmlElement.SetAttribute("Name", newModelDialog.Model.Name);
                xmlElement.SetAttribute("DisplayName", newModelDialog.Model.DisplayName);
                if (ProjectContent.DocumentElement != null)
                {
                    string filePath = ProjectContent.DocumentElement.GetAttribute("Folder") + "Reports\\" + newModelDialog.Model.Name + ".xml";
                    xmlElement.SetAttribute("Path", filePath);
                }
                XmlNode reportsXmlNode = ProjectContent.SelectSingleNode("/Project/Reports");
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
                //选中新增的节点
                treeModel.SelectLastAddNode();
                //todo:表节点底下加一个字段根节点
                tnNewTable.Nodes.Add(new TreeNode { Text = StaticValue.ModelColumnsNodeDisplayName, Tag = StaticValue.ModelColumnsNodeName });
            }

        }

        /// <summary>新建字段</summary>
        private void CreateNewColumn()
        {
            if (CurrentModel is ReportModel)
            {
                if (treeModel.SelectedNode.Parent is TreeNodeModelElement)
                {
                    //todo:根据当前选中TreeNode找到表对象，添加字段对象。
                    string tableName = (treeModel.SelectedNode.Parent as TreeNodeModelElement).ElementName;
                    Table tbl = (CurrentModel as ReportModel).FindTable(tableName);
                    //todo:创建字段对象
                    Column col = ModelUtils.AddNewColumn(tbl);
                    //todo:树形控件增加一个字段节点
                    TreeNodeModelElement tnCol = Utils.NewColumnTreeNode(col.Name, col.DisplayName);
                    treeModel.SelectedNode.Nodes.Add(tnCol);
                    //选中新增的节点
                    treeModel.SelectLastAddNode();
                }

            }
        }

        /// <summary>选中模型元素时</summary>
        /// <param name="elementNode"></param>
        private void OnModelElementSelected(TreeNodeModelElement elementNode)
        {
            switch (elementNode.ElementType)
            {
                case StaticValue.Table:
                    {
                        pgridModelSetting.SelectedObject =
                              (CurrentModel as DataModel).FindTable(elementNode.ElementName);
                    }
                    break;
                case StaticValue.Column:
                    {
                        pgridModelSetting.SelectedObject = (CurrentModel as DataModel).
                            FindTable((elementNode.Parent.Parent as TreeNodeModelElement).ElementName).FindColumn(elementNode.ElementName);
                    }
                    break;
            }
        }

        /// <summary>选中模型</summary>
        /// <param name="node"></param>
        private void OnModelSelected(TreeNode node)
        {
            if ("Reports".Equals(StringUtils.ToString(node.Parent.Tag), StringComparison.OrdinalIgnoreCase))
            {
                string projectFolder = ProjectContent.DocumentElement.Attributes["Folder"].Value;
                string filePath = projectFolder + "Reports\\" + StringUtils.ToString(node.Tag) + ".xml";
                if (File.Exists(filePath))
                {
                    FileStream file = new FileStream(filePath, FileMode.Open);
                    CurrentModel = XmlUtils.Deserialize<ReportModel>(file);


                    foreach (var item in CurrentModel.GetType().GetProperties())
                    {
                        var v = (DescriptionAttribute[])item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (v != null && v.Length > 0)
                        {
                            var descriptionName = v[0].Description;     
                        }
                        
                    }


                    file.Close();
                }
            }
            ReportModelToTreeView();
        }

        /// <summary>保存项目</summary>
        private void SaveProject()
        {
            string projectFolder = ProjectContent.DocumentElement.Attributes["Folder"].Value;
            if (ProjectContent.IsEditing)
            {
                if (Confirm("是否保存项目？"))
                {
                    //todo: 保存项目文件
                    ProjectContent.Save(ProjectFilePath);
                }
            }
        }

        /// <summary>保存模型</summary>
        private void SaveModel()
        {
            string projectFolder = ProjectContent.DocumentElement.Attributes["Folder"].Value;
            //todo: 构建项目目录结构(防止文件夹丢失)
            Utils.CreatePrjFolder(projectFolder);
            if (treeModule.SelectedNode != null)
            {
                if (CurrentModel is ReportModel)
                {
                    string filePath = projectFolder + "Reports\\" + CurrentModel.Name + ".xml";

                    //todo：将当期模型序列化成xml字符串
                    string xml = XmlUtils.Serializer(CurrentModel);
                    //CurrentModel.Name
                    //todo：判断模型文件是否存在 
                    SaveFile(xml, filePath);
                }
                //重置编辑状态
                ModelEdited = false;
            }
        }


    }
}
