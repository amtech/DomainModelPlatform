using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace DMP.Infrastructure.Common.Xml
{
    public class XmlDocumentEx : XmlDocument
    {

        private bool isLoading = false; 

        public bool IsEditing { get; set; }

        public XmlDocumentEx()
            : base()
        {
            NodeChanged += new XmlNodeChangedEventHandler(XmlDocumentNodeEditing);
            NodeInserted += new XmlNodeChangedEventHandler(XmlDocumentNodeEditing);
            NodeRemoved += new XmlNodeChangedEventHandler(XmlDocumentNodeEditing);
        }

        public override void Load(string filename)
        {
            isLoading = true;
            if (File.Exists(filename))
            {
                base.Load(filename); 
            }
            isLoading = false;    
        }

        public override void Save(string filename)
        {
            base.Save(filename);
            IsEditing = false;
        }

        void XmlDocumentNodeEditing(object sender, XmlNodeChangedEventArgs e)
        {
            if(!isLoading)
            { 
                IsEditing = true;
            }
        }

    }
}
