using System.ComponentModel;
using Infrastructure.Common;
using System.Xml.Serialization;


namespace Domain.Model.Elements
{
    public class Table
    {
        [Browsable(false)]
        [XmlElement("Columns")]
        [XmlIgnore]
        public NameObjectCollection<Column> Columns { get; set; }

        [Description("名称标识"), Category("基本属性")]
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [Description("数据库表名"), Category("基本属性")]
        [XmlAttribute("DataTableName")]
        public string DataTableName { get; set; }

        [Description("显示名称"), Category("基本属性")]
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [Description("是否主表"), Category("基本属性")]
        [XmlAttribute("IsMain")]
        public bool IsMain { get; set; }

        [Description("是否虚表"), Category("基本属性")]
        [XmlAttribute("IsVirtual")]
        public bool IsVirtual { get; set; }

        public Table()
        {
            Columns = new NameObjectCollection<Column>();
        }
    }
}
