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
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginResult loginResult = FacebookService.Login("1519758448246535", new string[] { "public_profile", "email", "user_friends" });

            if (loginResult.ErrorMessage != string.Empty)
            {
                MessageBox.Show(string.Format("Error logging into Facebook!{0}The error returned was:{0}{1}", Environment.NewLine, loginResult.ErrorMessage), "Error logging in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
