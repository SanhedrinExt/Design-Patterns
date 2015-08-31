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
    public abstract class ISerializer
    {
        public abstract string Serialize(object i_ObjectToSerialize, Type i_Type);

        public abstract object Deserialize(Stream i_Stream, Type i_Type);
    }
}
