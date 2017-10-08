using Infrastructure.Common;
using Infrastructure.Common.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Bll.Erp.Sales
{
    [Module(Id = 123)]
    public class SalesBll : BaseBll
    {
        public SalesBll()
        {
            Request = new RequestPackage();
            Response = new ResponsePackage();
        }
    }
}
