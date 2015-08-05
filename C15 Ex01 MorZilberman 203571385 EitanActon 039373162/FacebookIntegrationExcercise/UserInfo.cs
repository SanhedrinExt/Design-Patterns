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
        private static UserInfo s_UserInfoSingalton = null;

        private UserInfo(){}

        public static UserInfo GetUserInfo()
        {
            if(s_UserInfoSingalton == null)
            {
                s_UserInfoSingalton = new UserInfo();
            }
            return s_UserInfoSingalton;
        }

        public Point Location { set; get; }
        public Size Size { set; get; }
        public bool AutoLogIn { set; get; }
        public string AccessToken { set; get; }


        private string ParseUuserInfoToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            MemoryStream memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, GetUserInfo());
            memoryStream.Position = 0;
            string xml = new StreamReader(memoryStream).ReadToEnd();
            return xml;
        }
        
        public void saveUserInfoAsXmlFile(string i_filePath)
        {
            string path = string.Format("{0}{1}{2}", Environment.CurrentDirectory, Path.DirectorySeparatorChar, i_filePath);

            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(ParseUuserInfoToXml());
            }
            ReadUserInfo(i_filePath);
        }

        public void ReadUserInfo(string i_filePath)
        {
            string xml;
            string path = string.Format("{0}{1}{2}", Environment.CurrentDirectory, Path.DirectorySeparatorChar, i_filePath);
            using (StreamReader file = new StreamReader(path))
            {
                xml = file.ReadToEnd();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            MemoryStream memoryStream = new MemoryStream();

        }
    }
}
