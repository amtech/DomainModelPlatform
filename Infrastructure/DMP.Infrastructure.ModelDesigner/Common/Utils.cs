using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DMP.Infrastructure.ModelDesigner.Common
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
                string projectFolder = sfd.Folder + "\\" + sfd.ProjectName + "\\";
                string fullName = sfd.Folder + "\\" + sfd.ProjectName + ProjectFilePostfix;


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

        public static string SelectFolder()
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            if (path.ShowDialog() == DialogResult.OK)
            {
                return path.SelectedPath;
            }
            return string.Empty;
        }

        #endregion

        #region TreeNode相关

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

        #endregion

    }
}
