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

        private void SaveDataToFile(string i_filePath, string i_Data)
        {
            using (StreamWriter file = new StreamWriter(i_filePath))
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

        public override Object LoadData(string i_path,ISerializer i_serialzer,Type type)
        {
            return ReadFromFile(i_path, i_serialzer, type);
        }

        private Object ReadFromFile(string i_filePath, ISerializer i_serialzer, Type type)
        {
            Object deserializedObject = null;
            FileStream file;
            if (File.Exists(i_filePath))
            {
                try
                {
                    using (file = new FileStream(i_filePath, FileMode.Open))
                    {
                       deserializedObject = i_serialzer.Deserialize(file, type);
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
