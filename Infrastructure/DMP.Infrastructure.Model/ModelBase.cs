using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DMP.Infrastructure.Model
{
    public abstract class ModelBase
    {
        [XmlAttribute("SourceTag")]
        public int SourceTag { set; get; }
        [XmlAttribute("DocumentType")]
        public int DocumentType { set; get; }
        [XmlAttribute("Name")]
        public string Name { set; get; }
        [XmlAttribute("DisplayName")]
        public string DisplayName { set; get; }
    }
}
