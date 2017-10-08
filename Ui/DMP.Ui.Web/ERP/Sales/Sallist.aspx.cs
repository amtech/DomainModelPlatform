using DMP.Ui.Web.Common;
using System;

namespace DMP.Ui.Web.ERP.Sales
{
    public partial class Sallist : ListForm
    {
        public Sallist()
        {
            SourceTag = 123; 
        }

        protected override void AfterQuery()
        {    
            base.AfterQuery();
        }
    }
}