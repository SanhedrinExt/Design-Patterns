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
    public class GeneralPurposeXmlSerializer : ISerializer
    {
        public override string Serialize(object i_ObjectToSerialize, Type i_Type)
        {
            return parseObjectToXml(i_ObjectToSerialize, i_Type);
        }

        private string parseObjectToXml(object i_ObjectToSerialize, Type i_Type)
        {
            XmlSerializer serializer = new XmlSerializer(i_Type);
            MemoryStream memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, i_ObjectToSerialize);
            memoryStream.Position = 0;

            return new StreamReader(memoryStream).ReadToEnd();
        }

        public override object Deserialize(Stream i_Stream, Type i_Type)
        {
            object deserializedObject = null;

            if (i_Stream != null)
            {
                deserializedObject = DeserializeXml(i_Stream, i_Type);
            }

            return deserializedObject;
        }

        private object DeserializeXml(Stream i_Stream, Type i_Type)
        {
            XmlSerializer serializer = new XmlSerializer(i_Type);

            return serializer.Deserialize(i_Stream);
        }
    }
}
