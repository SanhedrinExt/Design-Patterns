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
    public sealed class UserInfo
    {
        private static UserInfo s_UserInfoSingleton = null;

        private static readonly object sr_SingletonCreationLock = new object();

        public Point Location { set; get; }
        public Size Size { set; get; }
        public bool AutoLogIn { set; get; }
        public string AccessToken { set; get; }
        public string TwitchUserName { get; set; }
        public bool AutoPostTwitchUpdates { get; set; }

        private UserInfo()
        {
        }

        /// <summary>
        /// Gets the singleton instance of the userinfo.
        /// </summary>
        public static UserInfo Singleton
        {
            get
            {
                if (s_UserInfoSingleton == null)
                {
                    lock (sr_SingletonCreationLock)
                    {
                        if (s_UserInfoSingleton == null)
                        {
                            s_UserInfoSingleton = new UserInfo();
                        }
                    }
                }

                return s_UserInfoSingleton;
            }
        }


        private string parseUserInfoToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            MemoryStream memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, Singleton);
            memoryStream.Position = 0;

            return new StreamReader(memoryStream).ReadToEnd();
        }
        
        /// <summary>
        /// Save user settings to file.
        /// </summary>
        /// <param name="i_filePath">Path to save file.</param>
        public void SaveUserInfoAsXmlFile(string i_filePath)
        {
            using (StreamWriter file = new StreamWriter(i_filePath))
            {
                try
                {
                    file.Write(parseUserInfoToXml());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("Error saving to file!{0}The error returned:{0}{1}", Environment.NewLine, exception.Message));
                }
            }
        }

        /// <summary>
        /// Read user settings from file.
        /// </summary>
        /// <param name="i_filePath">Path to file.</param>
        /// <returns>True if user settings exist, false otherwise.</returns>
        public bool ReadUserInfoFromFile(string i_filePath)
        {
            bool readSuccessful = false;

            if (File.Exists(i_filePath))
            {
                try
                {
                    using (FileStream file = new FileStream(i_filePath, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
                        s_UserInfoSingleton = (UserInfo)serializer.Deserialize(file);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("Error loading from file!{0}The error returned:{0}{1}", Environment.NewLine, exception.Message));
                }

                readSuccessful = true;
            }

            return readSuccessful;
        }
    }
}
