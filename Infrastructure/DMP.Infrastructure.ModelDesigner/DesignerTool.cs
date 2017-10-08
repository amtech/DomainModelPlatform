using DMP.Infrastructure.Common;
using DMP.Infrastructure.Common.Xml;
using Domain.Model;
using Domain.ModelDesigner.Common;
using DMP.Infrastructure.WindowsForm;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Domain.Model.Elements;
using Domain.ModelDesigner.Model.Elements;

namespace Domain.ModelDesigner
{
    public partial class DesignerTool : BaseForm
    {

        #region Members

        //当前项目mprj文件xml结构
        private readonly XmlDocumentEx _projectContent = new XmlDocumentEx();
        private bool _modelEdited;

        #endregion

        #region Properties

        /// <summary>项目文件路径</summary>
        public string ProjectFilePath { get; set; }

        public DataModel CurrentModel { get; set; }

        #endregion

        #region Constructs

        public DesignerTool()
        {
            InitializeComponent();
            //不隐藏选中节点
            treeModel.HideSelection = treeModule.HideSelection = false;
        }

        #endregion

        #region Event

        /// <summary>窗体加载</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesignerTool_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProjectFilePath))
            {
                _projectContent.Load(ProjectFilePath); //加载xml文件
            }
            ProjectToTreeView();
        }

