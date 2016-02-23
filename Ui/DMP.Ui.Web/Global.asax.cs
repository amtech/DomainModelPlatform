using DMP.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DMP.Infrastructure.Common.Model;
using DMP.Ui.Web.Common;

namespace DMP.Ui.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
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
                            BusinessModel model = XmlUtils.DeserializeFromFile<BusinessModel>(businessModelPath);
                            StaticValue.BusinessModels.Add(model.SourceTag.ToString() + "_" + model.DocumentType.ToString(), model);
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
                                    ReportModel model = XmlUtils.DeserializeFromFile<ReportModel>(reportModelPath);
                                    StaticValue.ReportModels.Add(model.SourceTag.ToString() + "_" + model.DocumentType.ToString(), model);
                                }
                            } 
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