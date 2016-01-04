using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.Common.Model
{
    /// <summary>报表模型</summary>
    public class ReportModel : ModelBase
    {
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public Dictionary<string, Table> Tables { get; set; }
    }
}
