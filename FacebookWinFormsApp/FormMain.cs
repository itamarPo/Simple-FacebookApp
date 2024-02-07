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
        private const string k_NoDescription = "No Description to retrieve";

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if(comboBoxAppID.SelectedIndex > -1)
            {
                if(!r_AppEngine.IsLoggedIn)
                {
                    login();
                }
            }
            else
            {
                MessageBox.Show(@"Please select an App ID");
            }
        }

        private void login()
        {
            r_AppEngine.LoginResult = FacebookService.Login(
                r_AppEngine.AppID,
                "email",
                "public_profile",
                "user_events",
                "user_likes",
                "user_posts",
                "user_photos",
                "user_birthday"
            );
            try
            {
                if(r_AppEngine.LoginResult == null || r_AppEngine.LoginResult.LoggedInUser == null)
                {
                    MessageBox.Show(@"Please Login to continue");
                }
                else if(string.IsNullOrEmpty(r_AppEngine.LoginResult.ErrorMessage))
                {
                    buttonLogin.Text = $@"Logged in as {r_AppEngine.LoginResult.LoggedInUser.Name}";
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = r_AppEngine.LoginResult.LoggedInUser.PictureNormalURL;
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;
                    enableButtons();
                    r_AppEngine.IsLoggedIn = true;
                    labelPleaseLogin.Visible = false;
                    comboBoxAppID.Enabled = false;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Unable to login {Environment.NewLine} Error:{exception.Message}");
                r_AppEngine.LoginResult = null;
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
            buttonPostStatus.Enabled = true;
            tabPageSpecialFeatures.Enabled = true;
            textBoxStatus.ReadOnly = false;
        }

        private void disableButtons()
        {
            buttonFetchAllData.Enabled = false;
            buttonFetchAlbums.Enabled = false;
            buttonFetchEvents.Enabled = false;
            buttonFetchLikedPages.Enabled = false;
            buttonFetchPosts.Enabled = false;
            buttonFavoriteTeams.Enabled = false;
            buttonPostStatus.Enabled = false;
            tabPageSpecialFeatures.Enabled = false;
            textBoxStatus.ReadOnly = true;
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
            comboBoxAppID.Enabled = true;
            clearUI();
            disableButtons();
        }

        private void clearUI()
        {
            listBoxUserPosts.Items.Clear();
            listBoxAlbums.Items.Clear();
            listBoxEvents.Items.Clear();
            listBoxLikedPages.Items.Clear();
            listBoxFavoriteTeams.Items.Clear();
            listBoxEventsOnUserBirthdayMonth.Items.Clear();
            richTextBoxEventOnUserBirthDayMonth.Clear();
            richTextBoxDescription.Clear();
            pictureBoxAlbums.ImageLocation = null;
            pictureBoxEvents.ImageLocation = null;
            pictureBoxLikedPages.ImageLocation = null;
            pictureBoxFavoriteTeams.ImageLocation = null;
            pictureBoxMyPosts.ImageLocation = null;
            pictureBoxEventsOnUserBirthdayMonth.ImageLocation = null;
            chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.Clear();
            chartUserCreatedPostsPerMonth.Titles.Clear();
            chartUserCreatedPostsPerMonth.Visible = false;
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album userAlbum;
            richTextBoxDescription.Clear();
            if(listBoxAlbums.SelectedIndex >= 0)
            {
                if(listBoxAlbums.Items.Count == 0)
                {
                    richTextBoxDescription.Text = k_NoDescription;
                }
                else
                {
                    try
                    {
                        userAlbum = r_AppEngine.LoginResult.LoggedInUser.Albums[listBoxAlbums.SelectedIndex];
                        richTextBoxDescription.Text = userAlbum.Description ?? k_NoDescription;

                        if(userAlbum.PictureAlbumURL != null)
                        {
                            pictureBoxAlbums.Load(userAlbum.PictureAlbumURL);
                        }
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }
                }
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
                    listBoxFavoriteTeams.Text = @"No Favorite Teams to retrieve";
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
                listBoxLikedPages.Items.Add(@"No Liked Pages to retrieve");
                listBoxLikedPages.Enabled = false;
            }
            else
            {
                listBoxLikedPages.Enabled = true;
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
                    listBoxEvents.Items.Add(@"No Events to retrieve");
                    listBoxEvents.Enabled = false;
                }
                else
                {
                    listBoxEvents.Enabled = true;
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
                    
                    listBoxAlbums.Items.Add(@"No Albums to retrieve");
                    listBoxAlbums.Enabled = false;
                }
                else
                {
                    listBoxAlbums.Enabled = true;
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
                    listBoxUserPosts.Items.Add("No Posts To retrieve");
                    listBoxUserPosts.Enabled = false;
                }
                else
                {
                    listBoxUserPosts.Enabled = true;

                    foreach(Post post in userPosts)
                    {
                        if(post.Message != null)
                        {
                            listBoxUserPosts.Items.Add(post.Message);
                        }
                        else if(post.Caption != null)
                        {
                            listBoxUserPosts.Items.Add(post.Caption);
                        }
                        else
                        {
                            listBoxUserPosts.Items.Add($"{post.Type}");
                        }
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
            Event selectedEvent;
            richTextBoxDescription.Clear();
            if(listBoxEvents.SelectedIndex >= 0)
            {
                if(!listBoxEvents.Enabled)
                {
                    richTextBoxDescription.Text = k_NoDescription;
                }
                else
                {
                    try
                    {
                        selectedEvent = r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex];
                        richTextBoxDescription.Text = selectedEvent.Description ?? k_NoDescription;

                        if(selectedEvent.PictureNormalURL != null)
                        {
                            pictureBoxEvents.Load(selectedEvent.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxEvents.Image = null;
                        }
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }
                }
            }
        }

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page likedPage;
            richTextBoxDescription.Clear();
            if(listBoxLikedPages.SelectedIndex >= 0)
            {
                if(!listBoxLikedPages.Enabled)
                {
                    richTextBoxDescription.Text = k_NoDescription;
                }
                else
                {
                    try
                    {
                        likedPage = r_AppEngine.LoginResult.LoggedInUser.LikedPages[listBoxLikedPages.SelectedIndex];
                        richTextBoxDescription.Text = likedPage.Description ?? k_NoDescription;

                        if(likedPage.PictureNormalURL != null)
                        {
                            pictureBoxLikedPages.Load(likedPage.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxLikedPages.Image = null;
                        }
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }
                }
            }
        }

        private void listBoxUserPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Post selectedUserPost;
            richTextBoxDescription.Clear();
            if(listBoxUserPosts.SelectedIndex >= 0)
            {
                if(!listBoxUserPosts.Enabled)
                {
                    richTextBoxDescription.Text = k_NoDescription;
                }
                else
                {
                    try
                    {
                        selectedUserPost = r_AppEngine.LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex];
                        richTextBoxDescription.Text = selectedUserPost.Message ?? k_NoDescription;
                        if(selectedUserPost.PictureURL != null)
                        {
                            pictureBoxMyPosts.Load(selectedUserPost.PictureURL);
                        }
                        else
                        {
                            pictureBoxMyPosts.Image = null;
                        }
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }
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

        private void buttonFetchFavoriteTeams_Click(object sender, EventArgs e)
        {
            fetchUserFavoriteTeams();
        }

        private void listBoxFavoriteTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page favoriteTeamPage;
            richTextBoxDescription.Clear();
            if(listBoxFavoriteTeams.SelectedIndex >= 0)
            {
                if(!listBoxFavoriteTeams.Enabled
                   || listBoxFavoriteTeams.SelectedIndex > listBoxFavoriteTeams.Items.Count)
                {
                    richTextBoxDescription.Text = k_NoDescription;
                }
                else
                {
                    try
                    {
                        favoriteTeamPage =
                            r_AppEngine.LoginResult.LoggedInUser.FavofriteTeams[listBoxFavoriteTeams.SelectedIndex];
                        richTextBoxDescription.Text = favoriteTeamPage.Description ?? k_NoDescription;

                        if(favoriteTeamPage.PictureNormalURL != null)
                        {
                            pictureBoxFavoriteTeams.Load(favoriteTeamPage.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxFavoriteTeams.Image = null;
                        }
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }
                }
            }
        }

        private void buttonFetchUserPostCreatedPerMonthGraph_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> userPostsCreatedPerMonth = r_AppEngine.FetchUserPostCreatedPerMonth();
            
            chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.Clear();
            //chartUserCreatedPostsPerMonth.TabIndex = userPostsCreatedPerMonth.Keys.Count;
            foreach(KeyValuePair<string, int> pair in userPostsCreatedPerMonth)
            {
                chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.AddXY(pair.Key, pair.Value);
            }

            chartUserCreatedPostsPerMonth.Visible = true;
        }

        private void buttonShowEventOnBirthdayMonth_Click(object sender, EventArgs e)
        {
            List<Event> eventsOnBirthdayMonth = r_AppEngine.FetchEventsOnBirthdayMonth();
            
            listBoxEventsOnUserBirthdayMonth.Items.Clear();
            if(eventsOnBirthdayMonth.Count == 0)
            {
                listBoxEventsOnUserBirthdayMonth.Items.Add(@"No Events to retrieve");
                listBoxEventsOnUserBirthdayMonth.Enabled = false;
            }
            else
            {
                listBoxEventsOnUserBirthdayMonth.Enabled = true;
                foreach(Event eventOnBirthdayMonth in eventsOnBirthdayMonth)
                {
                    listBoxEventsOnUserBirthdayMonth.Items.Add(eventOnBirthdayMonth);
                }
            }
        }

        private void listBoxEventsOnUserBirthdayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event selectedEventOnBirthdayMonth;
            richTextBoxEventOnUserBirthDayMonth.Clear();

            if(listBoxEventsOnUserBirthdayMonth.SelectedIndex > 0)
            {
                if(!listBoxEventsOnUserBirthdayMonth.Enabled)
                {
                    richTextBoxEventOnUserBirthDayMonth.Text = k_NoDescription;
                }
                else
                {
                    try
                    {
                        selectedEventOnBirthdayMonth =
                            r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEventsOnUserBirthdayMonth.SelectedIndex];
                        richTextBoxEventOnUserBirthDayMonth.Text =
                            selectedEventOnBirthdayMonth.Description ?? k_NoDescription;

                        if(selectedEventOnBirthdayMonth.PictureNormalURL != null)
                        {
                            pictureBoxEventsOnUserBirthdayMonth.Load(selectedEventOnBirthdayMonth.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxEventsOnUserBirthdayMonth.Image = null;
                        }
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($@"Error: {exception.Message}");
                    }
                }
            }
        }

        private void comboBoxAppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_AppEngine.AppID = comboBoxAppID.Items[comboBoxAppID.SelectedIndex].ToString();
        }

        private void buttonAddAppID_Click(object sender, EventArgs e)
        {
            if(!comboBoxAppID.Items.Contains(comboBoxAppID.Text) && comboBoxAppID.Text != string.Empty)
            {
                comboBoxAppID.Items.Add(comboBoxAppID.Text);
            }
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            Status statusToPost;
            try
            {
                if(textBoxStatus.Text != string.Empty)
                {
                    statusToPost = r_AppEngine.LoginResult.LoggedInUser.PostStatus(textBoxStatus.Text);
                    MessageBox.Show("Status Posted! ID: " + statusToPost.Id);
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(
                    string.Format(@"Error, unable to post at the moment.{0}Error Details: {1}",
                    Environment.NewLine, exception.Message));
            }
        }
    }
}
