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
    public abstract class UserInfoDataManger
    {      
        public ISerializer Serializer { get; set; }

        public void SaveUserInfo(string i_Path, UserInfo i_UserInfo)
        {         
                string data = Serializer.Serialize(i_UserInfo, typeof(UserInfo));
                SaveData(i_Path, data);            
        }

        protected abstract void SaveData(string i_Path, string i_Data);

        public UserInfo LoadUserInfo(string i_path)
        {
            return (UserInfo)LoadData(i_path, typeof(UserInfo));           
        }

        protected abstract Object LoadData(string i_Path, Type i_Type);
    }
}
