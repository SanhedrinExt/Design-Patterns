namespace FacebookIntegrationExcercise
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.listBoxNewsFeed = new System.Windows.Forms.ListBox();
            this.postBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxStayLoggedIn = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.advancedFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToTwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massRSVPEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconTwitchService = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenFacebookApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExitFacebookApp = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTwitchUpdateChecker = new System.Windows.Forms.Timer(this.components);
            this.pbUserProfilePic = new System.Windows.Forms.PictureBox();
            this.pbEventPicture = new System.Windows.Forms.PictureBox();
            this.pbFriendPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.contextMenuStripSystemTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEventPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFriendPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 34);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(90, 28);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Log In";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // listBoxNewsFeed
            // 
            this.listBoxNewsFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNewsFeed.DataSource = this.postBindingSource;
            this.listBoxNewsFeed.DisplayMember = "Message";
            this.listBoxNewsFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxNewsFeed.FormattingEnabled = true;
            this.listBoxNewsFeed.Location = new System.Drawing.Point(172, 86);
            this.listBoxNewsFeed.Name = "listBoxNewsFeed";
            this.listBoxNewsFeed.Size = new System.Drawing.Size(551, 108);
            this.listBoxNewsFeed.TabIndex = 41;
            this.listBoxNewsFeed.ValueMember = "Caption";
            // 
            // postBindingSource
            // 
            this.postBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Post);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Wall Posts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 26);
            this.label2.TabIndex = 44;
            this.label2.Text = "Friends\r\n(Click on a friend to view their picture)";
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFriends.DataSource = this.userBindingSource;
            this.listBoxFriends.DisplayMember = "Name";
            this.listBoxFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.Location = new System.Drawing.Point(12, 233);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(81, 147);
            this.listBoxFriends.TabIndex = 43;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEvents.DataSource = this.eventBindingSource;
            this.listBoxEvents.DisplayMember = "Name";
            this.listBoxEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(238, 233);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(311, 147);
            this.listBoxEvents.TabIndex = 46;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Event);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 26);
            this.label3.TabIndex = 47;
            this.label3.Text = "Events\r\n(Click on an event to view its picture)";
            // 
            // checkBoxStayLoggedIn
            // 
            this.checkBoxStayLoggedIn.AutoSize = true;
            this.checkBoxStayLoggedIn.Location = new System.Drawing.Point(108, 41);
            this.checkBoxStayLoggedIn.Name = "checkBoxStayLoggedIn";
            this.checkBoxStayLoggedIn.Size = new System.Drawing.Size(114, 17);
            this.checkBoxStayLoggedIn.TabIndex = 49;
            this.checkBoxStayLoggedIn.Text = "Keep me logged in";
            this.checkBoxStayLoggedIn.UseVisualStyleBackColor = true;
            this.checkBoxStayLoggedIn.CheckedChanged += new System.EventHandler(this.checkBoxStayLoggedIn_CheckedChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedFeaturesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(735, 24);
            this.menuStrip.TabIndex = 50;
            this.menuStrip.Text = "menuStrip1";
            // 
            // advancedFeaturesToolStripMenuItem
            // 
            this.advancedFeaturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToTwitchToolStripMenuItem,
            this.massRSVPEventsToolStripMenuItem});
            this.advancedFeaturesToolStripMenuItem.Name = "advancedFeaturesToolStripMenuItem";
            this.advancedFeaturesToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.advancedFeaturesToolStripMenuItem.Text = "Advanced Features";
            this.advancedFeaturesToolStripMenuItem.Click += new System.EventHandler(this.additionalFeaturesToolStripMenuItem_Click);
            // 
            // connectToTwitchToolStripMenuItem
            // 
            this.connectToTwitchToolStripMenuItem.Name = "connectToTwitchToolStripMenuItem";
            this.connectToTwitchToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.connectToTwitchToolStripMenuItem.Text = "Connect to Twitch";
            this.connectToTwitchToolStripMenuItem.ToolTipText = "Lets the user connect his Twitch account to enable automatic FB posts when they g" +
    "o live.";
            this.connectToTwitchToolStripMenuItem.Click += new System.EventHandler(this.connectToTwitchToolStripMenuItem_Click);
            // 
            // massRSVPEventsToolStripMenuItem
            // 
            this.massRSVPEventsToolStripMenuItem.Name = "massRSVPEventsToolStripMenuItem";
            this.massRSVPEventsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.massRSVPEventsToolStripMenuItem.Text = "Mass RSVP events";
            this.massRSVPEventsToolStripMenuItem.ToolTipText = "Fetches the list of events you haven\'t RSVPd to, and lets you mass response.";
            this.massRSVPEventsToolStripMenuItem.Click += new System.EventHandler(this.massEventRSVPToolStripMenuItem_Click);
            // 
            // notifyIconTwitchService
            // 
            this.notifyIconTwitchService.BalloonTipText = "Facebook App is still running";
            this.notifyIconTwitchService.ContextMenuStrip = this.contextMenuStripSystemTray;
            this.notifyIconTwitchService.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTwitchService.Icon")));
            this.notifyIconTwitchService.Text = "Facebook App";
            this.notifyIconTwitchService.Visible = true;
            // 
            // contextMenuStripSystemTray
            // 
            this.contextMenuStripSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenFacebookApp,
            this.toolStripMenuItemExitFacebookApp});
            this.contextMenuStripSystemTray.Name = "contextMenuStripSystemTray";
            this.contextMenuStripSystemTray.Size = new System.Drawing.Size(183, 48);
            this.contextMenuStripSystemTray.Text = "Facebook App";
            // 
            // toolStripMenuItemOpenFacebookApp
            // 
            this.toolStripMenuItemOpenFacebookApp.Name = "toolStripMenuItemOpenFacebookApp";
            this.toolStripMenuItemOpenFacebookApp.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItemOpenFacebookApp.Text = "Open Facebook App";
            this.toolStripMenuItemOpenFacebookApp.Click += new System.EventHandler(this.toolStripMenuItemOpenFacebookApp_Click);
            // 
            // toolStripMenuItemExitFacebookApp
            // 
            this.toolStripMenuItemExitFacebookApp.Name = "toolStripMenuItemExitFacebookApp";
            this.toolStripMenuItemExitFacebookApp.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItemExitFacebookApp.Text = "Exit Facebook App";
            this.toolStripMenuItemExitFacebookApp.Click += new System.EventHandler(this.toolStripMenuItemExitFacebookApp_Click);
            // 
            // timerTwitchUpdateChecker
            // 
            this.timerTwitchUpdateChecker.Enabled = true;
            this.timerTwitchUpdateChecker.Interval = 10000;
            this.timerTwitchUpdateChecker.Tick += new System.EventHandler(this.timerTwitchUpdateChecker_Tick);
            // 
            // pbUserProfilePic
            // 
            this.pbUserProfilePic.Location = new System.Drawing.Point(12, 68);
            this.pbUserProfilePic.Name = "pbUserProfilePic";
            this.pbUserProfilePic.Size = new System.Drawing.Size(151, 126);
            this.pbUserProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserProfilePic.TabIndex = 52;
            this.pbUserProfilePic.TabStop = false;
            // 
            // pbEventPicture
            // 
            this.pbEventPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEventPicture.Location = new System.Drawing.Point(555, 232);
            this.pbEventPicture.Name = "pbEventPicture";
            this.pbEventPicture.Size = new System.Drawing.Size(168, 158);
            this.pbEventPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEventPicture.TabIndex = 53;
            this.pbEventPicture.TabStop = false;
            // 
            // pbFriendPicture
            // 
            this.pbFriendPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbFriendPicture.Location = new System.Drawing.Point(99, 232);
            this.pbFriendPicture.Name = "pbFriendPicture";
            this.pbFriendPicture.Size = new System.Drawing.Size(114, 158);
            this.pbFriendPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFriendPicture.TabIndex = 54;
            this.pbFriendPicture.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 405);
            this.Controls.Add(this.pbFriendPicture);
            this.Controls.Add(this.pbEventPicture);
            this.Controls.Add(this.pbUserProfilePic);
            this.Controls.Add(this.checkBoxStayLoggedIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxFriends);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxNewsFeed);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Facebook app";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Move += new System.EventHandler(this.FormMain_Move);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripSystemTray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEventPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFriendPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listBoxNewsFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxStayLoggedIn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem advancedFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToTwitchToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconTwitchService;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSystemTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFacebookApp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExitFacebookApp;
        private System.Windows.Forms.Timer timerTwitchUpdateChecker;
        private System.Windows.Forms.ToolStripMenuItem massRSVPEventsToolStripMenuItem;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.PictureBox pbUserProfilePic;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.PictureBox pbEventPicture;
        private System.Windows.Forms.BindingSource postBindingSource;
        private System.Windows.Forms.PictureBox pbFriendPicture;
    }
}

