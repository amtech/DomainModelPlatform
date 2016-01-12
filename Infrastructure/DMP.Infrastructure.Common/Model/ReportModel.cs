using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DMP.Infrastructure.Common.Model
{
    /// <summary>报表模型</summary>
    public class ReportModel : ModelBase
    {

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public List<Table> Tables { get; set; }

        public ReportModel()
        {
            Tables = new List<Table>();
        }

    }
}
