using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookIntegrationExcercise
{
    public partial class FormConnectToTwitch : Form
    {
        /// <summary>
        /// Do we want to autopost to Facebook on the user's behalf?
        /// </summary>
        public bool AutoPostFacebookUpdate
        {
            get
            {
                return checkBoxAutoPost.Checked;
            }
        }

        /// <summary>
        /// The inputted Twitch username.
        /// </summary>
        public string TwitchUserName
        {
            get
            {
                return textBoxUserName.Text;
            }
        }

        public FormConnectToTwitch(string i_UserName, bool i_AutoPost)
        {
            InitializeComponent();

            checkBoxAutoPost.Checked = i_AutoPost;
            textBoxUserName.Text = i_UserName;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!(checkBoxAutoPost.Checked && string.IsNullOrEmpty(textBoxUserName.Text)))
            {
                if (!checkBoxAutoPost.Checked || (SingletonFactory.GetSingleton(typeof(TwitchForFacebookProxy)) as TwitchForFacebookProxy).CheckIfChannelExists(textBoxUserName.Text))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(string.Format("Twitch channel named {0} doesn't exist", textBoxUserName.Text));
                }
            }
            else
            {
                MessageBox.Show("Can't enable autoconnect without specifying a channel");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
