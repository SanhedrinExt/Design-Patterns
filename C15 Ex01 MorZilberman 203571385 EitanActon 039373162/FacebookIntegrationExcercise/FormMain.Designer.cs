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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.pbUserProfilePic = new System.Windows.Forms.PictureBox();
            this.listBoxNewsFeed = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.pbFriendPicture = new System.Windows.Forms.PictureBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbEventPic = new System.Windows.Forms.PictureBox();
            this.checkBoxStayLoggedIn = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.additionalFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToTwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFriendPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEventPic)).BeginInit();
            this.menuStrip.SuspendLayout();
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
            // pbUserProfilePic
            // 
            this.pbUserProfilePic.Location = new System.Drawing.Point(12, 68);
            this.pbUserProfilePic.Name = "pbUserProfilePic";
            this.pbUserProfilePic.Size = new System.Drawing.Size(151, 126);
            this.pbUserProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserProfilePic.TabIndex = 1;
            this.pbUserProfilePic.TabStop = false;
            // 
            // listBoxNewsFeed
            // 
            this.listBoxNewsFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNewsFeed.DisplayMember = "name";
            this.listBoxNewsFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxNewsFeed.FormattingEnabled = true;
            this.listBoxNewsFeed.Location = new System.Drawing.Point(172, 86);
            this.listBoxNewsFeed.Name = "listBoxNewsFeed";
            this.listBoxNewsFeed.Size = new System.Drawing.Size(497, 108);
            this.listBoxNewsFeed.TabIndex = 41;
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
            this.listBoxFriends.DisplayMember = "name";
            this.listBoxFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.Location = new System.Drawing.Point(12, 233);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(81, 147);
            this.listBoxFriends.TabIndex = 43;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // pbFriendPicture
            // 
            this.pbFriendPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbFriendPicture.Location = new System.Drawing.Point(99, 232);
            this.pbFriendPicture.Name = "pbFriendPicture";
            this.pbFriendPicture.Size = new System.Drawing.Size(114, 148);
            this.pbFriendPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFriendPicture.TabIndex = 45;
            this.pbFriendPicture.TabStop = false;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEvents.DisplayMember = "name";
            this.listBoxEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(238, 233);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(311, 147);
            this.listBoxEvents.TabIndex = 46;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
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
            // pbEventPic
            // 
            this.pbEventPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEventPic.Location = new System.Drawing.Point(555, 232);
            this.pbEventPic.Name = "pbEventPic";
            this.pbEventPic.Size = new System.Drawing.Size(114, 148);
            this.pbEventPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEventPic.TabIndex = 48;
            this.pbEventPic.TabStop = false;
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
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionalFeaturesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(681, 24);
            this.menuStrip.TabIndex = 50;
            this.menuStrip.Text = "menuStrip1";
            // 
            // additionalFeaturesToolStripMenuItem
            // 
            this.additionalFeaturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToTwitchToolStripMenuItem});
            this.additionalFeaturesToolStripMenuItem.Name = "additionalFeaturesToolStripMenuItem";
            this.additionalFeaturesToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.additionalFeaturesToolStripMenuItem.Text = "Advanced Features";
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 395);
            this.Controls.Add(this.checkBoxStayLoggedIn);
            this.Controls.Add(this.pbEventPic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.pbFriendPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxFriends);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxNewsFeed);
            this.Controls.Add(this.pbUserProfilePic);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Facebook app";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFriendPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEventPic)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.PictureBox pbUserProfilePic;
        private System.Windows.Forms.ListBox listBoxNewsFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.PictureBox pbFriendPicture;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbEventPic;
        private System.Windows.Forms.CheckBox checkBoxStayLoggedIn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem additionalFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToTwitchToolStripMenuItem;
    }
}

