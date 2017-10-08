using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DMP.Infrastructure.Common
{
    public class XmlUtils
    {
        public static string Serialize(object obj)
        {
            return Serialize(obj.GetType(), obj);
        }

        public static string Serialize<T>(object obj)
        {
            return Serialize(typeof(T), obj);
        }

        public static string Serialize(Type t, object obj)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                XmlSerializer xs = new XmlSerializer(t);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (XmlTextWriter xtw = new XmlTextWriter(memoryStream, Encoding.UTF8))
                    {
                        XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
                        xns.Add("", "");
                        xs.Serialize(xtw, obj, xns);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        using (StreamReader streamReader = new StreamReader(memoryStream, Encoding.UTF8))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result.ToString();
        }

        public static T Deserialize<T>(string content)
        {
            return (T)Deserialize(typeof(T), content);
        }

        public static T Deserialize<T>(FileStream file)
        {
            byte[] content = new byte[file.Length];

            for (int i = 0; i < content.Length; i++)
            {
                content[i] = (byte)file.ReadByte();
            }

            return Deserialize<T>(Encoding.UTF8.GetString(content));
        }

        public static object Deserialize(Type t, string content)
        {
            object result = null;
            XmlSerializer xs = new XmlSerializer(t);
            result = xs.Deserialize(new StringReader(content));
            return result;
        }


        public static XmlDocument ReadXmlFile(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(FileUtils.ReadTextFile(path));
            return doc;
        }

        public static XmlDocument LoadXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }

    }

    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public void WriteXml(XmlWriter write)       // Serializer 
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            foreach (KeyValuePair<TKey, TValue> kv in this)
            {
                write.WriteStartElement("SerializableDictionary");
                write.WriteStartElement("key");
                keySerializer.Serialize(write, kv.Key, ns);
                write.WriteEndElement();
                write.WriteStartElement("value");
                valueSerializer.Serialize(write, kv.Value, ns);
                write.WriteEndElement();
                write.WriteEndElement();
            }
        }

        public void ReadXml(XmlReader reader)       // Deserializer
        {
            reader.Read();
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("SerializableDictionary");
                reader.ReadStartElement("key");
                TKey tk = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue vl = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadEndElement();
                Add(tk, vl);
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}