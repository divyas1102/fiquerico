using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace FiqueRico.BL.XML
{
    public static class Serializador<T> where T : class 
    {
        public static string Serializar(ICollection<Jogo> obj)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(writer, obj);
            return writer.ToString();
        }

        public static ICollection<Jogo> Deserializar(string xml, Type tipo)
        {
            StringReader reader = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(tipo);
            return (ICollection<Jogo>)serializer.Deserialize(reader);
        }

        public static XmlDocument SerializeAsXML(T item)
        {
            XmlDocument xDoc = new XmlDocument();
            StringBuilder serializedXML = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            StringWriterWithEncoding sWriter = new StringWriterWithEncoding(serializedXML, Encoding.UTF8);

            serializer.Serialize(sWriter, item);

            xDoc.LoadXml(serializedXML.ToString());         

            return xDoc;
        }             

        public static T DeserializeFromXML(XmlDocument item)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(new StringReader(item.OuterXml)) as T;
        }
    }
}
