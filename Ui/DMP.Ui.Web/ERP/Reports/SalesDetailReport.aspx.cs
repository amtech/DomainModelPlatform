using DMP.Infrastructure.Common.Transfer;
using DMP.Ui.Web.Common; 

namespace DMP.Ui.Web.ERP.Reports
{
    /// <summary>销售明细表</summary>
    public partial class SalesDetailReport : ReportForm
    {
        public SalesDetailReport()
        {
            SourceTag = 20001;
            DocumentType = 1;
        }

        protected override void AfterGetModelInfo(RequestPackage reqPackag, ResponsePackage rspPackage)
        {
            base.AfterGetModelInfo(reqPackag, rspPackage);
        }

        protected override void AfterAddJs()
        {
            base.AfterAddJs(); 
        }
    }
}