        /// <summary>TreeNode AfterSelect事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeNodeAfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeModelElement node = e.Node as TreeNodeModelElement;
            if (node != null)
            {
                if (node.ElementType == StaticValue.Model)  // 模型
                {
                    if (node.TreeView == treeModule && node.Parent != null)
                    {
                        OnModelSelected(node);
                    }
                }
                else // 元素:表，字段,...
                {
                    OnModelElementSelected(node);
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
                //一层节点，展开，收缩等操作都不响应。
                if (e.Action == TreeViewAction.Collapse
                    || e.Action == TreeViewAction.Expand)
                {
                    return;
                }
                TreeNodeModelElement tn = e.Node as TreeNodeModelElement;
                if (tn == null) return;
                if (_projectContent.IsEditing)
                {
                    SaveProject();
                }
                //不提示保存：1.没有当前模型，2.模型没有处于编辑状态，3.当前节点不等于当前编辑模型
                if (CurrentModel == null || (!_modelEdited) || tn.ElementName == CurrentModel.Name) return;
                if (Confirm("模型已经修改，是否保存？"))
                {
                    if (_modelEdited)
                    {
                        SaveModel();
                    }
                }
                else
                {
                    //如果取消则放弃模型的修改
                    _modelEdited = false;
                    treeModel.Nodes.Clear();
                }
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
                TreeNodeModelElement node = e.Node as TreeNodeModelElement;
                if (node != null)
                {
                    nodeRightMenu.Tag = node.ElementType + ":" + node.ElementName;
                }
                else
                {
                    nodeRightMenu.Tag = e.Node.Tag;
                }
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

                string tag = nodeRightMenu.Tag.ToStr();
                string elementType = string.Empty;
                string elementName;
                if (tag.IndexOf(":", StringComparison.Ordinal) != -1)
                {
                    elementType = tag.Split(':')[0];
                    elementName = tag.Split(':')[1];
                }
                else
                {
                    elementName = tag;
                }
                switch (toolStripDropDownItem.Tag.ToString())
                {
                    case StaticValue.Add:
                        {
                            if (StaticValue.PrjReportsNodeName.Equals(elementName))
                            {
                                CreateNewReportModel();
                            }
                            else if (StaticValue.ModelTablesNodeName.Equals(elementName))
                            {
                                CreateNewTable();
                                _modelEdited = true;
                            }
                            else if (StaticValue.ModelColumnsNodeName.Equals(elementName))
                            {
                                CreateNewColumn();
                                _modelEdited = true;
                            }
                            else if (StaticValue.ModelColumnRelationshipNodeName.Equals(elementName))
                            {
                                CreateNewColumnRelationship();
                                _modelEdited = true;
                            }
                        }
                        break;
                    case StaticValue.Delete:
                        {
                            switch (elementType)
                            {
                                case StaticValue.Model:
                                    {
                                        DeleteModel(elementName);
                                    }
                                    break;
                                case StaticValue.Table:
                                    {
                                        DeleteTable(elementName);
                                        _modelEdited = true;
                                    }
                                    break;
                                case StaticValue.Column:
                                    {
                                        DeleteColumn(elementName);
                                        _modelEdited = true;
                                    }
                                    break;
                                case StaticValue.Relationship:
                                    {
                                        DeleteNewColumnRelationship();
                                        _modelEdited = true;
                                    }
                                    break;
                                default:
                                    {
                                        if (StaticValue.ModelTablesNodeName.Equals(elementName))
                                        {
                                            _modelEdited = true;
                                        }
                                        else if (StaticValue.ModelColumnsNodeName.Equals(elementName))
                                        {
                                            //RemoveColumn
                                            _modelEdited = true;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
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
                _modelEdited = true;
                if (propertyGrid.SelectedObject is Table)
                {
                    TreeNodeModelElement treeNodeModelElement = treeModel.SelectedNode as TreeNodeModelElement;
                    if (treeNodeModelElement != null)
                    {
                        treeNodeModelElement.Text = ((Table)propertyGrid.SelectedObject).DisplayName;
                        treeNodeModelElement.ElementName = ((Table)propertyGrid.SelectedObject).Name;
                    }
                }
                else if (propertyGrid.SelectedObject is Column)
                {
                    TreeNodeModelElement treeNodeModelElement = treeModel.SelectedNode as TreeNodeModelElement;
                    if (treeNodeModelElement != null)
                    {
                        treeNodeModelElement.Text = ((Column)propertyGrid.SelectedObject).DisplayName;
                        treeNodeModelElement.ElementName = ((Column)propertyGrid.SelectedObject).Name;
                    }
                }
                else if (propertyGrid.SelectedObject is DataModel)
                {
                    TreeNodeModelElement treeNodeModelElement = treeModel.SelectedNode as TreeNodeModelElement;
                    if (treeNodeModelElement != null)
                    {
                        treeNodeModelElement.Text = ((DataModel)propertyGrid.SelectedObject).DisplayName;
                        treeNodeModelElement.ElementName = ((DataModel)propertyGrid.SelectedObject).Name;
                    }
                }
                else if (propertyGrid.SelectedObject is ColumnRelationship)
                {
                    TreeNodeModelElement treeNodeModelElement = treeModel.SelectedNode as TreeNodeModelElement;
                    if (treeNodeModelElement != null)
                    {
                        treeNodeModelElement.Text = ((ColumnRelationship)propertyGrid.SelectedObject).DisplayName;
                        treeNodeModelElement.ElementName = ((ColumnRelationship)propertyGrid.SelectedObject).Name;
                    }
                }
            }
        }

        /// <summary>保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProject(true);
            SaveModel();
            SetStatus("保存成功。");
        }

        #endregion

        #region Method

        #region 树形控件填充数据

        /// <summary>将项目信息成树状展示</summary>
        private void ProjectToTreeView()
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
                            ProjectToTreeView(xmlNode, treeNode);
                        }
                    }
                }
            }
        }

        /// <summary>将项目信息成树状展示——子节点</summary>
        /// <param name="rootXmlNode"></param>
        /// <param name="rootTreeNode"></param>
        private void ProjectToTreeView(XmlNode rootXmlNode, TreeNode rootTreeNode)
        {
            foreach (XmlNode xmlNode in rootXmlNode.ChildNodes)
            {
                string displayName = string.Empty;
                string name = string.Empty;
                if (xmlNode.Attributes != null)
                {
                    if (xmlNode.Attributes["DisplayName"] != null)
                    {
                        displayName = xmlNode.Attributes["DisplayName"].Value;
                    }
                    if (xmlNode.Attributes["Name"] != null)
                    {
                        name = xmlNode.Attributes["Name"].Value;
                    }
                }
                TreeNodeModelElement treeNode = Utils.NewModelTreeNode(name, displayName);
                rootTreeNode.Nodes.Add(treeNode);
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
                ReportModel reportModel = CurrentModel as ReportModel;
                if (reportModel == null) return;
                foreach (string tblName in reportModel.Tables.AllKeys)
                {
                    Table tbl = reportModel.Tables[tblName];
                    TreeNodeModelElement tableNode = Utils.NewTableTreeNode(tbl.Name, tbl.DisplayName);
                    tablesNode.Nodes.Add(tableNode);
                    //创建字段-根节点
                    TreeNode columnsNode = new TreeNode
                    {
                        Text = StaticValue.ModelColumnsNodeDisplayName,
                        Tag = StaticValue.ModelColumnsNodeName
                    };
                    tableNode.Nodes.Add(columnsNode);
                    foreach (string colName in tbl.Columns.AllKeys)
                    {
                        Column col = tbl.Columns[colName];
                        TreeNodeModelElement columnNode = Utils.NewColumnTreeNode(col.Name, col.DisplayName);
                        columnsNode.Nodes.Add(columnNode);
                        //字段节点底下加一个关系根节点
                        TreeNode relationsNode = new TreeNode
                        {
                            Text = StaticValue.ModelColumnRelationshipNodeDisplayName,
                            Tag = StaticValue.ModelColumnRelationshipNodeName
                        };
                        columnNode.Nodes.Add(relationsNode);
                        if (col.Relationship != null)
                        {
                            TreeNodeModelElement relationNode = Utils.NewRelationshipTreeNode(col.Relationship.Name, col.Relationship.DisplayName);
                            relationsNode.Nodes.Add(relationNode);
                        }
                    }
                }
            }
            pgridModelSetting.SelectedObject = CurrentModel;
        }

        #endregion

        #region 树节点增删操作

        /// <summary>新建报表模型</summary>
        private void CreateNewReportModel()
        {
            //新增一个报表模型文件。 
            var newModelDialog = new NewModelDialog();
            newModelDialog.NewModelType = EnumValue.ModelType.Report;
            if (newModelDialog.ShowDialog() == DialogResult.OK)
            {
                //往项目文件里面加一个节点。 
                XmlElement xmlElement = _projectContent.CreateElement(StaticValue.PrjReportElementName);
                xmlElement.SetAttribute("Name", newModelDialog.Model.Name);
                xmlElement.SetAttribute("DisplayName", newModelDialog.Model.DisplayName);
                if (_projectContent.DocumentElement != null)
                {
                    string filePath = _projectContent.DocumentElement.GetAttribute("Folder") + "Reports\\" + newModelDialog.Model.Name + ".xml";
                    xmlElement.SetAttribute("Path", filePath);
                }
                XmlNode reportsXmlNode = _projectContent.SelectSingleNode("/Project/Reports");
                if (reportsXmlNode != null)
                {
                    reportsXmlNode.AppendChild(xmlElement);
                }
                CurrentModel = newModelDialog.Model;
                //更新树形控件。
                TreeNode reportsNode = treeModule.GetTreeNodeByTag("reports");
                if (reportsNode != null)
                {
                    reportsNode.Nodes.Add(Utils.NewModelTreeNode(CurrentModel.Name, CurrentModel.DisplayName));
                    treeModule.SelectedNode = reportsNode.Nodes[reportsNode.Nodes.Count - 1];
                }
                ReportModelToTreeView();

                SaveProject();
                SaveModel();
            }
        }

        /// <summary>删除模型</summary>
        private void DeleteModel(string modelName)
        {
            if (CurrentModel == null || !CurrentModel.Name.Equals(modelName))
            {
                SetStatus("删除模型失败，模型信息异常。");
                return;
            }
            //删除文件 
            if (_projectContent.DocumentElement != null)
            {
                TreeNode modelTreeeNode = treeModule.GetTreeNodeByTag(modelName);
                if (modelTreeeNode == null)
                {
                    return;
                }
                //先定位到上一级
                treeModule.SelectedNode = modelTreeeNode;
                string projectFolder = _projectContent.DocumentElement.Attributes["Folder"].Value;
                string path;
                string modelXpath;
                if (CurrentModel is ReportModel)
                {
                    path = projectFolder + StaticValue.PrjReportsNodeName + "\\" +
                              modelName + ".xml";
                    modelXpath = "/Project/" + StaticValue.PrjReportsNodeName + "/" + StaticValue.PrjReportElementName +
                        "[@Name='" + modelName + "']";
                }
                else
                {
                    path = projectFolder + StaticValue.PrjBusinessNodeName + "\\" + modelName + ".xml";
                    modelXpath = "/Project/" + StaticValue.PrjBusinessNodeName + "/" + StaticValue.PrjDocumentElementName +
                        "[@Name='" + modelName + "']";
                }
                if (Utils.DeleteFile(path))
                {
                    //删除项目文件节点
                    XmlNode modelNode = _projectContent.SelectSingleNode(modelXpath);
                    if (modelNode != null && modelNode.ParentNode != null)
                    {
                        modelNode.ParentNode.RemoveChild(modelNode);
                        SaveProject();
                        treeModel.Nodes.Clear();
                        _modelEdited = false;
                    }
                    else
                    {
                        Alert("项目文件结构异常！");
                    }
                }
                else
                {
                    Alert("删除模型文件失败！");
                }
                //删除树控件节点
                modelTreeeNode.Remove();
                pgridModelSetting.SelectedObject = null;
            }
        }

        /// <summary>新建表</summary>
        private void CreateNewTable()
        {
            if (CurrentModel is ReportModel)
            {
                //创建表对象
                Table tblNew = ModelUtils.AddNewTable<Table>(CurrentModel as ReportModel);
                //树形控件增加一个表节点
                TreeNodeModelElement tnNewTable = Utils.NewTableTreeNode(tblNew.Name, tblNew.DisplayName);
                treeModel.SelectedNode.Nodes.Add(tnNewTable);
                //选中新增的节点
                treeModel.SelectLastAddNode();
                //表节点底下加一个字段根节点
                tnNewTable.Nodes.Add(new TreeNode { Text = StaticValue.ModelColumnsNodeDisplayName, Tag = StaticValue.ModelColumnsNodeName });
            }
        }

        /// <summary>删除表</summary>
        private void DeleteTable(string tableName)
        {
            DataModel dataModel = CurrentModel;
            if (dataModel == null) return;
            dataModel.Tables.Remove(tableName);
            //删除tree
            treeModel.SelectedNode.Remove();
        }

        /// <summary>新建字段</summary>
        private void CreateNewColumn()
        {
            if (CurrentModel is ReportModel)
            {
                TreeNodeModelElement tableNode = treeModel.SelectedNode.Parent as TreeNodeModelElement;
                if (tableNode != null)
                {
                    Table tbl = (CurrentModel as ReportModel).Tables[tableNode.ElementName];
                    //创建字段对象
                    ColumnEx col = ModelUtils.AddNewColumn<ColumnEx>(tbl);
                    //树形控件增加一个字段节点
                    TreeNodeModelElement tnCol = Utils.NewColumnTreeNode(col.Name, col.DisplayName);
                    treeModel.SelectedNode.Nodes.Add(tnCol);
                    //选中新增的节点
                    treeModel.SelectLastAddNode();
                    //字段节点底下加一个关系根节点
                    tnCol.Nodes.Add(new TreeNode { Text = StaticValue.ModelColumnRelationshipNodeDisplayName, Tag = StaticValue.ModelColumnRelationshipNodeName });
                }

            }
        }

        /// <summary>删除字段</summary>
        private void DeleteColumn(string modelName)
        {
            //模型删除字段
            DataModel dataModel = CurrentModel;
            if (dataModel == null) return;
            TreeNodeModelElement colNode = treeModel.SelectedNode as TreeNodeModelElement;
            if (colNode == null) return;
            TreeNodeModelElement tblNode = colNode.Parent.Parent as TreeNodeModelElement;
            if (tblNode == null) return;
            Table tbl = dataModel.Tables[tblNode.ElementName];
            if (tbl == null) return;
            tbl.Columns.Remove(modelName);
            //删除tree
            treeModel.SelectedNode.Remove();
        }

        /// <summary>新建关系模型</summary>
        private void CreateNewColumnRelationship()
        {
            if (CurrentModel is ReportModel)
            {

                NewColumnRelationshipDialog newRelationshipDialog = new NewColumnRelationshipDialog();
                if (newRelationshipDialog.ShowDialog() == DialogResult.OK)
                {
                    TreeNodeModelElement columnNode = treeModel.SelectedNode.Parent as TreeNodeModelElement;
                    if (columnNode != null)
                    {
                        TreeNodeModelElement tableNode = columnNode.Parent.Parent as TreeNodeModelElement;
                        if (tableNode != null)
                        {
                            Table tbl = (CurrentModel as ReportModel).Tables[tableNode.ElementName];
                            if (tbl != null)
                            {
                                ColumnEx col = (ColumnEx)tbl.Columns[columnNode.ElementName];
                                col.Relationship = newRelationshipDialog.Relationship;
                                //树形控件增加一个字段节点
                                TreeNodeModelElement tnRelationship = Utils.NewRelationshipTreeNode(newRelationshipDialog.Relationship.Name,
                                                                                                        newRelationshipDialog.Relationship.DisplayName);
                                treeModel.SelectedNode.Nodes.Add(tnRelationship);
                                //选中新增的节点
                                treeModel.SelectLastAddNode();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>删除关系模型</summary>
        private void DeleteNewColumnRelationship()
        {
            //模型删除字段
            DataModel dataModel = CurrentModel;
            if (dataModel == null) return;
            TreeNodeModelElement relNode = treeModel.SelectedNode as TreeNodeModelElement;
            if (relNode == null) return;
            TreeNodeModelElement colNode = relNode.Parent.Parent as TreeNodeModelElement;
            if (colNode == null) return;
            TreeNodeModelElement tblNode = colNode.Parent.Parent as TreeNodeModelElement;
            if (tblNode == null) return;
            Table tbl = dataModel.Tables[tblNode.ElementName];
            if (tbl == null) return;
            ColumnEx col = (ColumnEx)tbl.Columns[colNode.ElementName];
            if (col == null) return;
            col.Relationship = null;
            //删除tree
            treeModel.SelectedNode.Remove();
        }

        #endregion

        /// <summary>选中模型元素时</summary>
        /// <param name="elementNode"></param>
        private void OnModelElementSelected(TreeNodeModelElement elementNode)
        {
            switch (elementNode.ElementType)
            {
                case StaticValue.Table:
                    {
                        DataModel dataModel = CurrentModel;
                        if (dataModel != null)
                        {
                            pgridModelSetting.SelectedObject =
                                dataModel.Tables[elementNode.ElementName];
                        }
                    }
                    break;
                case StaticValue.Column:
                    {
                        DataModel dataModel = CurrentModel;
                        if (dataModel != null)
                        {
                            TreeNodeModelElement treeNodeModelElement = elementNode.Parent.Parent as TreeNodeModelElement;
                            if (treeNodeModelElement != null)
                            {
                                Table tbl = dataModel.Tables[treeNodeModelElement.ElementName];
                                if (tbl != null)
                                {
                                    pgridModelSetting.SelectedObject = tbl.Columns[elementNode.ElementName];
                                }
                            }
                        }
                    }
                    break;
                case StaticValue.Relationship:
                    {
                        DataModel dataModel = CurrentModel;
                        if (dataModel != null)
                        {
                            TreeNodeModelElement colElement = elementNode.Parent.Parent as TreeNodeModelElement;
                            if (colElement != null)
                            {
                                TreeNodeModelElement tblElement = colElement.Parent.Parent as TreeNodeModelElement;
                                if (tblElement != null)
                                {
                                    Table tbl = dataModel.Tables[tblElement.ElementName];
                                    if (tbl != null)
                                    {
                                        ColumnEx col = (ColumnEx)tbl.Columns[colElement.ElementName];
                                        if (col != null && col.Relationship != null)
                                        {
                                            pgridModelSetting.SelectedObject = col.Relationship;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>选中模型</summary>
        /// <param name="node"></param>
        private void OnModelSelected(TreeNode node)
        {
            if ("Reports".Equals(node.Parent.Tag.ToStr(), StringComparison.OrdinalIgnoreCase))
            {
                if (_projectContent.DocumentElement != null)
                {
                    TreeNodeModelElement treeNodeModelElement = node as TreeNodeModelElement;
                    if (treeNodeModelElement != null)
                    {
                        string projectFolder = _projectContent.DocumentElement.Attributes["Folder"].Value;
                        string filePath = projectFolder + "Reports\\" + treeNodeModelElement.ElementName + ".xml";
                        if (File.Exists(filePath))
                        {
                            using (FileStream file = new FileStream(filePath, FileMode.Open))
                            {
                                CurrentModel = ModelUtils.DeserializeModel<ReportModel, ColumnEx>(file);
                            }
                        }
                    }
                }
            }
            ReportModelToTreeView();
        }

        /// <summary>设置状态栏文本</summary>
        /// <param name="msg"></param>
        private void SetStatus(string msg)
        {
            Main main = MdiParent as Main;
            if (main != null)
            {
                main.SetStatus(msg);
            }
        }

        /// <summary>保存项目</summary>
        private void SaveProject(bool needConfirm = false)
        {
            if (_projectContent.IsEditing)
            {
                if (needConfirm && !Confirm("是否保存项目？"))
                {
                    return;
                }
                //保存项目文件
                _projectContent.Save(ProjectFilePath);
            }
        }

        /// <summary>保存模型</summary>
        private void SaveModel()
        {
            if (_projectContent.DocumentElement != null)
            {
                string projectFolder = _projectContent.DocumentElement.Attributes["Folder"].Value;
                //构建项目目录结构(防止文件夹丢失)
                Utils.CreatePrjFolder(projectFolder);
                if (treeModule.SelectedNode != null)
                {
                    if (CurrentModel is ReportModel)
                    {
                        string filePath = projectFolder + "Reports\\" + CurrentModel.Name + ".xml";

                        //将当期模型序列化成xml字符串
                        string xml = ModelUtils.Serialize<ReportModel, ColumnEx>(CurrentModel);
                        //CurrentModel.Name
                        //判断模型文件是否存在 
                        Utils.SaveTextFile(xml, filePath);
                    }
                    //重置编辑状态
                    _modelEdited = false;
                }
            }
        }

        #endregion

    }
}
