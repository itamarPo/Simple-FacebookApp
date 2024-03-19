using System.Windows.Forms.DataVisualization.Charting;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRegularFeatures = new System.Windows.Forms.TabPage();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.labelPostStatus = new System.Windows.Forms.Label();
            this.labelPleaseLogin = new System.Windows.Forms.Label();
            this.buttonAddAppID = new System.Windows.Forms.Button();
            this.comboBoxAppID = new System.Windows.Forms.ComboBox();
            this.labelFavoriteTeams = new System.Windows.Forms.Label();
            this.buttonFavoriteTeams = new System.Windows.Forms.Button();
            this.pictureBoxFavoriteTeams = new System.Windows.Forms.PictureBox();
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
            this.tabPageSpecialFeatures = new System.Windows.Forms.TabPage();
            this.eventOnUserBirthDayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxSortOrder = new System.Windows.Forms.ComboBox();
            this.labelUserPostCreatedMonthGraph = new System.Windows.Forms.Label();
            this.buttonFetchUserPostCreatedPerMonthGraph = new System.Windows.Forms.Button();
            this.chartUserCreatedPostsPerMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxEventsOnUserBirthdayMonth = new System.Windows.Forms.PictureBox();
            this.richTextBoxEventOnUserBirthDayMonth = new System.Windows.Forms.RichTextBox();
            this.labelEventDescription = new System.Windows.Forms.Label();
            this.listBoxEventsOnUserBirthdayMonth = new System.Windows.Forms.ListBox();
            this.buttonShowEventOnBirthdayMonth = new System.Windows.Forms.Button();
            this.labelUserBirthDayMonth = new System.Windows.Forms.Label();
            this.labelSortGraph = new System.Windows.Forms.Label();
            this.labelEventsUserBirthdayMonth = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageRegularFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavoriteTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMyPosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabPageSpecialFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventOnUserBirthDayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUserCreatedPostsPerMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventsOnUserBirthdayMonth)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(458, 54);
            this.label1.TabIndex = 53;
            this.label1.Text = "Welcome. Please Login to continue.\r\nIf you desire to add another aplication id Pr" +
    "ess the Add button.\r\nThe default values of the combo box contains my app ID and " +
    "desig\'s.";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageRegularFeatures);
            this.tabControl.Controls.Add(this.tabPageSpecialFeatures);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1243, 697);
            this.tabControl.TabIndex = 54;
            // 
            // tabPageRegularFeatures
            // 
            this.tabPageRegularFeatures.Controls.Add(this.buttonPostStatus);
            this.tabPageRegularFeatures.Controls.Add(this.textBoxStatus);
            this.tabPageRegularFeatures.Controls.Add(this.labelPostStatus);
            this.tabPageRegularFeatures.Controls.Add(this.labelPleaseLogin);
            this.tabPageRegularFeatures.Controls.Add(this.buttonAddAppID);
            this.tabPageRegularFeatures.Controls.Add(this.comboBoxAppID);
            this.tabPageRegularFeatures.Controls.Add(this.labelFavoriteTeams);
            this.tabPageRegularFeatures.Controls.Add(this.buttonFavoriteTeams);
            this.tabPageRegularFeatures.Controls.Add(this.pictureBoxFavoriteTeams);
            this.tabPageRegularFeatures.Controls.Add(this.listBoxFavoriteTeams);
            this.tabPageRegularFeatures.Controls.Add(this.pictureBoxMyPosts);
            this.tabPageRegularFeatures.Controls.Add(this.pictureBoxLikedPages);
            this.tabPageRegularFeatures.Controls.Add(this.pictureBoxAlbums);
            this.tabPageRegularFeatures.Controls.Add(this.pictureBoxEvents);
            this.tabPageRegularFeatures.Controls.Add(this.buttonFetchPosts);
            this.tabPageRegularFeatures.Controls.Add(this.buttonFetchLikedPages);
            this.tabPageRegularFeatures.Controls.Add(this.buttonFetchAlbums);
            this.tabPageRegularFeatures.Controls.Add(this.buttonFetchEvents);
            this.tabPageRegularFeatures.Controls.Add(this.buttonFetchAllData);
            this.tabPageRegularFeatures.Controls.Add(this.labelDescription);
            this.tabPageRegularFeatures.Controls.Add(this.labelListBoxUserPosts);
            this.tabPageRegularFeatures.Controls.Add(this.labelListBoxGrops);
            this.tabPageRegularFeatures.Controls.Add(this.labelListBoxAlbums);
            this.tabPageRegularFeatures.Controls.Add(this.labelBoxEvents);
            this.tabPageRegularFeatures.Controls.Add(this.richTextBoxDescription);
            this.tabPageRegularFeatures.Controls.Add(this.listBoxUserPosts);
            this.tabPageRegularFeatures.Controls.Add(this.listBoxLikedPages);
            this.tabPageRegularFeatures.Controls.Add(this.listBoxAlbums);
            this.tabPageRegularFeatures.Controls.Add(this.listBoxEvents);
            this.tabPageRegularFeatures.Controls.Add(this.pictureBoxProfile);
            this.tabPageRegularFeatures.Controls.Add(this.label1);
            this.tabPageRegularFeatures.Controls.Add(this.buttonLogout);
            this.tabPageRegularFeatures.Controls.Add(this.buttonLogin);
            this.tabPageRegularFeatures.Location = new System.Drawing.Point(4, 27);
            this.tabPageRegularFeatures.Name = "tabPageRegularFeatures";
            this.tabPageRegularFeatures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegularFeatures.Size = new System.Drawing.Size(1235, 666);
            this.tabPageRegularFeatures.TabIndex = 0;
            this.tabPageRegularFeatures.Text = "Regular Features";
            this.tabPageRegularFeatures.UseVisualStyleBackColor = true;
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Enabled = false;
            this.buttonPostStatus.Location = new System.Drawing.Point(846, 216);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonPostStatus.TabIndex = 84;
            this.buttonPostStatus.Text = "Post";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            this.buttonPostStatus.Click += new System.EventHandler(this.buttonPostStatus_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(427, 213);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(404, 24);
            this.textBoxStatus.TabIndex = 83;
            // 
            // labelPostStatus
            // 
            this.labelPostStatus.AutoSize = true;
            this.labelPostStatus.Location = new System.Drawing.Point(321, 216);
            this.labelPostStatus.Name = "labelPostStatus";
            this.labelPostStatus.Size = new System.Drawing.Size(87, 18);
            this.labelPostStatus.TabIndex = 82;
            this.labelPostStatus.Text = "Post status:";
            // 
            // labelPleaseLogin
            // 
            this.labelPleaseLogin.AutoSize = true;
            this.labelPleaseLogin.ForeColor = System.Drawing.Color.Red;
            this.labelPleaseLogin.Location = new System.Drawing.Point(116, 96);
            this.labelPleaseLogin.Name = "labelPleaseLogin";
            this.labelPleaseLogin.Size = new System.Drawing.Size(170, 18);
            this.labelPleaseLogin.TabIndex = 81;
            this.labelPleaseLogin.Text = "Please Login to continue";
            // 
            // buttonAddAppID
            // 
            this.buttonAddAppID.Location = new System.Drawing.Point(588, 74);
            this.buttonAddAppID.Name = "buttonAddAppID";
            this.buttonAddAppID.Size = new System.Drawing.Size(91, 26);
            this.buttonAddAppID.TabIndex = 80;
            this.buttonAddAppID.Text = "Add";
            this.buttonAddAppID.UseVisualStyleBackColor = true;
            this.buttonAddAppID.Click += new System.EventHandler(this.buttonAddAppID_Click);
            // 
            // comboBoxAppID
            // 
            this.comboBoxAppID.FormattingEnabled = true;
            this.comboBoxAppID.Items.AddRange(new object[] {
            "1542194956558397",
            "1450160541956417"});
            this.comboBoxAppID.Location = new System.Drawing.Point(317, 74);
            this.comboBoxAppID.Name = "comboBoxAppID";
            this.comboBoxAppID.Size = new System.Drawing.Size(265, 26);
            this.comboBoxAppID.TabIndex = 79;
            this.comboBoxAppID.SelectedIndexChanged += new System.EventHandler(this.comboBoxAppID_SelectedIndexChanged);
            // 
            // labelFavoriteTeams
            // 
            this.labelFavoriteTeams.AutoSize = true;
            this.labelFavoriteTeams.Location = new System.Drawing.Point(824, 284);
            this.labelFavoriteTeams.Name = "labelFavoriteTeams";
            this.labelFavoriteTeams.Size = new System.Drawing.Size(135, 18);
            this.labelFavoriteTeams.TabIndex = 78;
            this.labelFavoriteTeams.Text = "My Favorite Teams";
            // 
            // buttonFavoriteTeams
            // 
            this.buttonFavoriteTeams.Enabled = false;
            this.buttonFavoriteTeams.Location = new System.Drawing.Point(824, 526);
            this.buttonFavoriteTeams.Name = "buttonFavoriteTeams";
            this.buttonFavoriteTeams.Size = new System.Drawing.Size(165, 29);
            this.buttonFavoriteTeams.TabIndex = 77;
            this.buttonFavoriteTeams.Text = "Fetch Favorite Teams";
            this.buttonFavoriteTeams.UseVisualStyleBackColor = true;
            this.buttonFavoriteTeams.Click += new System.EventHandler(this.buttonFetchFavoriteTeams_Click);
            // 
            // pictureBoxFavoriteTeams
            // 
            this.pictureBoxFavoriteTeams.Location = new System.Drawing.Point(824, 561);
            this.pictureBoxFavoriteTeams.Name = "pictureBoxFavoriteTeams";
            this.pictureBoxFavoriteTeams.Size = new System.Drawing.Size(97, 80);
            this.pictureBoxFavoriteTeams.TabIndex = 76;
            this.pictureBoxFavoriteTeams.TabStop = false;
            // 
            // listBoxFavoriteTeams
            // 
            this.listBoxFavoriteTeams.FormattingEnabled = true;
            this.listBoxFavoriteTeams.ItemHeight = 18;
            this.listBoxFavoriteTeams.Location = new System.Drawing.Point(824, 303);
            this.listBoxFavoriteTeams.Name = "listBoxFavoriteTeams";
            this.listBoxFavoriteTeams.Size = new System.Drawing.Size(139, 220);
            this.listBoxFavoriteTeams.TabIndex = 75;
            this.listBoxFavoriteTeams.SelectedIndexChanged += new System.EventHandler(this.listBoxFavoriteTeams_SelectedIndexChanged);
            // 
            // pictureBoxMyPosts
            // 
            this.pictureBoxMyPosts.Location = new System.Drawing.Point(612, 555);
            this.pictureBoxMyPosts.Name = "pictureBoxMyPosts";
            this.pictureBoxMyPosts.Size = new System.Drawing.Size(107, 83);
            this.pictureBoxMyPosts.TabIndex = 74;
            this.pictureBoxMyPosts.TabStop = false;
            // 
            // pictureBoxLikedPages
            // 
            this.pictureBoxLikedPages.Location = new System.Drawing.Point(408, 555);
            this.pictureBoxLikedPages.Name = "pictureBoxLikedPages";
            this.pictureBoxLikedPages.Size = new System.Drawing.Size(108, 83);
            this.pictureBoxLikedPages.TabIndex = 73;
            this.pictureBoxLikedPages.TabStop = false;
            // 
            // pictureBoxAlbums
            // 
            this.pictureBoxAlbums.Location = new System.Drawing.Point(222, 555);
            this.pictureBoxAlbums.Name = "pictureBoxAlbums";
            this.pictureBoxAlbums.Size = new System.Drawing.Size(115, 83);
            this.pictureBoxAlbums.TabIndex = 72;
            this.pictureBoxAlbums.TabStop = false;
            // 
            // pictureBoxEvents
            // 
            this.pictureBoxEvents.Location = new System.Drawing.Point(16, 564);
            this.pictureBoxEvents.Name = "pictureBoxEvents";
            this.pictureBoxEvents.Size = new System.Drawing.Size(112, 77);
            this.pictureBoxEvents.TabIndex = 71;
            this.pictureBoxEvents.TabStop = false;
            // 
            // buttonFetchPosts
            // 
            this.buttonFetchPosts.Enabled = false;
            this.buttonFetchPosts.Location = new System.Drawing.Point(612, 526);
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
            this.buttonFetchLikedPages.Location = new System.Drawing.Point(408, 526);
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
            this.buttonFetchAlbums.Location = new System.Drawing.Point(222, 529);
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
            this.buttonFetchEvents.Location = new System.Drawing.Point(16, 531);
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
            this.labelDescription.Location = new System.Drawing.Point(1005, 282);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(83, 18);
            this.labelDescription.TabIndex = 65;
            this.labelDescription.Text = "Description";
            // 
            // labelListBoxUserPosts
            // 
            this.labelListBoxUserPosts.AutoSize = true;
            this.labelListBoxUserPosts.Location = new System.Drawing.Point(609, 282);
            this.labelListBoxUserPosts.Name = "labelListBoxUserPosts";
            this.labelListBoxUserPosts.Size = new System.Drawing.Size(69, 18);
            this.labelListBoxUserPosts.TabIndex = 64;
            this.labelListBoxUserPosts.Text = "My posts";
            // 
            // labelListBoxGrops
            // 
            this.labelListBoxGrops.AutoSize = true;
            this.labelListBoxGrops.Location = new System.Drawing.Point(405, 282);
            this.labelListBoxGrops.Name = "labelListBoxGrops";
            this.labelListBoxGrops.Size = new System.Drawing.Size(89, 18);
            this.labelListBoxGrops.TabIndex = 63;
            this.labelListBoxGrops.Text = "Liked Pages";
            // 
            // labelListBoxAlbums
            // 
            this.labelListBoxAlbums.AutoSize = true;
            this.labelListBoxAlbums.Location = new System.Drawing.Point(219, 282);
            this.labelListBoxAlbums.Name = "labelListBoxAlbums";
            this.labelListBoxAlbums.Size = new System.Drawing.Size(57, 18);
            this.labelListBoxAlbums.TabIndex = 62;
            this.labelListBoxAlbums.Text = "Albums";
            // 
            // labelBoxEvents
            // 
            this.labelBoxEvents.AutoSize = true;
            this.labelBoxEvents.Location = new System.Drawing.Point(13, 282);
            this.labelBoxEvents.Name = "labelBoxEvents";
            this.labelBoxEvents.Size = new System.Drawing.Size(53, 18);
            this.labelBoxEvents.TabIndex = 61;
            this.labelBoxEvents.Text = "Events";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(1008, 303);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(199, 220);
            this.richTextBoxDescription.TabIndex = 60;
            this.richTextBoxDescription.Text = "";
            // 
            // listBoxUserPosts
            // 
            this.listBoxUserPosts.FormattingEnabled = true;
            this.listBoxUserPosts.ItemHeight = 18;
            this.listBoxUserPosts.Location = new System.Drawing.Point(612, 303);
            this.listBoxUserPosts.Name = "listBoxUserPosts";
            this.listBoxUserPosts.Size = new System.Drawing.Size(152, 220);
            this.listBoxUserPosts.TabIndex = 59;
            this.listBoxUserPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxUserPosts_SelectedIndexChanged);
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.ItemHeight = 18;
            this.listBoxLikedPages.Location = new System.Drawing.Point(408, 303);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(154, 220);
            this.listBoxLikedPages.TabIndex = 58;
            this.listBoxLikedPages.SelectedIndexChanged += new System.EventHandler(this.listBoxLikedPages_SelectedIndexChanged);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 18;
            this.listBoxAlbums.Location = new System.Drawing.Point(222, 303);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(135, 220);
            this.listBoxAlbums.TabIndex = 57;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 18;
            this.listBoxEvents.Location = new System.Drawing.Point(16, 305);
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
            // tabPageSpecialFeatures
            // 
            this.tabPageSpecialFeatures.Controls.Add(this.labelEventsUserBirthdayMonth);
            this.tabPageSpecialFeatures.Controls.Add(this.labelSortGraph);
            this.tabPageSpecialFeatures.Controls.Add(this.comboBoxSortOrder);
            this.tabPageSpecialFeatures.Controls.Add(this.labelUserPostCreatedMonthGraph);
            this.tabPageSpecialFeatures.Controls.Add(this.buttonFetchUserPostCreatedPerMonthGraph);
            this.tabPageSpecialFeatures.Controls.Add(this.chartUserCreatedPostsPerMonth);
            this.tabPageSpecialFeatures.Controls.Add(this.pictureBoxEventsOnUserBirthdayMonth);
            this.tabPageSpecialFeatures.Controls.Add(this.richTextBoxEventOnUserBirthDayMonth);
            this.tabPageSpecialFeatures.Controls.Add(this.labelEventDescription);
            this.tabPageSpecialFeatures.Controls.Add(this.listBoxEventsOnUserBirthdayMonth);
            this.tabPageSpecialFeatures.Controls.Add(this.buttonShowEventOnBirthdayMonth);
            this.tabPageSpecialFeatures.Controls.Add(this.labelUserBirthDayMonth);
            this.tabPageSpecialFeatures.Enabled = false;
            this.tabPageSpecialFeatures.Location = new System.Drawing.Point(4, 27);
            this.tabPageSpecialFeatures.Name = "tabPageSpecialFeatures";
            this.tabPageSpecialFeatures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecialFeatures.Size = new System.Drawing.Size(1235, 666);
            this.tabPageSpecialFeatures.TabIndex = 1;
            this.tabPageSpecialFeatures.Text = "Special Features";
            this.tabPageSpecialFeatures.UseVisualStyleBackColor = true;
            // 
            // eventOnUserBirthDayBindingSource
            // 
            this.eventOnUserBirthDayBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Event);
            // 
            // comboBoxSortOrder
            // 
            this.comboBoxSortOrder.Enabled = false;
            this.comboBoxSortOrder.FormattingEnabled = true;
            this.comboBoxSortOrder.Location = new System.Drawing.Point(11, 375);
            this.comboBoxSortOrder.Name = "comboBoxSortOrder";
            this.comboBoxSortOrder.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSortOrder.TabIndex = 13;
            this.comboBoxSortOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortOrder_SelectedIndexChanged);
            // 
            // labelUserPostCreatedMonthGraph
            // 
            this.labelUserPostCreatedMonthGraph.AutoSize = true;
            this.labelUserPostCreatedMonthGraph.Location = new System.Drawing.Point(6, 260);
            this.labelUserPostCreatedMonthGraph.Name = "labelUserPostCreatedMonthGraph";
            this.labelUserPostCreatedMonthGraph.Size = new System.Drawing.Size(319, 18);
            this.labelUserPostCreatedMonthGraph.TabIndex = 8;
            this.labelUserPostCreatedMonthGraph.Text = "The User\'s created Number of posts per Month";
            // 
            // buttonFetchUserPostCreatedPerMonthGraph
            // 
            this.buttonFetchUserPostCreatedPerMonthGraph.Location = new System.Drawing.Point(31, 281);
            this.buttonFetchUserPostCreatedPerMonthGraph.Name = "buttonFetchUserPostCreatedPerMonthGraph";
            this.buttonFetchUserPostCreatedPerMonthGraph.Size = new System.Drawing.Size(218, 48);
            this.buttonFetchUserPostCreatedPerMonthGraph.TabIndex = 7;
            this.buttonFetchUserPostCreatedPerMonthGraph.Text = "Fetch User\'s Created Number of Posts per Month Graph";
            this.buttonFetchUserPostCreatedPerMonthGraph.UseVisualStyleBackColor = true;
            this.buttonFetchUserPostCreatedPerMonthGraph.Click += new System.EventHandler(this.buttonFetchUserPostCreatedPerMonthGraph_Click);
            // 
            // chartUserCreatedPostsPerMonth
            // 
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chartUserCreatedPostsPerMonth.ChartAreas.Add(chartArea1);
            legend1.AutoFitMinFontSize = 5;
            legend1.Name = "Legend1";
            this.chartUserCreatedPostsPerMonth.Legends.Add(legend1);
            this.chartUserCreatedPostsPerMonth.Location = new System.Drawing.Point(331, 211);
            this.chartUserCreatedPostsPerMonth.Name = "chartUserCreatedPostsPerMonth";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Number of Posts";
            this.chartUserCreatedPostsPerMonth.Series.Add(series1);
            this.chartUserCreatedPostsPerMonth.Size = new System.Drawing.Size(615, 336);
            this.chartUserCreatedPostsPerMonth.TabIndex = 12;
            this.chartUserCreatedPostsPerMonth.Text = "chart1";
            title1.Name = "TitleUserCreatedPostsPerMonthGraph";
            title1.Text = "Users Created Posts Per Month";
            this.chartUserCreatedPostsPerMonth.Titles.Add(title1);
            this.chartUserCreatedPostsPerMonth.Visible = false;
            // 
            // pictureBoxEventsOnUserBirthdayMonth
            // 
            this.pictureBoxEventsOnUserBirthdayMonth.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.eventOnUserBirthDayBindingSource, "ImageNormal", true));
            this.pictureBoxEventsOnUserBirthdayMonth.Location = new System.Drawing.Point(538, 48);
            this.pictureBoxEventsOnUserBirthdayMonth.Name = "pictureBoxEventsOnUserBirthdayMonth";
            this.pictureBoxEventsOnUserBirthdayMonth.Size = new System.Drawing.Size(151, 148);
            this.pictureBoxEventsOnUserBirthdayMonth.TabIndex = 5;
            this.pictureBoxEventsOnUserBirthdayMonth.TabStop = false;
            // 
            // richTextBoxEventOnUserBirthDayMonth
            // 
            this.richTextBoxEventOnUserBirthDayMonth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventOnUserBirthDayBindingSource, "Description", true));
            this.richTextBoxEventOnUserBirthDayMonth.Location = new System.Drawing.Point(704, 48);
            this.richTextBoxEventOnUserBirthDayMonth.Name = "richTextBoxEventOnUserBirthDayMonth";
            this.richTextBoxEventOnUserBirthDayMonth.Size = new System.Drawing.Size(274, 148);
            this.richTextBoxEventOnUserBirthDayMonth.TabIndex = 4;
            this.richTextBoxEventOnUserBirthDayMonth.Text = "";
            // 
            // labelEventDescription
            // 
            this.labelEventDescription.AutoSize = true;
            this.labelEventDescription.Location = new System.Drawing.Point(701, 27);
            this.labelEventDescription.Name = "labelEventDescription";
            this.labelEventDescription.Size = new System.Drawing.Size(128, 18);
            this.labelEventDescription.TabIndex = 3;
            this.labelEventDescription.Text = "Event Description:";
            // 
            // listBoxEventsOnUserBirthdayMonth
            // 
            this.listBoxEventsOnUserBirthdayMonth.DataSource = this.eventOnUserBirthDayBindingSource;
            this.listBoxEventsOnUserBirthdayMonth.DisplayMember = "Name";
            this.listBoxEventsOnUserBirthdayMonth.FormattingEnabled = true;
            this.listBoxEventsOnUserBirthdayMonth.ItemHeight = 18;
            this.listBoxEventsOnUserBirthdayMonth.Location = new System.Drawing.Point(250, 48);
            this.listBoxEventsOnUserBirthdayMonth.Name = "listBoxEventsOnUserBirthdayMonth";
            this.listBoxEventsOnUserBirthdayMonth.Size = new System.Drawing.Size(272, 148);
            this.listBoxEventsOnUserBirthdayMonth.TabIndex = 2;
            this.listBoxEventsOnUserBirthdayMonth.SelectedIndexChanged += new System.EventHandler(this.listBoxEventsOnUserBirthdayMonth_SelectedIndexChanged);
            // 
            // buttonShowEventOnBirthdayMonth
            // 
            this.buttonShowEventOnBirthdayMonth.Location = new System.Drawing.Point(9, 48);
            this.buttonShowEventOnBirthdayMonth.Name = "buttonShowEventOnBirthdayMonth";
            this.buttonShowEventOnBirthdayMonth.Size = new System.Drawing.Size(179, 49);
            this.buttonShowEventOnBirthdayMonth.TabIndex = 1;
            this.buttonShowEventOnBirthdayMonth.Text = "Show Events On Users birthday Month";
            this.buttonShowEventOnBirthdayMonth.UseVisualStyleBackColor = true;
            this.buttonShowEventOnBirthdayMonth.Click += new System.EventHandler(this.buttonShowEventOnBirthdayMonth_Click);
            // 
            // labelUserBirthDayMonth
            // 
            this.labelUserBirthDayMonth.AutoSize = true;
            this.labelUserBirthDayMonth.Location = new System.Drawing.Point(8, 27);
            this.labelUserBirthDayMonth.Name = "labelUserBirthDayMonth";
            this.labelUserBirthDayMonth.Size = new System.Drawing.Size(233, 18);
            this.labelUserBirthDayMonth.TabIndex = 0;
            this.labelUserBirthDayMonth.Text = "The user\'s birthday month events: ";
            // 
            // labelSortGraph
            // 
            this.labelSortGraph.AutoSize = true;
            this.labelSortGraph.Location = new System.Drawing.Point(8, 354);
            this.labelSortGraph.Name = "labelSortGraph";
            this.labelSortGraph.Size = new System.Drawing.Size(106, 18);
            this.labelSortGraph.TabIndex = 14;
            this.labelSortGraph.Text = "Sort Graph By:";
            // 
            // labelEventsUserBirthdayMonth
            // 
            this.labelEventsUserBirthdayMonth.AutoSize = true;
            this.labelEventsUserBirthdayMonth.Location = new System.Drawing.Point(247, 27);
            this.labelEventsUserBirthdayMonth.Name = "labelEventsUserBirthdayMonth";
            this.labelEventsUserBirthdayMonth.Size = new System.Drawing.Size(53, 18);
            this.labelEventsUserBirthdayMonth.TabIndex = 15;
            this.labelEventsUserBirthdayMonth.Text = "Events";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DP.206026254";
            this.tabControl.ResumeLayout(false);
            this.tabPageRegularFeatures.ResumeLayout(false);
            this.tabPageRegularFeatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavoriteTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMyPosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabPageSpecialFeatures.ResumeLayout(false);
            this.tabPageSpecialFeatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventOnUserBirthDayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUserCreatedPostsPerMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventsOnUserBirthdayMonth)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageRegularFeatures;
		private System.Windows.Forms.TabPage tabPageSpecialFeatures;
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
        private System.Windows.Forms.PictureBox pictureBoxFavoriteTeams;
        private System.Windows.Forms.Label labelUserBirthDayMonth;
        private System.Windows.Forms.ListBox listBoxEventsOnUserBirthdayMonth;
        private System.Windows.Forms.Button buttonShowEventOnBirthdayMonth;
        private System.Windows.Forms.PictureBox pictureBoxEventsOnUserBirthdayMonth;
        private System.Windows.Forms.RichTextBox richTextBoxEventOnUserBirthDayMonth;
        private System.Windows.Forms.Label labelEventDescription;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUserCreatedPostsPerMonth;
        private System.Windows.Forms.Label labelUserPostCreatedMonthGraph;
        private System.Windows.Forms.Button buttonFetchUserPostCreatedPerMonthGraph;
        private System.Windows.Forms.ComboBox comboBoxAppID;
        private System.Windows.Forms.Button buttonAddAppID;
        private System.Windows.Forms.Label labelPleaseLogin;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label labelPostStatus;
        private System.Windows.Forms.ComboBox comboBoxSortOrder;
        private System.Windows.Forms.BindingSource eventOnUserBirthDayBindingSource;
        private System.Windows.Forms.Label labelSortGraph;
        private System.Windows.Forms.Label labelEventsUserBirthdayMonth;
    }
}

