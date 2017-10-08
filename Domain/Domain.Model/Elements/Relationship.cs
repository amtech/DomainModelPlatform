using System.ComponentModel;
using DMP.Infrastructure.Common;
using System.Xml.Serialization;

namespace Domain.Model.Elements
{
    public class RelationColumn
    {
        [Description("名称标识"), Category("基本属性")]
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [Description("显示名称"), Category("基本属性")]
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }
    }

    /// <summary>字段关系信息</summary>
    public class ColumnRelationship
    {
        public ColumnRelationship()
        {
            RelationColumns = new NameObjectCollection<RelationColumn>();
        }

        [XmlAttribute("SourceTag")]
        public int SourceTag { set; get; }

        [XmlAttribute("DocumentType")]
        public int DocumentType { set; get; }

        [XmlAttribute("Name")]
        public string Name { set; get; }

        [XmlAttribute("DisplayName")]
        public string DisplayName { set; get; }

        [Browsable(false)]
        [XmlIgnore]
        public NameObjectCollection<RelationColumn> RelationColumns { get; set; }

    }



}
