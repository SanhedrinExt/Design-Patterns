using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookIntegrationExcercise
{
    interface IFacebookConnection
    {
        LoginResult Connect(string i_NonExpiredAccessToken);
        LoginResult Login(string i_AppId, params string[] i_Permissions);
        LoginResult Login(string i_AppId, string i_Permissions);
    }
}
