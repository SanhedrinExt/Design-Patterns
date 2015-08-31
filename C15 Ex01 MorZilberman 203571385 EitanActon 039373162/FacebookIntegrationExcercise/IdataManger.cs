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
    public abstract class IDataManager
    {
        public abstract void SaveData(string i_Path, string i_Data);

        public abstract Object LoadData(string i_path, ISerializer i_serialzer, Type type);

    }
}
