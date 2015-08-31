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

        private UserInfoDataManger m_DataManger;

        public Point Location { set; get; }
        public Size Size { set; get; }
        public bool AutoLogIn { set; get; }
        public string AccessToken { set; get; }
        public string TwitchUserName { get; set; }
        public bool AutoPostTwitchUpdates { get; set; }

        private UserInfo()
        {
            m_DataManger = new UserInfoDataManger() { m_DataManger = new FileManager(), m_Serializer = new MyXmlSerializer() };
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
        public void SaveUserInfo(string i_Path)
        {
            m_DataManger.SaveUserInfo(i_Path, this);
        }

        public bool LoadUserInfo(string i_filePath)
        {

            s_UserInfoSingleton = m_DataManger.loadUserInfo(i_filePath);

            return s_UserInfoSingleton != null;
        }
    }
}
