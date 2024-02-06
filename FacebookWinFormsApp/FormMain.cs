using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using AppEngine;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly Engine r_AppEngine = new Engine();
        private FacebookWrapper.LoginResult m_LoginResult;
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        private const string k_NoDescription = "No Description to retrieve";

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (r_AppEngine.LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            r_AppEngine.LoginResult = FacebookService.Login(
                /// (This is Desig Patter's App ID. replace it with your own)
                r_AppEngine.AppID,
                /// requested permissions:
                "email",
                "public_profile",
                "user_events",
                "user_likes",
                "user_posts",
                "user_photos",
                "user_birthday"
                /// add any relevant permissions
                );
            try
            {
                if(string.IsNullOrEmpty(r_AppEngine.LoginResult.ErrorMessage))
                {
                    buttonLogin.Text = $@"Logged in as {r_AppEngine.LoginResult.LoggedInUser.Name}";
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = r_AppEngine.LoginResult.LoggedInUser.PictureNormalURL;
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;
                    enableButtons();
                    r_AppEngine.IsLoggedIn = true;
                    labelPleaseLogin.Visible = false;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
        }

        private void enableButtons()
        {
            buttonFetchAllData.Enabled = true;
            buttonFetchAlbums.Enabled = true;
            buttonFetchEvents.Enabled = true;
            buttonFetchLikedPages.Enabled = true;
            buttonFetchPosts.Enabled = true;
            buttonFavoriteTeams.Enabled = true;
            tabPageSpecialFeatures.Enabled = true;
        }

        private void disableButtons()
        {
            buttonFetchAllData.Enabled = false;
            buttonFetchAlbums.Enabled = false;
            buttonFetchEvents.Enabled = false;
            buttonFetchLikedPages.Enabled = false;
            buttonFetchPosts.Enabled = false;
            buttonFavoriteTeams.Enabled = false;
            tabPageSpecialFeatures.Enabled = false;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            r_AppEngine.LoginResult = null;
            r_AppEngine.IsLoggedIn = false;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            labelPleaseLogin.Visible = true;
            pictureBoxProfile.ImageLocation = null;
            disableButtons();
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            try
            {
                richTextBoxDescription.Text =
                    r_AppEngine.LoginResult.LoggedInUser.Albums[listBoxAlbums.SelectedIndex].Description;
                pictureBoxAlbums.Load(r_AppEngine.LoginResult.LoggedInUser.Albums[listBoxAlbums.SelectedIndex].PictureAlbumURL);
            }
            catch(Exception exception)
            {
                if(r_AppEngine.LoginResult.LoggedInUser.Albums.Count != 0 ||
                   r_AppEngine.LoginResult.LoggedInUser.Albums[listBoxAlbums.SelectedIndex].Pictures != null)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }

                richTextBoxDescription.Text = k_NoDescription;
            }
        }

        private void buttonFetchData_Click(object sender, EventArgs e)
        {
            fetchUserInfo();
        }

        private void fetchUserInfo()
        {
            fetchUserPosts();
            fetchUserAlbums();
            fetchUserEvents();
            fetchUserLikedPages();
            fetchUserFavoriteTeams();
        }

        private void fetchUserFavoriteTeams()
        {
            try
            {
                List<Page> favoriteTeams = r_AppEngine.FetchFavoriteTeams();
                listBoxFavoriteTeams.Items.Clear();
                if(favoriteTeams.Count == 0)
                {
                    listBoxFavoriteTeams.Items.Add("No Teams to retrieve");
                }
                else
                {
                    foreach(Page team in favoriteTeams)
                    {
                        listBoxFavoriteTeams.Items.Add(team.Name);
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
        }

        private void fetchUserLikedPages()
        {
            listBoxLikedPages.Items.Clear();
            List<Page> userLikedPages = r_AppEngine.FetchUserLikedPages();

            if(userLikedPages.Count == 0)
            {
                listBoxLikedPages.Items.Add("No Liked Pages to retrieve");
            }
            else
            {
                foreach(Page page in userLikedPages)
                {
                    listBoxLikedPages.Items.Add(page.Name);
                }
            }
        }

        private void fetchUserEvents()
        {
            try
            {
                List<Event> userEvents = r_AppEngine.FetchUserEvents();
                listBoxEvents.Items.Clear();

                if(userEvents.Count == 0)
                {
                    listBoxEvents.Items.Add("No Events to retrieve");
                }
                else
                {
                    foreach(Event fbEvent in userEvents)
                    {
                        listBoxEvents.Items.Add(fbEvent.Name);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
        }

        private void fetchUserAlbums()
        {
            try
            {
                List<Album> userAlbums = r_AppEngine.FetchUserAlbums();
                listBoxAlbums.Items.Clear();

                if(userAlbums.Count == 0)
                {
                    listBoxAlbums.Items.Add("No Albums to retrieve");
                }
                else
                {
                    foreach(Album album in userAlbums)
                    {
                        listBoxAlbums.Items.Add(album.Name);
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
            
        }

        private void fetchUserPosts()
        {
            try
            {
                List<Post> userPosts = r_AppEngine.FetchUserPosts();
                listBoxUserPosts.Items.Clear();

                if(userPosts.Count == 0)
                {
                    listBoxUserPosts.Items.Add("No Posts to retrieve");
                }
                else
                {
                    foreach(Post post in userPosts)
                    {
                        listBoxUserPosts.Items.Add(post.Caption ?? string.Format("[{0}]", post.Type));
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
            
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            
            if(r_AppEngine.LoginResult.LoggedInUser.Events.Count == 0)
            {
                richTextBoxDescription.Text = k_NoDescription;
            }
            else
            {
                try
                {
                    richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser
                        .Events[listBoxEvents.SelectedIndex].Description;
                    pictureBoxEvents.Load(
                        r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex].PictureNormalURL);
                }
                catch(Exception exception)
                {
                    if(r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex].Pictures != null)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }

                    richTextBoxDescription.Text = k_NoDescription;
                }
            }
        }

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            if(r_AppEngine.LoginResult.LoggedInUser.LikedPages.Count == 0)
            {
                richTextBoxDescription.Text = k_NoDescription;
            }
            else
            {
                try
                {
                    richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser
                        .LikedPages[listBoxLikedPages.SelectedIndex].Description;
                    pictureBoxLikedPages.Load(
                        r_AppEngine.LoginResult.LoggedInUser.LikedPages[listBoxLikedPages.SelectedIndex]
                            .PictureNormalURL);
                }
                catch(Exception exception)
                {
                    if(r_AppEngine.LoginResult.LoggedInUser.LikedPages.Count != 0 || r_AppEngine.LoginResult
                           .LoggedInUser.LikedPages[listBoxLikedPages.SelectedIndex].Pictures != null)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }

                    richTextBoxDescription.Text = k_NoDescription;
                }
            }
        }

        private void listBoxUserPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            
            if(r_AppEngine.LoginResult.LoggedInUser.Posts.Count == 0)
            {
                richTextBoxDescription.Text = k_NoDescription;
            }
            else
            {
                try
                {
                    richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser
                        .Posts[listBoxUserPosts.SelectedIndex].Message;
                    //pictureBoxMyPosts.Load(
                     //   r_AppEngine.LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex].PictureURL);
                    pictureBoxMyPosts.ImageLocation = r_AppEngine.LoginResult.LoggedInUser
                        .Posts[listBoxUserPosts.SelectedIndex].PictureURL;
                }
                catch(Exception exception)
                {
                    if(r_AppEngine.LoginResult.LoggedInUser
                           .Posts[listBoxUserPosts.SelectedIndex].PictureURL != null)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }

                    richTextBoxDescription.Text = k_NoDescription;
                }
            }
        }

        private void buttonFetchEvents_Click(object sender, EventArgs e)
        {
            fetchUserEvents();
        }

        private void buttonFetchAlbums_Click(object sender, EventArgs e)
        {
            fetchUserAlbums();
        }

        private void buttonLikedPages_Click(object sender, EventArgs e)
        {
            fetchUserLikedPages();
        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            fetchUserPosts();
        }

        private void buttonFetchGroups_Click(object sender, EventArgs e)
        {
            fetchUserFavoriteTeams();
        }

        private void listBoxFavoriteTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();

            if(r_AppEngine.LoginResult.LoggedInUser.FavofriteTeams.Length == 0)
            {
                richTextBoxDescription.Text = k_NoDescription;
            }
            else
            {
                try
                {
                    richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser
                        .FavofriteTeams[listBoxFavoriteTeams.SelectedIndex].Description;
                    pictureBoxGroups.Load(
                        r_AppEngine.LoginResult.LoggedInUser.FavofriteTeams[listBoxFavoriteTeams.SelectedIndex]
                            .PictureURL);
                }
                catch(Exception exception)
                {
                    if(r_AppEngine.LoginResult.LoggedInUser.
                           FavofriteTeams[listBoxFavoriteTeams.SelectedIndex].PictureURL != null)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }

                    richTextBoxDescription.Text = k_NoDescription;
                }
            }
        }

        private void buttonFetchUserPostCreatedPerMonthGraph_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> userPostsCreatedPerMonth = r_AppEngine.FetchUserPostCreatedPerMonth();
            
            chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.Clear();
            chartUserCreatedPostsPerMonth.TabIndex = userPostsCreatedPerMonth.Keys.Count;
            foreach(KeyValuePair<string, int> pair in userPostsCreatedPerMonth)
            {
                chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.AddXY(pair.Key, pair.Value);
            }
        }

        private void buttonShowEventOnBirthdayMonth_Click(object sender, EventArgs e)
        {
            List<Event> eventsOnBirthdayMonth = r_AppEngine.FetchEventsOnBirthdayMonth();
            
            listBoxEventsOnUserBirthdayMonth.Items.Clear();
            if(eventsOnBirthdayMonth.Count == 0)
            {
                listBoxEventsOnUserBirthdayMonth.Items.Add("No Events to retrieve");
            }
            else
            {
                foreach(Event eventOnBirthdayMonth in eventsOnBirthdayMonth)
                {
                    listBoxEventsOnUserBirthdayMonth.Items.Add(eventOnBirthdayMonth.Name);
                }
            }
        }

        private void listBoxEventsOnUserBirthdayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxEventOnUserBirthDayMonth.Clear();
            if(r_AppEngine.LoginResult.LoggedInUser.Events.Count == 0)
            {
                richTextBoxEventOnUserBirthDayMonth.Text = k_NoDescription;
            }
            else
            {
                try
                {
                    richTextBoxEventOnUserBirthDayMonth.Text = r_AppEngine.LoginResult.LoggedInUser
                        .Events[listBoxEventsOnUserBirthdayMonth.SelectedIndex].Description;
                    pictureBoxEventsOnUserBirthdayMonth.Load(r_AppEngine.LoginResult.LoggedInUser.
                            Events[listBoxEventsOnUserBirthdayMonth.SelectedIndex].PictureNormalURL);
                }
                catch(Exception exception)
                {
                    if(r_AppEngine.LoginResult.LoggedInUser.
                           Events[listBoxEventsOnUserBirthdayMonth.SelectedIndex].Pictures != null)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }

                    richTextBoxEventOnUserBirthDayMonth.Text = k_NoDescription;
                }
            }
        }

        private void comboBoxAppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_AppEngine.AppID = comboBoxAppID.Items[comboBoxAppID.SelectedIndex].ToString();

        }

        private void buttonAddAppID_Click(object sender, EventArgs e)
        {
            comboBoxAppID.Items.Add(comboBoxAppID.Text);
        }
    }
}
