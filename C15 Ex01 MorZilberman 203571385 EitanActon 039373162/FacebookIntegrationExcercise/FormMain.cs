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

        private readonly object r_TwitchAutoUpdateLock = new object();

        public FormMain()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show(string.Format("Another instance of this app is already running.{0}Please close the other instance in the system tray to open a new instance", Environment.NewLine), "Multiple instances running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            InitializeComponent();
            initializeFromUserInfoFile();
        }

        private void initializeFromUserInfoFile()
        {
            if (UserInfo.Singleton.ReadUserInfoFromFile(k_UserInfoPath))
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
            startThreaded(fetchUserProfilePic);
            startThreaded(fetchUserNewsFeed);
            startThreaded(fetchUserEvents);
            startThreaded(fetchUserFriends);
            buttonLogin.Enabled = false;
        }

        private void fetchUserEvents()
        {
            FacebookObjectCollection<Event> events = m_LoggedInUser.Events;
            this.ThreadSafeControlUpdate(() => eventBindingSource.DataSource = events);
        }

        private void fetchUserNewsFeed()
        {
            FacebookObjectCollection<Post> posts = m_LoggedInUser.NewsFeed;
            this.ThreadSafeControlUpdate(() => postBindingSource.DataSource = posts);
        }

        private void fetchUserFriends()
        {
            FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
            this.ThreadSafeControlUpdate(() => userBindingSource.DataSource = friends);
        }

        private void fetchUserProfilePic()
        {
            this.ThreadSafeControlUpdate(() => pbUserProfilePic.LoadAsync(m_LoggedInUser.PictureNormalURL));
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                loginToFacebook();
            }
        }

        private void connectToTwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConnectToTwitch twitchConnect = new FormConnectToTwitch(UserInfo.Singleton.TwitchUserName, UserInfo.Singleton.AutoPostTwitchUpdates);

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

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            startThreaded(() =>
            {
                this.ThreadSafeControlUpdate(() => pbFriendPicture.LoadAsync((listBoxFriends.SelectedItem as User).PictureNormalURL));
            });
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            startThreaded(() =>
            {
                this.ThreadSafeControlUpdate(() => pbEventPicture.LoadAsync((listBoxEvents.SelectedItem as Event).PictureNormalURL));
            });
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
            if (e.CloseReason == CloseReason.UserClosing && UserInfo.Singleton.AutoPostTwitchUpdates && !string.IsNullOrEmpty(UserInfo.Singleton.TwitchUserName))
            {
                this.Visible = false;
                notifyIconTwitchService.ShowBalloonTip(1000, "Facebook App is still running", "Right click this notification icon to open or close the app", ToolTipIcon.Info);
                e.Cancel = true;
            }
            else if(e.CloseReason == CloseReason.ApplicationExitCall || !UserInfo.Singleton.AutoPostTwitchUpdates || string.IsNullOrEmpty(UserInfo.Singleton.TwitchUserName))
            {
                UserInfo.Singleton.SaveUserInfoAsXmlFile(k_UserInfoPath);
                exitApplication();
            }
        }

        private void toolStripMenuItemExitFacebookApp_Click(object sender, EventArgs e)
        {
            exitApplication();
        }

        private void exitApplication()
        {
            Environment.Exit(0);
        }

        private void toolStripMenuItemOpenFacebookApp_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void timerTwitchUpdateChecker_Tick(object sender, EventArgs e)
        {
            Thread autoUpdateThread = new Thread(new ThreadStart(AutoPostTwitchUpdate));
            autoUpdateThread.Start();
        }

        private void AutoPostTwitchUpdate()
        {
            //A lock on the entire method is ok since we don't want to post twice about the event.
            lock (r_TwitchAutoUpdateLock)
            {
                if (UserInfo.Singleton.AutoPostTwitchUpdates && !string.IsNullOrEmpty(UserInfo.Singleton.TwitchUserName))
                {
                    if (TwitchAPIWrapper.CheckIfStreamStarted(UserInfo.Singleton.TwitchUserName))
                    {
                        m_LoggedInUser.PostStatus(string.Format("I have just gone online!{0}Come watch me at:{0}{1}{2}", Environment.NewLine, TwitchAPIWrapper.TwitchBaseAddress, UserInfo.Singleton.TwitchUserName));
                        notifyIconTwitchService.ShowBalloonTip(1000, "Facebook update posted!", "A post linking to your newly started stream had been posted to your Facebook page", ToolTipIcon.Info);
                    }
                }
            }
        }

        private void massEventRSVPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.FullWithConnections);

            FormEventResponder eventResponder = new FormEventResponder(m_LoggedInUser.EventsNotYetReplied);

            if (eventResponder.ShowDialog() == DialogResult.OK)
            {
                foreach (Event selectedEvent in eventResponder.SelectedEvents)
                {
                    selectedEvent.Respond(eventResponder.SelectedRSVPStatus);
                }

                MessageBox.Show("Responded successfuly");
            }
        }

        private void startThreaded(ThreadStart i_ActionToThread)
        {
            Thread thread = new Thread(i_ActionToThread);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
