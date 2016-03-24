using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DMP.Infrastructure.Model
{
    public class Table
    {
        [BrowsableAttribute(false)]
        [XmlElement("Columns")]
        public List<Column> Columns { get; set; }

        [DescriptionAttribute("名称标识"), CategoryAttribute("基本属性")]
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [DescriptionAttribute("数据库表名"), CategoryAttribute("基本属性")]
        [XmlAttribute("DataTableName")]
        public string DataTableName { get; set; }

        [DescriptionAttribute("显示名称"), CategoryAttribute("基本属性")]
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [DescriptionAttribute("是否主表"), CategoryAttribute("基本属性")]
        [XmlAttribute("IsMain")]
        public bool IsMain { get; set; }

        [DescriptionAttribute("是否虚表"), CategoryAttribute("基本属性")]
        [XmlAttribute("IsVirtual")]
        public bool IsVirtual { get; set; }

        public Table()
        {
            Columns = new List<Column>();
        }

        public Column FindColumn(string colName)
        {
            foreach (Column col in Columns)
            {
                if (col.Name == colName)
                {
                    return col;
                }
            }
            return null;
        }

    }
}
