namespace BasicFacebookFeatures
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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelFavoriteTeams = new System.Windows.Forms.Label();
            this.buttonFavoriteTeams = new System.Windows.Forms.Button();
            this.pictureBoxGroups = new System.Windows.Forms.PictureBox();
            this.listBoxFavoriteTeams = new System.Windows.Forms.ListBox();
            this.pictureBoxMyPosts = new System.Windows.Forms.PictureBox();
            this.pictureBoxLikedPages = new System.Windows.Forms.PictureBox();
            this.pictureBoxAlbums = new System.Windows.Forms.PictureBox();
            this.pictureBoxEvents = new System.Windows.Forms.PictureBox();
            this.buttonFetchPosts = new System.Windows.Forms.Button();
            this.buttonFetchLikedPages = new System.Windows.Forms.Button();
            this.buttonFetchAlbums = new System.Windows.Forms.Button();
            this.buttonFetchEvents = new System.Windows.Forms.Button();
            this.buttonFetchAllData = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelListBoxUserPosts = new System.Windows.Forms.Label();
            this.labelListBoxGrops = new System.Windows.Forms.Label();
            this.labelListBoxAlbums = new System.Windows.Forms.Label();
            this.labelBoxEvents = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.listBoxUserPosts = new System.Windows.Forms.ListBox();
            this.listBoxLikedPages = new System.Windows.Forms.ListBox();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMyPosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(18, 57);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 36);
            this.label1.TabIndex = 53;
            this.label1.Text = "This is the AppID of \"Design Patterns App 2.4\". The grader will use it to test yo" +
    "ur app.\r\nType here your own AppID to test it:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelFavoriteTeams);
            this.tabPage1.Controls.Add(this.buttonFavoriteTeams);
            this.tabPage1.Controls.Add(this.pictureBoxGroups);
            this.tabPage1.Controls.Add(this.listBoxFavoriteTeams);
            this.tabPage1.Controls.Add(this.pictureBoxMyPosts);
            this.tabPage1.Controls.Add(this.pictureBoxLikedPages);
            this.tabPage1.Controls.Add(this.pictureBoxAlbums);
            this.tabPage1.Controls.Add(this.pictureBoxEvents);
            this.tabPage1.Controls.Add(this.buttonFetchPosts);
            this.tabPage1.Controls.Add(this.buttonFetchLikedPages);
            this.tabPage1.Controls.Add(this.buttonFetchAlbums);
            this.tabPage1.Controls.Add(this.buttonFetchEvents);
            this.tabPage1.Controls.Add(this.buttonFetchAllData);
            this.tabPage1.Controls.Add(this.labelDescription);
            this.tabPage1.Controls.Add(this.labelListBoxUserPosts);
            this.tabPage1.Controls.Add(this.labelListBoxGrops);
            this.tabPage1.Controls.Add(this.labelListBoxAlbums);
            this.tabPage1.Controls.Add(this.labelBoxEvents);
            this.tabPage1.Controls.Add(this.richTextBoxDescription);
            this.tabPage1.Controls.Add(this.listBoxUserPosts);
            this.tabPage1.Controls.Add(this.listBoxLikedPages);
            this.tabPage1.Controls.Add(this.listBoxAlbums);
            this.tabPage1.Controls.Add(this.listBoxEvents);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1235, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelFavoriteTeams
            // 
            this.labelFavoriteTeams.AutoSize = true;
            this.labelFavoriteTeams.Location = new System.Drawing.Point(826, 229);
            this.labelFavoriteTeams.Name = "labelFavoriteTeams";
            this.labelFavoriteTeams.Size = new System.Drawing.Size(135, 18);
            this.labelFavoriteTeams.TabIndex = 78;
            this.labelFavoriteTeams.Text = "My Favorite Teams";
            // 
            // buttonFavoriteTeams
            // 
            this.buttonFavoriteTeams.Enabled = false;
            this.buttonFavoriteTeams.Location = new System.Drawing.Point(826, 471);
            this.buttonFavoriteTeams.Name = "buttonFavoriteTeams";
            this.buttonFavoriteTeams.Size = new System.Drawing.Size(165, 29);
            this.buttonFavoriteTeams.TabIndex = 77;
            this.buttonFavoriteTeams.Text = "Fetch Favorite Teams";
            this.buttonFavoriteTeams.UseVisualStyleBackColor = true;
            this.buttonFavoriteTeams.Click += new System.EventHandler(this.buttonFetchGroups_Click);
            // 
            // pictureBoxGroups
            // 
            this.pictureBoxGroups.Location = new System.Drawing.Point(826, 506);
            this.pictureBoxGroups.Name = "pictureBoxGroups";
            this.pictureBoxGroups.Size = new System.Drawing.Size(97, 80);
            this.pictureBoxGroups.TabIndex = 76;
            this.pictureBoxGroups.TabStop = false;
            // 
            // listBoxFavoriteTeams
            // 
            this.listBoxFavoriteTeams.FormattingEnabled = true;
            this.listBoxFavoriteTeams.ItemHeight = 18;
            this.listBoxFavoriteTeams.Location = new System.Drawing.Point(826, 248);
            this.listBoxFavoriteTeams.Name = "listBoxFavoriteTeams";
            this.listBoxFavoriteTeams.Size = new System.Drawing.Size(139, 220);
            this.listBoxFavoriteTeams.TabIndex = 75;
            this.listBoxFavoriteTeams.SelectedIndexChanged += new System.EventHandler(this.listBoxFavoriteTeams_SelectedIndexChanged);
            // 
            // pictureBoxMyPosts
            // 
            this.pictureBoxMyPosts.Location = new System.Drawing.Point(614, 500);
            this.pictureBoxMyPosts.Name = "pictureBoxMyPosts";
            this.pictureBoxMyPosts.Size = new System.Drawing.Size(107, 83);
            this.pictureBoxMyPosts.TabIndex = 74;
            this.pictureBoxMyPosts.TabStop = false;
            // 
            // pictureBoxLikedPages
            // 
            this.pictureBoxLikedPages.Location = new System.Drawing.Point(410, 500);
            this.pictureBoxLikedPages.Name = "pictureBoxLikedPages";
            this.pictureBoxLikedPages.Size = new System.Drawing.Size(108, 83);
            this.pictureBoxLikedPages.TabIndex = 73;
            this.pictureBoxLikedPages.TabStop = false;
            // 
            // pictureBoxAlbums
            // 
            this.pictureBoxAlbums.Location = new System.Drawing.Point(224, 500);
            this.pictureBoxAlbums.Name = "pictureBoxAlbums";
            this.pictureBoxAlbums.Size = new System.Drawing.Size(115, 83);
            this.pictureBoxAlbums.TabIndex = 72;
            this.pictureBoxAlbums.TabStop = false;
            // 
            // pictureBoxEvents
            // 
            this.pictureBoxEvents.Location = new System.Drawing.Point(18, 509);
            this.pictureBoxEvents.Name = "pictureBoxEvents";
            this.pictureBoxEvents.Size = new System.Drawing.Size(112, 77);
            this.pictureBoxEvents.TabIndex = 71;
            this.pictureBoxEvents.TabStop = false;
            // 
            // buttonFetchPosts
            // 
            this.buttonFetchPosts.Enabled = false;
            this.buttonFetchPosts.Location = new System.Drawing.Point(614, 471);
            this.buttonFetchPosts.Name = "buttonFetchPosts";
            this.buttonFetchPosts.Size = new System.Drawing.Size(107, 23);
            this.buttonFetchPosts.TabIndex = 70;
            this.buttonFetchPosts.Text = "Fetch Posts";
            this.buttonFetchPosts.UseVisualStyleBackColor = true;
            this.buttonFetchPosts.Click += new System.EventHandler(this.buttonFetchPosts_Click);
            // 
            // buttonFetchLikedPages
            // 
            this.buttonFetchLikedPages.Enabled = false;
            this.buttonFetchLikedPages.Location = new System.Drawing.Point(410, 471);
            this.buttonFetchLikedPages.Name = "buttonFetchLikedPages";
            this.buttonFetchLikedPages.Size = new System.Drawing.Size(154, 29);
            this.buttonFetchLikedPages.TabIndex = 69;
            this.buttonFetchLikedPages.Text = "Fetch Liked Pages";
            this.buttonFetchLikedPages.UseVisualStyleBackColor = true;
            this.buttonFetchLikedPages.Click += new System.EventHandler(this.buttonLikedPages_Click);
            // 
            // buttonFetchAlbums
            // 
            this.buttonFetchAlbums.Enabled = false;
            this.buttonFetchAlbums.Location = new System.Drawing.Point(224, 474);
            this.buttonFetchAlbums.Name = "buttonFetchAlbums";
            this.buttonFetchAlbums.Size = new System.Drawing.Size(115, 23);
            this.buttonFetchAlbums.TabIndex = 68;
            this.buttonFetchAlbums.Text = "Fetch Albums";
            this.buttonFetchAlbums.UseVisualStyleBackColor = true;
            this.buttonFetchAlbums.Click += new System.EventHandler(this.buttonFetchAlbums_Click);
            // 
            // buttonFetchEvents
            // 
            this.buttonFetchEvents.Enabled = false;
            this.buttonFetchEvents.Location = new System.Drawing.Point(18, 476);
            this.buttonFetchEvents.Name = "buttonFetchEvents";
            this.buttonFetchEvents.Size = new System.Drawing.Size(102, 27);
            this.buttonFetchEvents.TabIndex = 67;
            this.buttonFetchEvents.Text = "Fetch Events";
            this.buttonFetchEvents.UseVisualStyleBackColor = true;
            this.buttonFetchEvents.Click += new System.EventHandler(this.buttonFetchEvents_Click);
            // 
            // buttonFetchAllData
            // 
            this.buttonFetchAllData.Enabled = false;
            this.buttonFetchAllData.Location = new System.Drawing.Point(18, 180);
            this.buttonFetchAllData.Name = "buttonFetchAllData";
            this.buttonFetchAllData.Size = new System.Drawing.Size(182, 34);
            this.buttonFetchAllData.TabIndex = 66;
            this.buttonFetchAllData.Text = "Fetch All Data";
            this.buttonFetchAllData.UseVisualStyleBackColor = true;
            this.buttonFetchAllData.Click += new System.EventHandler(this.buttonFetchData_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(1007, 227);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(83, 18);
            this.labelDescription.TabIndex = 65;
            this.labelDescription.Text = "Description";
            // 
            // labelListBoxUserPosts
            // 
            this.labelListBoxUserPosts.AutoSize = true;
            this.labelListBoxUserPosts.Location = new System.Drawing.Point(611, 227);
            this.labelListBoxUserPosts.Name = "labelListBoxUserPosts";
            this.labelListBoxUserPosts.Size = new System.Drawing.Size(69, 18);
            this.labelListBoxUserPosts.TabIndex = 64;
            this.labelListBoxUserPosts.Text = "My posts";
            // 
            // labelListBoxGrops
            // 
            this.labelListBoxGrops.AutoSize = true;
            this.labelListBoxGrops.Location = new System.Drawing.Point(407, 227);
            this.labelListBoxGrops.Name = "labelListBoxGrops";
            this.labelListBoxGrops.Size = new System.Drawing.Size(89, 18);
            this.labelListBoxGrops.TabIndex = 63;
            this.labelListBoxGrops.Text = "Liked Pages";
            // 
            // labelListBoxAlbums
            // 
            this.labelListBoxAlbums.AutoSize = true;
            this.labelListBoxAlbums.Location = new System.Drawing.Point(221, 227);
            this.labelListBoxAlbums.Name = "labelListBoxAlbums";
            this.labelListBoxAlbums.Size = new System.Drawing.Size(57, 18);
            this.labelListBoxAlbums.TabIndex = 62;
            this.labelListBoxAlbums.Text = "Albums";
            // 
            // labelBoxEvents
            // 
            this.labelBoxEvents.AutoSize = true;
            this.labelBoxEvents.Location = new System.Drawing.Point(15, 227);
            this.labelBoxEvents.Name = "labelBoxEvents";
            this.labelBoxEvents.Size = new System.Drawing.Size(53, 18);
            this.labelBoxEvents.TabIndex = 61;
            this.labelBoxEvents.Text = "Events";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(1010, 248);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(199, 220);
            this.richTextBoxDescription.TabIndex = 60;
            this.richTextBoxDescription.Text = "";
            // 
            // listBoxUserPosts
            // 
            this.listBoxUserPosts.FormattingEnabled = true;
            this.listBoxUserPosts.ItemHeight = 18;
            this.listBoxUserPosts.Location = new System.Drawing.Point(614, 248);
            this.listBoxUserPosts.Name = "listBoxUserPosts";
            this.listBoxUserPosts.Size = new System.Drawing.Size(152, 220);
            this.listBoxUserPosts.TabIndex = 59;
            this.listBoxUserPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxUserPosts_SelectedIndexChanged);
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.ItemHeight = 18;
            this.listBoxLikedPages.Location = new System.Drawing.Point(410, 248);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(154, 220);
            this.listBoxLikedPages.TabIndex = 58;
            this.listBoxLikedPages.SelectedIndexChanged += new System.EventHandler(this.listBoxLikedPages_SelectedIndexChanged);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 18;
            this.listBoxAlbums.Location = new System.Drawing.Point(224, 248);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(135, 220);
            this.listBoxAlbums.TabIndex = 57;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 18;
            this.listBoxEvents.Location = new System.Drawing.Point(18, 250);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(170, 220);
            this.listBoxEvents.TabIndex = 56;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(18, 96);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(79, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(317, 61);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 24);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1450160541956417";
            this.textBoxAppID.TextChanged += new System.EventHandler(this.textBoxAppID_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1235, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMyPosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.ListBox listBoxLikedPages;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelListBoxUserPosts;
        private System.Windows.Forms.Label labelListBoxGrops;
        private System.Windows.Forms.Label labelListBoxAlbums;
        private System.Windows.Forms.Label labelBoxEvents;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.ListBox listBoxUserPosts;
        private System.Windows.Forms.Button buttonFetchAllData;
        private System.Windows.Forms.Button buttonFetchPosts;
        private System.Windows.Forms.Button buttonFetchLikedPages;
        private System.Windows.Forms.Button buttonFetchAlbums;
        private System.Windows.Forms.Button buttonFetchEvents;
        private System.Windows.Forms.PictureBox pictureBoxMyPosts;
        private System.Windows.Forms.PictureBox pictureBoxLikedPages;
        private System.Windows.Forms.PictureBox pictureBoxAlbums;
        private System.Windows.Forms.PictureBox pictureBoxEvents;
        private System.Windows.Forms.ListBox listBoxFavoriteTeams;
        private System.Windows.Forms.Label labelFavoriteTeams;
        private System.Windows.Forms.Button buttonFavoriteTeams;
        private System.Windows.Forms.PictureBox pictureBoxGroups;
    }
}

