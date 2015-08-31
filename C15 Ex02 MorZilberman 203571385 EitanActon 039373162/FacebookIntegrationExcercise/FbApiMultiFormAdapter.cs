using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookIntegrationExcercise
{
    class FbApiMultiFormAdapter : FacebookService, IFacebookConnection
    {
        public User LoggedInUser { get; private set; }

        public new LoginResult Connect(string i_NonExpiredAccessToken)
        {
            LoginResult loginResult = FacebookService.Connect(i_NonExpiredAccessToken);
            loginUser(loginResult);

            return loginResult;
        }

        public new LoginResult Login(string i_AppId, params string[] i_Permissions)
        {
            LoginResult loginResult = FacebookService.Login(i_AppId, i_Permissions);
            loginUser(loginResult);

            return loginResult;
        }

        public new LoginResult Login(string i_AppId, string i_Permissions)
        {
            LoginResult loginResult = FacebookService.Login(i_AppId, i_Permissions);
            loginUser(loginResult);

            return loginResult;
        }

        private void loginUser(LoginResult loginResult)
        {
            if (string.IsNullOrEmpty(loginResult.ErrorMessage))
            {
                LoggedInUser = loginResult.LoggedInUser;
            }
        }
    }
}
