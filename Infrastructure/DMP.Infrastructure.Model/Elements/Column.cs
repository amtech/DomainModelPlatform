using DMP.Infrastructure.Model.Editer;
using DMP.Infrastructure.Model.Elements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Xml.Serialization;

namespace DMP.Infrastructure.Model
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

        [DescriptionAttribute("名称标识"), CategoryAttribute("基本属性")]
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [DescriptionAttribute("字段名"), CategoryAttribute("基本属性")]
        [XmlAttribute("FieldName")]
        public string FieldName { get; set; }

        [DescriptionAttribute("字段类型"), CategoryAttribute("基本属性")]
        [XmlAttribute("ColumnType")]
        public ColumnTypes ColumnType { get; set; }

        [DescriptionAttribute("是否主键"), CategoryAttribute("基本属性")]
        [XmlAttribute("IsKey")]
        public bool IsKey { get; set; }

        [DescriptionAttribute("是否虚字段"), CategoryAttribute("基本属性")]
        [XmlAttribute("IsVirtual")]
        public bool IsVirtual { get; set; }

        [DescriptionAttribute("是否可见"), CategoryAttribute("显示")]
        [XmlAttribute("Visible")] 
        public bool Visible { get; set; }

        [DescriptionAttribute("显示名称"), CategoryAttribute("显示")]
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [DescriptionAttribute("是否用于查询"), CategoryAttribute("查询")]
        [XmlAttribute("IsSearch")]
        public bool IsSearch { get; set; }

        [DescriptionAttribute("枚举值"), CategoryAttribute("查询")]
        [XmlElement("Items")]
        [Editor(typeof(ListItemEditer), typeof(UITypeEditor))]
        public List<ListItem> Items { get; set; }

        [DescriptionAttribute("能否多选"), CategoryAttribute("查询")]
        [XmlElement("IsMulti")] 
        public bool IsMulti { get; set; }

        


    }
}
