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
    public partial class ConnectToTwitch : Form
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

        public ConnectToTwitch(string i_UserName, bool i_AutoPost)
        {
            InitializeComponent();

            checkBoxAutoPost.Checked = i_AutoPost;
            textBoxUserName.Text = i_UserName;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
