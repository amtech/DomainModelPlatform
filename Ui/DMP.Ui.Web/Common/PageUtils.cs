using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DMP.Ui.Web.Common
{
    public class PageUtils
    {
        public static void AddJs(Page page, string jsPath)
        {
            HtmlGenericControl jsRef = new HtmlGenericControl();
            jsRef.TagName = "script";
            jsRef.Attributes.Add("type", "text/javascript");
            jsRef.Attributes.Add("src", page.ResolveClientUrl(jsPath));
            page.Header.Controls.Add(jsRef);
        }

        public static void AddCss(Page page, string cssPath)
        {
            HtmlGenericControl myCss = new HtmlGenericControl();
            myCss.TagName = "link";
            myCss.Attributes.Add("type", "text/css");
            myCss.Attributes.Add("rel", "stylesheet");
            myCss.Attributes.Add("href", page.ResolveClientUrl(cssPath));
            page.Header.Controls.Add(myCss);
        }


    }
}