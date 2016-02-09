using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DMP.Infrastructure.Common.Model
{
    /// <summary>数据源模型</summary>
    public class DataModel : ModelBase
    {
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public List<Table> Tables { get; set; }

        public Table FindTable(string tableName)
        {
            foreach (Table tbl in Tables)
            {
                if (tbl.Name == tableName)
                { return tbl; }
            }
            return null;
        }

    }
}
