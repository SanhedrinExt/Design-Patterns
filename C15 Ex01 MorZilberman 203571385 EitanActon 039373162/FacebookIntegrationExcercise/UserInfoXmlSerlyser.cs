using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace FacebookIntegrationExcercise
{
    public class MyXmlSerializer : ISerializer
    {
        public override string Serialize(Object i_ObjectToSerialize, Type i_Type)
        {
            return parseObjectToXml(i_ObjectToSerialize, i_Type);
        }

        private string parseObjectToXml(Object i_ObjectToSerialize, Type i_Type)
        {
            XmlSerializer serializer = new XmlSerializer(i_Type);
            MemoryStream memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, i_ObjectToSerialize);
            memoryStream.Position = 0;

            return new StreamReader(memoryStream).ReadToEnd();
        }

        public override Object Deserialize(Stream i_Stream, Type i_Type)
        {
            Object deserialzedObject = null;
            if (i_Stream != null)
            {
                deserialzedObject = deSerializeXml(i_Stream, i_Type);
            }
            return deserialzedObject;
        }

        private Object deSerializeXml(Stream i_Stream, Type i_Type)
        {
            XmlSerializer serializer = new XmlSerializer(i_Type);
            return serializer.Deserialize(i_Stream);
        }
    }
}
