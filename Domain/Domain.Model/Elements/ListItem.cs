

using System.Xml.Serialization;

namespace Domain.Model.Elements
{
    public class ListItem
    {
        [XmlAttribute("Text")]
        public string Text { get; set; }
        [XmlAttribute("Value")]
        public string Value { get; set; }
        [XmlAttribute("IsDefault")]
        public bool IsDefault { get; set; }
    }
}
