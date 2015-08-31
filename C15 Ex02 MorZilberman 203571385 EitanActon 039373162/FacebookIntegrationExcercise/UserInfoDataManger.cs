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
        public IDataManager m_DataManger = null;
        public ISerializer m_Serializer = null;

        public void SaveUserInfo(string i_Path ,UserInfo userInfo)
        {
            if(m_DataManger != null && m_Serializer != null)
            {
                string data = m_Serializer.Serialize(userInfo, typeof(UserInfo));
                m_DataManger.SaveData(i_Path, data);
            }
        }

        public UserInfo loadUserInfo(string i_path)
        {
            return (UserInfo)m_DataManger.LoadData(i_path, m_Serializer, typeof(UserInfo));           
        }
    }
}
