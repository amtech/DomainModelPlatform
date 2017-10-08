using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Infrastructure.Common;

namespace Domain.ModelDesigner.Common
{
    public class Utils
    {
        #region 项目相关

        //项目文件后缀
        public const string ProjectFilePostfix = ".mprj";

        /// <summary>新建项目</summary>
        public static string NewProject()
        {
            NewProjectDialog sfd = new NewProjectDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string projectFolder = sfd.Folder + sfd.ProjectName + "\\";
                string fullName = sfd.Folder + sfd.ProjectName + ProjectFilePostfix;


                XmlDocument doc = new XmlDocument();

                XmlElement rootProject = doc.CreateElement("Project");
                rootProject.SetAttribute("Name", sfd.ProjectName);
                //项目文件夹路径
                rootProject.SetAttribute("Folder", projectFolder);
                rootProject.SetAttribute("DisplayName", sfd.DisplayName);
                doc.AppendChild(rootProject);
                //业务功能
                XmlElement businessFunctions = doc.CreateElement(StaticValue.PrjBusinessNodeName);
                rootProject.AppendChild(businessFunctions);

                //报表
                XmlElement reports = doc.CreateElement(StaticValue.PrjReportsNodeName);
                rootProject.AppendChild(reports);

                //Business 
                doc.Save(fullName);
                CreatePrjFolder(projectFolder);
                return fullName;
            }
            return string.Empty;
        }

        public static void CreatePrjFolder(string projectFolder)
        {
            if (Directory.Exists(projectFolder) == false)//如果不存在就创建file文件夹{
                Directory.CreateDirectory(projectFolder);
            if (Directory.Exists(projectFolder + "Reports") == false)//如果不存在就创建file文件夹{
                Directory.CreateDirectory(projectFolder + "Reports");

        }

        /// <summary>打开项目</summary>
        public static string OpenProject()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = string.Format("项目文件(*{0})|*{0}", ProjectFilePostfix)
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        /// <summary>选择文件夹</summary>
        /// <returns></returns>
        public static string SelectFolder(string folder = "")
        {
            folder = folder.Trim();
            if (!Directory.Exists(folder))
            {
                folder = AppDomain.CurrentDomain.BaseDirectory;
            }
            FolderBrowserDialog path = new FolderBrowserDialog
            {
                SelectedPath = folder
            };
            if (path.ShowDialog() == DialogResult.OK)
            {
                return path.SelectedPath;
            }
            return string.Empty;
        }

        #endregion

        #region TreeNode相关

        /// <summary>新建模型treenode</summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static TreeNodeModelElement NewModelTreeNode(string name, string displayName)
        {
            return new TreeNodeModelElement { ElementType = StaticValue.Model, ElementName = name, Text = displayName };
        }

        /// <summary>新建表treenode</summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static TreeNodeModelElement NewTableTreeNode(string name, string displayName)
        {
            return new TreeNodeModelElement { ElementType = StaticValue.Table, ElementName = name, Text = displayName };
        }

        /// <summary>新建字段treenode</summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static TreeNodeModelElement NewColumnTreeNode(string name, string displayName)
        {
            return new TreeNodeModelElement { ElementType = StaticValue.Column, ElementName = name, Text = displayName };
        }

        /// <summary>新建关系</summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static TreeNodeModelElement NewRelationshipTreeNode(string name, string displayName)
        {
            return new TreeNodeModelElement { ElementType = StaticValue.Relationship, ElementName = name, Text = displayName };
        }

        #endregion

        public static string GetSaveXmlPath()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = StaticValue.XmlFilter
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return string.Empty;
        }

        /// <summary>保存文本文件</summary>
        /// <param name="content">内容</param>
        /// <param name="path">路径</param>
        public static void SaveTextFile(string content, string path)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.Write(content);
            streamWriter.Close();
        }

        /// <summary>删除文件</summary>
        /// <param name="path"></param>
        public static bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    FileInfo fi = new FileInfo(path);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly", StringComparison.Ordinal) != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(path);
                    return true;
                }
                catch
                {
                    // ignored
                }
            }
            return false;
        }

    }

    public class ConfigHelper
    {
        private static string outFolder;
        /// <summary>输出文件夹</summary>
        public static string OutFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(outFolder)) return outFolder;
                try
                {
                    XmlDocument doc = XmlUtils.ReadXmlFile(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");
                    XmlNodeList settingAddNodes = doc.SelectNodes("//settings//add");
                    if (settingAddNodes != null && settingAddNodes.Count > 0)
                    {
                        foreach (XmlNode addNode in settingAddNodes)
                        {
                            if (addNode.Attributes != null && "output_folder".Equals(addNode.Attributes["key"].Value))
                            {
                                if (!string.IsNullOrEmpty(addNode.Attributes["value"].Value))
                                {
                                    outFolder = addNode.Attributes["value"].Value;
                                    return outFolder;
                                }
                                else
                                {
                                    return string.Empty;
                                }

                            }
                        }
                    }
                }
                catch
                {
                    // ignored
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    string configPath = AppDomain.CurrentDomain.BaseDirectory + "Config.xml";
                    XmlDocument doc = XmlUtils.ReadXmlFile(configPath);
                    XmlNodeList settingAddNodes = doc.SelectNodes("//settings//add");
                    if (settingAddNodes != null && settingAddNodes.Count > 0)
                    {
                        foreach (XmlNode addNode in settingAddNodes)
                        {
                            if (addNode.Attributes != null && "output_folder".Equals(addNode.Attributes["key"].Value))
                            {
                                if (!value.EndsWith("\\"))
                                {
                                    outFolder = value + "\\";
                                }
                                addNode.Attributes["value"].Value = outFolder;
                                break;
                            }
                        }
                    }
                    doc.Save(configPath);
                }
                catch
                {
                    // ignored
                }
            }

        }
    }

}
