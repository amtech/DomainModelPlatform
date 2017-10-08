using DMP.Infrastructure.Common.Transfer;
using DMP.Infrastructure.Model;
using Newtonsoft.Json;
using System; 
using System.IO;
using System.Web.UI;
using DMP.Infrastructure.Common; 

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
                DoAction(action);
            }
            else
            {
                AddResources();
            }

        }

        #region 引用页面资源文件

        private void AddResources()
        {
            AddCss();
            AddJs();
        }

        /// <summary>添加js引用</summary>
        private void AddJs()
        {
            PageUtils.AddJs(Page, "~/Resources/Js/jquery-1.11.3.min.js");
            PageUtils.AddJs(Page, "~/Resources/Js/json2.js");
            PageUtils.AddJs(Page, "~/Resources/Js/Form/ui.form.base.js");
            AfterAddJs();
        }

        /// <summary>添加css引用</summary>
        private void AddCss()
        {
            AfterAddCss();
        }

        /// <summary>获取模型之后</summary>
        /// <remarks>用于派生类，可扩展用于：添加子类所需js</remarks> 
        protected virtual void AfterAddJs() { }

        /// <summary>获取模型之后</summary>
        /// <remarks>用于派生类，可扩展用于：添加子类所需css</remarks> 
        protected virtual void AfterAddCss() { }

        #endregion

        private void DoAction(string action)
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

        /// <summary> 获取模型信息 </summary>
        private ResponsePackage GetModelInfo(RequestPackage reqPackage)
        {
            ResponsePackage rspPackage = new ResponsePackage();
            string model = JsonConvert.SerializeObject(ModelInfo);
            rspPackage.Items.Add("model", model);
            AfterGetModelInfo(reqPackage, rspPackage);
            return rspPackage;
        }

        /// <summary>获取模型之后</summary>
        /// <remarks>用于派生类，可扩展用于：处理模型信息的自定义</remarks>
        /// <param name="reqPackag"></param>
        /// <param name="rspPackage"></param>
        protected virtual void AfterGetModelInfo(RequestPackage reqPackag, ResponsePackage rspPackage)
        {
        }

    }

    /// <summary>报表窗体</summary>
    public class ReportForm : BaseForm
    {
        public override ModelBase ModelInfo
        {
            get
            {
                return StaticValue.ReportModels[SourceTag.ToStr() + "_" + DocumentType.ToStr()];
            }
        }

        protected override void AfterAddCss()
        {
            base.AfterAddCss();
            PageUtils.AddCss(Page, "~/Resources/Css/webnewindex.css");
        }

        protected override void AfterAddJs()
        {
            base.AfterAddJs();
            PageUtils.AddJs(Page, "~/Resources/Js/JsRender/jsrender.min.js");
            PageUtils.AddJs(Page, "~/Resources/Js/BootStrap/bootstrap.min.js");
            PageUtils.AddJs(Page, "~/Resources/Js/JQuery.Plugins/jquery.flexbox.js");
            PageUtils.AddJs(Page, "~/Resources/Js/BootStrap/bootstrap-multiselect.js");
            PageUtils.AddJs(Page, "~/Resources/Js/JqGrid/jquery.jqGrid.min.js");
            PageUtils.AddJs(Page, "~/Resources/Js/JqGrid/i18n/grid.locale-cn.js");
            PageUtils.AddJs(Page, "~/Resources/Js/BootStrap/bootstrap-datepicker.js");
            PageUtils.AddJs(Page, "~/Resources/Js/BootStrap/Locales/bootstrap-datepicker.zh-CN.js"); 
            PageUtils.AddJs(Page, "~/Resources/Js/JsRender/Tmpls/ctrls.js");
            PageUtils.AddJs(Page, "~/Resources/Js/Data/base_main_data.js"); 
            PageUtils.AddJs(Page, "~/Resources/Js/Form/ui.form.report.js"); 
        }
    }
}