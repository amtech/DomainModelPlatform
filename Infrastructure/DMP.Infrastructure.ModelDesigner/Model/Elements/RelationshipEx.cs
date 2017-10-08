using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;


namespace DMP.Infrastructure.ModelDesigner.Model.Elements
{
    public class RelationColumn : IRelationColumn
    {

    }

    /// <summary>字段关系信息</summary>
    public class ColumnRelationshipEx : IRelationship
    {
        public ColumnRelationshipEx()
        {
            RelationColumns = new List<IRelationColumn>();
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
        [XmlElement("RelationColumns")]
        public List<IRelationColumn> RelationColumns { get; set; }

         
    }

    

}
