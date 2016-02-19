using DMP.Infrastructure.Common;
using System;

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
                    foreach(string moduleFolder in moduleFolders)
                    {

                    }
                }

            }
            //Directory.GetDirectories(Server.MapPath("/hvtimg\\"));
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