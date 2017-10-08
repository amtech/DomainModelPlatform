using DMP.Infrastructure.Common.Transfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.Bll.Interface
{
    /// <summary></summary>
    public interface IBll
    {
        int ModuleId { get; set; }
        RequestPackage Request { get; set; }
        ResponsePackage Response { get; set; }

        void Add();
        void Delete();
        void Modify();
        void Query();


    }
}
