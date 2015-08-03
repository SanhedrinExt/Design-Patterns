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

namespace FacebookIntegrationExcercise
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void loginAndInit()
        {
            if (m_LoggedInUser == null)
            {
                LoginResult loginResult = FacebookService.Login("1519758448246535", new string[] { "public_profile", "email", "user_friends", "user_posts", "publish_actions", "user_actions.news", "user_events"});

                if (!string.IsNullOrEmpty(loginResult.ErrorMessage))
                {
                    MessageBox.Show(string.Format("Error logging into Facebook!{0}The error returned was:{0}{1}", Environment.NewLine, loginResult.ErrorMessage), "Error logging in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    m_LoggedInUser = loginResult.LoggedInUser;
                    fetchUserInfo();
                }
            }
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
            pbUserProfilePic.ImageLocation = m_LoggedInUser.PictureNormalURL;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedItem != null)
            {
                User friend = listBoxFriends.SelectedItem as User;
                pbFriendPicture.ImageLocation = friend.PictureNormalURL;
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem != null)
            {
                Event fbEvent = listBoxEvents.SelectedItem as Event;
                pbEventPic.ImageLocation = fbEvent.PictureNormalURL;
            }
        }
    }
}
