using Infrastructure.Common;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Domain.Model.Elements
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
        [Description("名称标识"), Category("基本属性")]
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [Description("字段名"), Category("基本属性")]
        [XmlAttribute("FieldName")]
        public string FieldName { get; set; }

        [Description("字段类型"), Category("基本属性")]
        [XmlAttribute("ColumnType")]
        public ColumnTypes ColumnType { get; set; }

        [Description("是否主键"), Category("基本属性")]
        [XmlAttribute("IsKey")]
        public bool IsKey { get; set; }

        [Description("是否虚字段"), Category("基本属性")]
        [XmlAttribute("IsVirtual")]
        public bool IsVirtual { get; set; }

        [Description("是否用于查询"), Category("基本属性")]
        [XmlAttribute("IsSearch")]
        public bool IsSearch { get; set; }

        [Description("是否展现在grid列中"), Category("基本属性"),]
        [XmlAttribute("Visible")]
        public bool Visible { get; set; }

        [Description("显示名称"), Category("基本属性")]
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [Description("选项"), Category("数据")]
        [XmlIgnore]
        public virtual NameObjectCollection<ListItem> Items { get; set; }

        [Browsable(false)]
        [XmlElement("Relationship")]
        public ColumnRelationship Relationship { get; set; }

        public Column()
        {
            Items = new NameObjectCollection<ListItem>();
        }

    }

}
