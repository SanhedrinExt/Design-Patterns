using FacebookIntegrationExcercise.Properties;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookIntegrationExcercise
{
    public class TwitchForFacebookProxy : ITwitchFunctionalityProvider
    {
        private NotifyIcon m_TwitchServiceNotifyIcon;

        private TwitchForFacebookProxy()
        {
            setupFacebookFunctionality();
        }

        private void setupFacebookFunctionality()
        {
            m_TwitchServiceNotifyIcon = new NotifyIcon();
            m_TwitchServiceNotifyIcon.Text = "Facebook-Twitch App";
            m_TwitchServiceNotifyIcon.Icon = Resources.FacebookIcon;
            m_TwitchServiceNotifyIcon.BalloonTipText = "A post linking to your newly started stream had been posted to your Facebook page";
            m_TwitchServiceNotifyIcon.BalloonTipTitle = "Facebook update posted!";
            m_TwitchServiceNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            m_TwitchServiceNotifyIcon.Visible = true;
        }

        public bool CheckIfChannelExists(string i_ChannelName)
        {
            return (SingletonFactory.GetSingleton(typeof(TwitchAPIWrapper)) as TwitchAPIWrapper).CheckIfChannelExists(i_ChannelName);
        }

        public bool CheckIfStreamStarted(string i_ChannelName)
        {
            bool streamStarted = false;

            if ((SingletonFactory.GetSingleton(typeof(TwitchAPIWrapper)) as TwitchAPIWrapper).CheckIfStreamStarted(i_ChannelName))
            {
                streamStarted = true;

                User loggedInUser = (SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser;
                loggedInUser.PostStatus(string.Format("I have just gone online!{0}Come watch me at:{0}{1}{2}", Environment.NewLine, TwitchAPIWrapper.TwitchBaseAddress, (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo).TwitchUserName));
                m_TwitchServiceNotifyIcon.ShowBalloonTip(1000);
            }

            return streamStarted;
        }
    }
}
