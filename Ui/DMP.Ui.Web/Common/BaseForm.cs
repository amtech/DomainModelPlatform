using System;
using System.IO;
using System.Web.UI;
using System.Xml;
using Infrastructure.Common;
using Infrastructure.Common.Transfer;
using Domain.Model;
using Newtonsoft.Json;

namespace DMP.Ui.Web.Common
{
    /// <summary>窗体基类</summary>
    public abstract class BaseForm<T> : Page where T : DataModel
    {
        public int SourceTag;
        public int DocumentType;

        public abstract T ModelInfo { get; }

        private void Page_Load(object sender, EventArgs e)
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
                default:
                    rspPackage = DoOtherAction(reqPackage);
                    break;
            }

            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(rspPackage));
            Response.End();
        }

        /// <summary>由子类完成基类不实现的action</summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected abstract ResponsePackage DoOtherAction(RequestPackage request);

        /// <summary> 获取模型信息 </summary>
        private ResponsePackage GetModelInfo(RequestPackage reqPackage)
        {
            ResponsePackage rspPackage = new ResponsePackage();
            string model = ModelUtils.SerializeJson<T>(ModelInfo);
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

    /// <summary>列表页面</summary>
    public class ListForm : BaseForm<BusinessModel>
    {
        public override BusinessModel ModelInfo
        {
            get
            {
                throw new NotImplementedException();
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

        private void Query()
        {
            if (StaticValue.Blls.ContainsKey(this.SourceTag))
            {
                StaticValue.Blls[SourceTag].Query();
            }
            AfterQuery();
        }

        protected virtual void AfterQuery() { }

        protected override ResponsePackage DoOtherAction(RequestPackage request)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>单据页面</summary>
    public class DocumentForm : BaseForm<BusinessModel>
    {
        public override BusinessModel ModelInfo
        {
            get
            {
                throw new NotImplementedException();
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

        protected void Add()
        { }

        protected void Save()
        { }

        protected void Delete()
        { }

        protected override ResponsePackage DoOtherAction(RequestPackage request)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>报表页面</summary>
    public class ReportForm : BaseForm<ReportModel>
    {
        public override ReportModel ModelInfo
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

        protected override ResponsePackage DoOtherAction(RequestPackage request)
        {
            throw new NotImplementedException();
        }

        protected void Query()
        { }

    }
}