using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DMP.Infrastructure.Common.Xml
{
    public class XmlDocumentEx : XmlDocument
    {
        public bool IsEditing { get; set; }

        public XmlDocumentEx()
            : base()
        {
            NodeChanged += new XmlNodeChangedEventHandler(XmlDocumentNodeEditing);
            NodeInserted += new XmlNodeChangedEventHandler(XmlDocumentNodeEditing);
            NodeRemoved += new XmlNodeChangedEventHandler(XmlDocumentNodeEditing); 
        }

        void XmlDocumentNodeEditing(object sender, XmlNodeChangedEventArgs e)
        {
            IsEditing = true;
        }

    }
}
