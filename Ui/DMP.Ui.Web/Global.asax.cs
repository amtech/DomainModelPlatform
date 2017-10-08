using Infrastructure.Common;
using Domain.Model;
using DMP.Ui.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Domain.Bll.Interface;

namespace DMP.Ui.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            LoadModels();
            LoadBllClass();
        }

        private void LoadModels()
        {
            string modelsFolder = Server.MapPath("~/Resources/Models");
            if (!DirectoryUtils.Exists(modelsFolder))
            {
                DirectoryUtils.Create(modelsFolder);
            }
            else
            {
                string[] moduleFolders = DirectoryUtils.GetDirectories(modelsFolder);
                if (moduleFolders != null && moduleFolders.Length > 0)
                {
                    foreach (string moduleFolder in moduleFolders)
                    {
                        string[] businessModels = DirectoryUtils.GetXmlFiles(moduleFolder);
                        StaticValue.BusinessModels = new Dictionary<string, BusinessModel>();
                        foreach (string businessModelPath in businessModels)
                        {
                            using (FileStream file = new FileStream(businessModelPath, FileMode.Open))
                            {
                                BusinessModel model = ModelUtils.DeserializeModel<BusinessModel>(file);
                                StaticValue.BusinessModels.Add(model.SourceTag.ToString() + "_" + model.DocumentType.ToString(), model);
                            }
                        }
                        string[] reportsFolders = DirectoryUtils.GetDirectories(moduleFolder, "Reports");
                        if (reportsFolders != null && reportsFolders.Length > 0)
                        {
                            string[] reportModels = DirectoryUtils.GetXmlFiles(reportsFolders[0]);
                            if (reportModels != null && reportModels.Length > 0)
                            {
                                StaticValue.ReportModels = new Dictionary<string, ReportModel>();
                                foreach (string reportModelPath in reportModels)
                                {
                                    using (FileStream file = new FileStream(reportModelPath, FileMode.Open))
                                    {
                                        ReportModel model = ModelUtils.DeserializeModel<ReportModel>(file);
                                        StaticValue.ReportModels.Add(model.SourceTag.ToString() + "_" + model.DocumentType.ToString(), model);
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        private void LoadBllClass()
        {
            StaticValue.Blls = new Dictionary<int, IBll>();

            Type[] types = Assembly.LoadFile(Server.MapPath("/bin/Domain.Bll.dll")).GetTypes();
            foreach (Type t in types)
            {
                //取类上的自定义特性
                object[] objs = t.GetCustomAttributes(typeof(ModuleAttribute), true);
                foreach (object obj in objs)
                {
                    if (t.GetInterface("IBll") != null)
                    {
                        var bll = (IBll)Activator.CreateInstance(t);
                        ModuleAttribute attr = obj as ModuleAttribute;
                        if (attr != null)
                        {
                            //attr.Id;//模块id
                            StaticValue.Blls.Add(attr.Id, bll);
                            break;
                        }
                    } 
                }

            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}