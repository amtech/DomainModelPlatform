using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;


namespace DMP.Infrastructure.ModelDesigner.Model.Elements
{
    public class TableEx : Table
    {
        [Browsable(false)]
        [XmlElement("Columns")]
        public List<IColumn> Columns { get; set; }

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

        public TableEx()
        {
            Columns = new List<IColumn>();
        }

        public IColumn FindColumn(string colName)
        {
            foreach (IColumn col in Columns)
            {
                if (col.Name == colName)
                {
                    return col;
                }
            }
            return null;
        }

        public void RemoveColumn(string colName)
        {
            foreach (IColumn col in Columns)
            {
                Columns.Remove(col);
                return;
            }
        }

    }
}
