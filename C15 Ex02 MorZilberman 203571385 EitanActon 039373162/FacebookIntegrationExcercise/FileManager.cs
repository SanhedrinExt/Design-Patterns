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
    public class FileManager : IDataManager
    {
        public override void SaveData(string i_Path, string i_Data)
        {
            SaveDataToFile(i_Path, i_Data);
        }

        private void SaveDataToFile(string i_FilePath, string i_Data)
        {
            using (StreamWriter file = new StreamWriter(i_FilePath))
            {
                try
                {
                    file.Write(i_Data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("Error saving to file!{0}The error returned:{0}{1}", Environment.NewLine, exception.Message));
                }
            }
        }

        public override Object LoadData(string i_Path,ISerializer i_Serialzer,Type i_Type)
        {
            return ReadFromFile(i_Path, i_Serialzer, i_Type);
        }

        private Object ReadFromFile(string i_FilePath, ISerializer i_Serialzer, Type i_Type)
        {
            object deserializedObject = null;
            FileStream file;

            if (File.Exists(i_FilePath))
            {
                try
                {
                    using (file = new FileStream(i_FilePath, FileMode.Open))
                    {
                       deserializedObject = i_Serialzer.Deserialize(file, i_Type);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("Error loading from file!{0}The error returned:{0}{1}", Environment.NewLine, exception.Message));
                }
            }

            return deserializedObject;
        }
    }
}
