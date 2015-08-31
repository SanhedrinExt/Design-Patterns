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
            UserInfo userInfoSingleton = (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo);
            if (userInfoSingleton.LoadUserInfo(k_UserInfoPath))
            {
                this.Location = userInfoSingleton.Location;
                this.Size = userInfoSingleton.Size;
                this.checkBoxStayLoggedIn.Checked = userInfoSingleton.AutoLogIn;

                if (checkBoxStayLoggedIn.Checked)
                {
                    try
                    {
                        IFacebookConnection facebookConnection = SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter;
                        LoginResult loginResult = facebookConnection.Connect(userInfoSingleton.AccessToken);

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
                IFacebookConnection facebookConnection = SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter;
                LoginResult loginResult = facebookConnection.Login("1519758448246535", new string[] { "public_profile", "email", "user_friends", "user_posts", "publish_actions", "user_actions.news", "user_events", "rsvp_event" });

                if (!string.IsNullOrEmpty(loginResult.ErrorMessage))
                {
                    MessageBox.Show(string.Format("Error logging into Facebook!{0}The error returned was:{0}{1}", Environment.NewLine, loginResult.ErrorMessage), "Error logging in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo).AccessToken = loginResult.AccessToken;
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
            startThreaded(fetchUserProfilePic);
            startThreaded(fetchUserNewsFeed);
            startThreaded(fetchUserEvents);
            startThreaded(fetchUserFriends);
            buttonLogin.Enabled = false;
        }

        private void fetchUserEvents()
        {
            FacebookObjectCollection<Event> events = (SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser.Events;
            this.ThreadSafeControlUpdate(() => eventBindingSource.DataSource = events);
        }

        private void fetchUserNewsFeed()
        {
            FacebookObjectCollection<Post> posts = (SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser.NewsFeed;
            this.ThreadSafeControlUpdate(() => postBindingSource.DataSource = posts);
        }

        private void fetchUserFriends()
        {
            FacebookObjectCollection<User> friends = (SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser.Friends;
            this.ThreadSafeControlUpdate(() => userBindingSource.DataSource = friends);
        }

        private void fetchUserProfilePic()
        {
            this.ThreadSafeControlUpdate(() => pbUserProfilePic.LoadAsync((SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser.PictureNormalURL));
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if ((SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser == null)
            {
                loginToFacebook();
            }
        }

        private void connectToTwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo userInfoSingleton = SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo;
            FormConnectToTwitch twitchConnect = new FormConnectToTwitch(userInfoSingleton.TwitchUserName, userInfoSingleton.AutoPostTwitchUpdates);

            if (twitchConnect.ShowDialog() == DialogResult.OK)
            {
                userInfoSingleton.TwitchUserName = twitchConnect.TwitchUserName;
                userInfoSingleton.AutoPostTwitchUpdates = twitchConnect.AutoPostFacebookUpdate;
            }
        }

        private void additionalFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser == null)
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
            (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo).Location = this.Location;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo).Size = this.Size;
        }

        private void checkBoxStayLoggedIn_CheckedChanged(object sender, EventArgs e)
        {
            (SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo).AutoLogIn = checkBoxStayLoggedIn.Checked;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserInfo userInfoSingleton = SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo;

            if (e.CloseReason == CloseReason.UserClosing && userInfoSingleton.AutoPostTwitchUpdates && !string.IsNullOrEmpty(userInfoSingleton.TwitchUserName))
            {
                this.Visible = false;
                notifyIconTwitchService.ShowBalloonTip(1000, "Facebook App is still running", "Right click this notification icon to open or close the app", ToolTipIcon.Info);
                e.Cancel = true;
            }
            else if(e.CloseReason == CloseReason.ApplicationExitCall || !userInfoSingleton.AutoPostTwitchUpdates || string.IsNullOrEmpty(userInfoSingleton.TwitchUserName))
            {
                userInfoSingleton.SaveUserInfo(k_UserInfoPath);
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
            UserInfo userInfoSingleton = SingletonFactory.GetSingleton(typeof(UserInfo)) as UserInfo;

            //A lock on the entire method is ok since we don't want to post twice about the event.
            lock (r_TwitchAutoUpdateLock)
            {
                if (userInfoSingleton.AutoPostTwitchUpdates && !string.IsNullOrEmpty(userInfoSingleton.TwitchUserName))
                {
                    (SingletonFactory.GetSingleton(typeof(TwitchForFacebookProxy)) as TwitchForFacebookProxy).CheckIfStreamStarted(userInfoSingleton.TwitchUserName);
                }
            }
        }

        private void massEventRSVPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.FullWithConnections);

            FormEventResponder eventResponder = new FormEventResponder((SingletonFactory.GetSingleton(typeof(FbApiMultiFormAdapter)) as FbApiMultiFormAdapter).LoggedInUser.EventsNotYetReplied);

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
