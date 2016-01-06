using System.Collections.Generic;
using System.ComponentModel;

namespace DMP.Infrastructure.Common.Model
{
    public class Table
    {
        [BrowsableAttribute(false)]
        public Dictionary<string, Column> Columns { get; set; }

        [DescriptionAttribute("名称标识"), CategoryAttribute("基本属性")]
        public string Name { get; set; }

        [DescriptionAttribute("数据库表名"), CategoryAttribute("基本属性")]
        public string DataTableName { get; set; }

        [DescriptionAttribute("显示名称"), CategoryAttribute("基本属性")]
        public string DisplayName { get; set; }

        [DescriptionAttribute("是否主表"), CategoryAttribute("基本属性")]
        public bool IsMain { get; set; }

        [DescriptionAttribute("是否虚表"), CategoryAttribute("基本属性")]
        public bool IsVirtual { get; set; }

    }
}
