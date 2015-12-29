using DMP.Infrastructure.Common.Model;
using System.Web.UI;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Web.UI.HtmlControls;

namespace DMP.Ui.Web.Common
{
    /// <summary>窗体基类</summary>
    public abstract class BaseForm : Page
    {
        public int SourceTag;
        public int DocumentType;

        public abstract ModelBase ModelInfo { get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //

            string action = Request["action"] ?? string.Empty;
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "get_model":
                        object p = JsonConvert.DeserializeObject(new StreamReader(Request.InputStream).ReadToEnd());
                        GetModelInfo();
                        break;
                }
            }
            else
            {
                AddJs("~/Resources/Js/jquery-1.11.3.min.js");
                AddJs("~/Resources/Js/BaseForm.js");
            }
           
        }

        /// <summary> 获取模型信息 </summary>
        private void GetModelInfo()
        {
            AfterGetModelInfo();
        }

        protected virtual void AfterGetModelInfo()
        {
        }

        /// <summary>添加js引用</summary>
        /// <param name="jsPath"></param>
        protected void AddJs(string jsPath)
        {
            HtmlGenericControl jsRef = new HtmlGenericControl(); 
            jsRef.TagName = "script"; 
            jsRef.Attributes.Add("type", "text/javascript"); 
            jsRef.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl(jsPath)));
            Page.Header.Controls.Add(jsRef);
        }

        /// <summary>添加css引用</summary>
        /// <param name="cssPath"></param>
        protected void AddCss(string cssPath)
        {
            HtmlGenericControl myCss = new HtmlGenericControl(); 
            myCss.TagName = "link"; 
            myCss.Attributes.Add("type", "text/css"); 
            myCss.Attributes.Add("rel", "stylesheet"); 
            myCss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl(cssPath))); 
            Page.Header.Controls.AddAt(0, myCss);
        }


    }

    /// <summary>报表窗体</summary>
    public class ReportForm : BaseForm
    {

        public override ModelBase ModelInfo
        {
            get
            {
                return new ReportModel();
            }
        }
    }
}