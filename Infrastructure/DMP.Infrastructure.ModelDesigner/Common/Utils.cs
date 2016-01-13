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
                XmlElement businessFunctions = doc.CreateElement("BusinessFunctions");
                rootProject.AppendChild(businessFunctions);

                //报表
                XmlElement reports = doc.CreateElement("Reports");
                rootProject.AppendChild(reports);

                //Business 
                doc.Save(fullName);

                if (Directory.Exists(projectFolder) == false)//如果不存在就创建file文件夹{
                    Directory.CreateDirectory(projectFolder);


                return fullName;
            }
            return string.Empty;
        }


        public static string SelectFolder()
        {
            FolderBrowserDialog path = new FolderBrowserDialog();

            if (path.ShowDialog() == DialogResult.OK)
            {
                return path.SelectedPath;
            }
            return string.Empty;
        }

    }
}
