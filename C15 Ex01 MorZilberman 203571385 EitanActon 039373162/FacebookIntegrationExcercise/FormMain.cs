using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Threading;
using System.Diagnostics;

namespace FacebookIntegrationExcercise
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser = null;
        private const string k_UserInfoPath = "UserInfo.info";

        public FormMain()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show(string.Format("Another instance of this app is already running.{0}Please close the other instance in the system tray to open a new instance", Environment.NewLine), "Multiple instances running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            InitializeComponent();
            initializeFromUserInfoFile();
        }

        private void initializeFromUserInfoFile()
        {
            if (UserInfo.Singleton.ReadUserInfo(k_UserInfoPath))
            {
                this.Location = UserInfo.Singleton.Location;
                this.Size = UserInfo.Singleton.Size;
                this.checkBoxStayLoggedIn.Checked = UserInfo.Singleton.AutoLogIn;

                if (checkBoxStayLoggedIn.Checked)
                {
                    try
                    {
                        LoginResult loginResult = FacebookService.Connect(UserInfo.Singleton.AccessToken);

                        if (string.IsNullOrEmpty(loginResult.AccessToken))
                        {
                            MessageBox.Show(string.Format("Error logging into Facebook!{0}The error returned was:{0}{1}", Environment.NewLine, loginResult.ErrorMessage), "Error logging in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            initUserInfo(loginResult.LoggedInUser);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(string.Format("Error logging in!{0}The error returned was:{0}{1}", Environment.NewLine, exception.Message), "Net error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void loginToFacebook()
        {
            try
            {
                LoginResult loginResult = FacebookService.Login("1519758448246535", new string[] { "public_profile", "email", "user_friends", "user_posts", "publish_actions", "user_actions.news", "user_events", "rsvp_event" });

                if (!string.IsNullOrEmpty(loginResult.ErrorMessage))
                {
                    MessageBox.Show(string.Format("Error logging into Facebook!{0}The error returned was:{0}{1}", Environment.NewLine, loginResult.ErrorMessage), "Error logging in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    UserInfo.Singleton.AccessToken = loginResult.AccessToken;
                    initUserInfo(loginResult.LoggedInUser);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error logging in!{0}The error returned was:{0}{1}", Environment.NewLine, exception.Message), "Net error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initUserInfo(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;
            fetchUserInfo();
            buttonLogin.Enabled = false;
        }

        private void fetchUserInfo()
        {
            fetchUserProfilePic();
            fetchUserNewsFeed();
            fetchUserFriends();
            fetchUserEvents();
        }

        private void fetchUserEvents()
        {
            listBoxEvents.DisplayMember = "Name";

            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                listBoxEvents.Items.Add(fbEvent);
            }
        }

        private void fetchUserNewsFeed()
        {
            foreach (Post post in m_LoggedInUser.NewsFeed)
            {
                if (!string.IsNullOrEmpty(post.From.Name) && !string.IsNullOrEmpty(post.Message))
                {
                    listBoxNewsFeed.Items.Add(string.Format("Posted by: {0}", post.From.Name));
                    listBoxNewsFeed.Items.Add(post.Message);
                    listBoxNewsFeed.Items.Add(" ");
                }
            }
        }

        private void fetchUserFriends()
        {
            listBoxFriends.DisplayMember = "Name";

            foreach (User user in m_LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(user);
            }
        }

        private void fetchUserProfilePic()
        {
            pbUserProfilePic.LoadAsync(m_LoggedInUser.PictureNormalURL);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                loginToFacebook();
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedItem != null)
            {
                User friend = listBoxFriends.SelectedItem as User;
                pbFriendPicture.LoadAsync(friend.PictureNormalURL);
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem != null)
            {
                Event fbEvent = listBoxEvents.SelectedItem as Event;
                pbEventPic.LoadAsync(fbEvent.PictureNormalURL);
            }
        }

        private void connectToTwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToTwitch twitchConnect = new ConnectToTwitch(UserInfo.Singleton.TwitchUserName, UserInfo.Singleton.AutoPostTwitchUpdates);

            if (twitchConnect.ShowDialog() == DialogResult.OK)
            {
                UserInfo.Singleton.TwitchUserName = twitchConnect.TwitchUserName;
                UserInfo.Singleton.AutoPostTwitchUpdates = twitchConnect.AutoPostFacebookUpdate;
            }
        }

        private void additionalFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                MessageBox.Show("Please log in to use advanced features!", "Not logged in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                advancedFeaturesToolStripMenuItem.HideDropDown();
            }
        }

        private void FormMain_Move(object sender, EventArgs e)
        {
            UserInfo.Singleton.Location = this.Location;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            UserInfo.Singleton.Size = this.Size;
        }

        private void checkBoxStayLoggedIn_CheckedChanged(object sender, EventArgs e)
        {
            UserInfo.Singleton.AutoLogIn = checkBoxStayLoggedIn.Checked;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserInfo.Singleton.AutoPostTwitchUpdates && !string.IsNullOrEmpty(UserInfo.Singleton.TwitchUserName))
            {
                this.Visible = false;
                notifyIconTwitchService.ShowBalloonTip(1000, "Facebook App is still running", "Right click this notification icon to open or close the app", ToolTipIcon.Info);
                e.Cancel = true;
            }
            else
            {
                UserInfo.Singleton.SaveUserInfoAsXmlFile(k_UserInfoPath);
            }
        }

        private void toolStripMenuItemExitFacebookApp_Click(object sender, EventArgs e)
        {
            UserInfo.Singleton.SaveUserInfoAsXmlFile(k_UserInfoPath);
            Environment.Exit(0);
        }

        private void toolStripMenuItemOpenFacebookApp_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void timerTwitchUpdateChecker_Tick(object sender, EventArgs e)
        {
            if (UserInfo.Singleton.AutoPostTwitchUpdates && !string.IsNullOrEmpty(UserInfo.Singleton.TwitchUserName))
            {
                try
                {
                    if (TwitchAPIWrapper.CheckIfStreamStarted(UserInfo.Singleton.TwitchUserName))
                    {
                        m_LoggedInUser.PostStatus(string.Format("I have just gone online!{0}Come watch me at:{0}{1}{2}", Environment.NewLine, TwitchAPIWrapper.TwitchBaseAddress, UserInfo.Singleton.TwitchUserName));
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("Error logging in!{0}The error returned was:{0}{1}", Environment.NewLine, exception.Message), "Net error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void unsubscribeInactiveEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_LoggedInUser.ReFetch();
            EventResponder eventResponder = new EventResponder(m_LoggedInUser.EventsNotYetReplied);

            if (eventResponder.ShowDialog() == DialogResult.OK)
            {
                foreach (Event selectedEvent in eventResponder.SelectedEvents)
                {
                    selectedEvent.Respond(eventResponder.SelectedRSVPStatus);
                }

                MessageBox.Show("Responded successfuly");
            }
        }
    }
}
