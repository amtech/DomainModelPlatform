using DMP.Infrastructure.Common.Model;
using System.Web.UI;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Web.UI.HtmlControls;
using DMP.Infrastructure.Common.Transfer;

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
            string action = Request["action"] ?? string.Empty;
            if (!string.IsNullOrEmpty(action))
            {
                RequestPackage reqPackage = JsonConvert.DeserializeObject<RequestPackage>(
                                                new StreamReader(Request.InputStream).ReadToEnd());
                ResponsePackage rspPackage = null;
                switch (action)
                {
                    case "get_model":
                        rspPackage = GetModelInfo(reqPackage);
                        break;
                }

                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.Write(JsonConvert.SerializeObject(rspPackage));
                Response.End();
            }
            else
            {
                AddJs("~/Resources/Js/jquery-1.11.3.min.js");
                AddJs("~/Resources/Js/BaseForm.js");
            }

        }

        /// <summary> 获取模型信息 </summary>
        private ResponsePackage GetModelInfo(RequestPackage reqPackage)
        {
            ResponsePackage rspPackage = new ResponsePackage();
            AfterGetModelInfo(reqPackage, rspPackage);
            return rspPackage;
        }

        protected virtual void AfterGetModelInfo(RequestPackage reqPackag, ResponsePackage rspPackage)
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