using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.Common.Model
{

    public enum ColumnTypes
    {
        /// <summary>文本</summary>
        String,
        /// <summary>整型</summary>
        Int,
        /// <summary>布尔</summary>
        Bool,
        /// <summary>小数</summary>
        Decimal,
        /// <summary>日期</summary>
        Date
    }

    public class Column
    {
        [BrowsableAttribute(false)]
        public Dictionary<string, Column> Columns { get; set; }

        [DescriptionAttribute("名称标识"), CategoryAttribute("基本属性")]
        public string Name { get; set; }

        [DescriptionAttribute("字段名"), CategoryAttribute("基本属性")]
        public string FieldName { get; set; }

        [DescriptionAttribute("字段类型"), CategoryAttribute("基本属性")]
        public ColumnTypes ColumnType { get; set; }

        [DescriptionAttribute("显示名称"), CategoryAttribute("基本属性")]
        public string DisplayName { get; set; }

        [DescriptionAttribute("是否主键"), CategoryAttribute("基本属性")]
        public bool IsKey { get; set; }

        [DescriptionAttribute("是否虚字段"), CategoryAttribute("基本属性")]
        public bool IsVirtual { get; set; }

        [DescriptionAttribute("是否用于查询"), CategoryAttribute("基本属性")]
        public bool IsSearch { get; set; }
    }
}
