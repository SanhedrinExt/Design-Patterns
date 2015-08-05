using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FacebookIntegrationExcercise
{
    public class UserInfo
    {
        private static UserInfo s_UserInfoSingleton = null;

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
                    s_UserInfoSingleton = new UserInfo();
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
            string xml = new StreamReader(memoryStream).ReadToEnd();
            return xml;
        }
        
        /// <summary>
        /// Save user settings to file.
        /// </summary>
        /// <param name="i_filePath">Path to save file.</param>
        public void SaveUserInfoAsXmlFile(string i_filePath)
        {
            using (StreamWriter file = new StreamWriter(i_filePath))
            {
                file.Write(parseUserInfoToXml());
            }
        }

        /// <summary>
        /// Read user settings from file.
        /// </summary>
        /// <param name="i_filePath">Path to file.</param>
        /// <returns>True if user settings exist, false otherwise.</returns>
        public bool ReadUserInfo(string i_filePath)
        {
            bool readSuccessful = false;

            if (File.Exists(i_filePath))
            {
                using (FileStream file = new FileStream(i_filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
                    s_UserInfoSingleton = (UserInfo)serializer.Deserialize(file);
                }

                readSuccessful = true;
            }

            return readSuccessful;
        }
    }
}
