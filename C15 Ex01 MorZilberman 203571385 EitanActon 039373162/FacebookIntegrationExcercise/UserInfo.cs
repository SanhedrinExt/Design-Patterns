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


        private string parseUserInfoToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            MemoryStream memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, GetUserInfo());
            memoryStream.Position = 0;
            string xml = new StreamReader(memoryStream).ReadToEnd();
            return xml;
        }
        
        public void SaveUserInfoAsXmlFile(string i_filePath)
        {
            using (StreamWriter file = new StreamWriter(i_filePath))
            {
                file.Write(parseUserInfoToXml());
            }
        }

        public void ReadUserInfo(string i_filePath)
        {
            
            string xml;
            
            using (FileStream file = new FileStream(i_filePath, FileMode.Open))
            {
               XmlSerializer serializer = new XmlSerializer(typeof(UserInfo)); 
                s_UserInfoSingalton = (UserInfo)serializer.Deserialize(file);
            }

           
           
        }
    }
}
