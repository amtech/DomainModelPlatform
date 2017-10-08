using System.ComponentModel;
using Infrastructure.Common;
using Domain.Model.Elements; 
using System.Xml.Serialization;

namespace Domain.Model
{
    /// <summary>数据源模型</summary>  
    public class DataModel
    {
        public DataModel()
        {
            Tables = new NameObjectCollection<Table>();
        }
        [XmlAttribute("SourceTag")]
        public int SourceTag { set; get; }
        [XmlAttribute("DocumentType")]
        public int DocumentType { set; get; }
        [XmlAttribute("Name")]
        public string Name { set; get; }
        [XmlAttribute("DisplayName")]
        public string DisplayName { set; get; }

        [Browsable(false), DefaultValue(false)]
        [XmlIgnore]
        public NameObjectCollection<Table> Tables { get; set; }

    }
}



