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
using System.Reflection;

namespace FacebookIntegrationExcercise
{
    public sealed class UserInfo
    {
        private UserInfoDataManger m_DataManager;

        public Point Location { set; get; }
        public Size Size { set; get; }
        public bool AutoLogIn { set; get; }
        public string AccessToken { set; get; }
        public string TwitchUserName { get; set; }
        public bool AutoPostTwitchUpdates { get; set; }

        private UserInfo()
        {
            m_DataManager = new FileManager() { Serializer = new GeneralPurposeXmlSerializer() };
        }

        public void SaveUserInfo(string i_Path)
        {
            m_DataManager.SaveUserInfo(i_Path, this);
        }

        public bool LoadUserInfo(string i_filePath)
        {
            UserInfo userInfoSingleton = (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo);
            userInfoSingleton.populateUserInfo(m_DataManager.LoadUserInfo(i_filePath));

            return userInfoSingleton != null;
        }

        private void populateUserInfo(UserInfo i_UserInfo)
        {
            if (i_UserInfo != null)
            {
                foreach (PropertyInfo property in typeof(UserInfo).GetProperties())
                {
                    property.SetValue(this, property.GetValue(i_UserInfo));
                }
            }
        }
    }
}
