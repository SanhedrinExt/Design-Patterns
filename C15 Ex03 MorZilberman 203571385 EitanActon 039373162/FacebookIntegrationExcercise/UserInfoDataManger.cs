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
    public class UserInfoDataManger
    {
        public IDataManager DataManager { get; set; }
        public ISerializer Serializer { get; set; }

        public void SaveUserInfo(string i_Path, UserInfo i_UserInfo)
        {
            if(DataManager != null && Serializer != null)
            {
                string data = Serializer.Serialize(i_UserInfo, typeof(UserInfo));
                DataManager.SaveData(i_Path, data);
            }
        }

        public UserInfo LoadUserInfo(string i_path)
        {
            return (UserInfo)DataManager.LoadData(i_path, Serializer, typeof(UserInfo));           
        }
    }
}
