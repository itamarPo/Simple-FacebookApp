using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using AppEngine;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly EngineSingleton r_AppEngineSingleton = EngineSingleton.Instance;
        private const string k_NoDescription = "No Description to retrieve";

        public event Action ChangedSortCheckBox;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            ChangedSortCheckBox += changeUserPostsPerMonth;
        }

        private void buttonLogin_Click(object i_Sender, EventArgs i_)
        {
            Clipboard.SetText("design.patterns");

            if(comboBoxAppID.SelectedIndex > -1)
            {
                if(!r_AppEngineSingleton.IsLoggedIn)
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
            r_AppEngineSingleton.LoginResult = FacebookService.Login(
                r_AppEngineSingleton.AppID,
                "email",
                "public_profile",
                "user_events",
                "user_likes",
                "user_posts",
                "user_photos",
                "user_birthday",
                "user_hometown",
                "user_location",
                "user_gender"
            );
            try
            {
                if(r_AppEngineSingleton.LoginResult == null || r_AppEngineSingleton.LoginResult.LoggedInUser == null)
                {
                    MessageBox.Show(@"Please Login to continue");
                }
                else if(string.IsNullOrEmpty(r_AppEngineSingleton.LoginResult.ErrorMessage))
                {
                    buttonLogin.Invoke(new Action(() =>
                        buttonLogin.Text = $@"Logged in as {r_AppEngineSingleton.LoginResult.LoggedInUser.Name}"));
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = r_AppEngineSingleton.LoginResult.LoggedInUser.PictureNormalURL;
                    buttonLogin.Invoke(new Action(() => buttonLogin.Enabled = false));
                    buttonLogout.Invoke(new Action(() => buttonLogout.Enabled = true));
                    new Thread(enableButtons).Start();
                    r_AppEngineSingleton.IsLoggedIn = true;
                    labelPleaseLogin.Invoke(new Action(() => labelPleaseLogin.Visible = false));
                    comboBoxAppID.Invoke(new Action(() => comboBoxAppID.Enabled = false));
                    new Thread(fetchSortTypes).Start();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Unable to login {Environment.NewLine} Error:{exception.Message}");
                r_AppEngineSingleton.LoginResult = null;
            }
        }

        private void enableButtons()
        {
            buttonFetchAllData.Invoke(new Action(() => buttonFetchAllData.Enabled = true));
            buttonFetchAlbums.Invoke(new Action(() => buttonFetchAlbums.Enabled = true));
            buttonFetchEvents.Invoke(new Action(() => buttonFetchEvents.Enabled = true));
            buttonFetchLikedPages.Invoke(new Action(() => buttonFetchLikedPages.Enabled = true));
            buttonFetchPosts.Invoke(new Action(() => buttonFetchPosts.Enabled = true));
            buttonFavoriteTeams.Invoke(new Action(() => buttonFavoriteTeams.Enabled = true));
            buttonPostStatus.Invoke(new Action(() => buttonPostStatus.Enabled = true));
            tabPageSpecialFeatures.Invoke(new Action(() => tabPageSpecialFeatures.Enabled = true));
            textBoxStatus.Invoke(new Action(() => textBoxStatus.ReadOnly = false));
            comboBoxSortOrder.Invoke(new Action(() => comboBoxSortOrder.Enabled = true));
        }

        private void disableButtons()
        {
            buttonFetchAllData.Invoke(new Action(() => buttonFetchAllData.Enabled = false));
            buttonFetchAlbums.Invoke(new Action(() => buttonFetchAlbums.Enabled = false));
            buttonFetchEvents.Invoke(new Action(() => buttonFetchEvents.Enabled = false));
            buttonFetchLikedPages.Invoke(new Action(() => buttonFetchLikedPages.Enabled = false));
            buttonFetchPosts.Invoke(new Action(() => buttonFetchPosts.Enabled = false));
            buttonFavoriteTeams.Invoke(new Action(() => buttonFavoriteTeams.Enabled = false));
            buttonPostStatus.Invoke(new Action(() => buttonPostStatus.Enabled = false));
            tabPageSpecialFeatures.Invoke(new Action(() => tabPageSpecialFeatures.Enabled = false));
            textBoxStatus.Invoke(new Action(() => textBoxStatus.ReadOnly = true));
            comboBoxSortOrder.Invoke(new Action(() => comboBoxSortOrder.Enabled = false));
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            r_AppEngineSingleton.LoginResult = null;
            r_AppEngineSingleton.IsLoggedIn = false;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            labelPleaseLogin.Visible = true;
            pictureBoxProfile.ImageLocation = null;
            comboBoxAppID.Enabled = true;
            eventOnUserBirthDayBindingSource.Clear();
            new Thread(clearUi).Start();
            new Thread(disableButtons).Start();
        }

        private void clearUi()
        {
            listBoxUserPosts.Invoke(new Action(() => listBoxUserPosts.Items.Clear()));
            listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Clear()));
            listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Clear()));
            listBoxLikedPages.Invoke(new Action(() => listBoxLikedPages.Items.Clear()));
            listBoxFavoriteTeams.Invoke(new Action(() => listBoxFavoriteTeams.Items.Clear()));
            richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Clear()));
            pictureBoxAlbums.ImageLocation = null;
            pictureBoxEvents.ImageLocation = null;
            pictureBoxLikedPages.ImageLocation = null;
            pictureBoxFavoriteTeams.ImageLocation = null;
            pictureBoxMyPosts.ImageLocation = null;
            pictureBoxEventsOnUserBirthdayMonth.ImageLocation = null;
            chartUserCreatedPostsPerMonth.Invoke(new Action(() =>
                chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.Clear()));
            chartUserCreatedPostsPerMonth.Invoke(new Action(() =>
                chartUserCreatedPostsPerMonth.Titles.Clear()));
            chartUserCreatedPostsPerMonth.Invoke(new Action(() => chartUserCreatedPostsPerMonth.Visible = false));
        }

        private void fetchSortTypes()
        {
            List<string> sortTypes = r_AppEngineSingleton.FetchSortType();

            foreach(string sortType in sortTypes)
            {
                comboBoxSortOrder.Invoke(new Action(() => 
                    comboBoxSortOrder.Items.Add(sortType)));
            }
            
            comboBoxSortOrder.Invoke(new Action(() => comboBoxSortOrder.SelectedIndex = 0));
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album userAlbum;

            richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Clear()));
            if(listBoxAlbums.SelectedIndex >= 0)
            {
                if(listBoxAlbums.Items.Count == 0)
                {
                    richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = k_NoDescription));
                }
                else
                {
                    try
                    {
                        userAlbum = listBoxAlbums.SelectedItem as Album;
                        richTextBoxDescription.Invoke(new Action(() => 
                            richTextBoxDescription.Text = userAlbum.Description ?? k_NoDescription));

                        if(userAlbum.PictureAlbumURL != null)
                        {
                            pictureBoxAlbums.LoadAsync(userAlbum.PictureAlbumURL);
                        }
                        else
                        {
                            pictureBoxAlbums.ImageLocation = null;
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
           new Thread(fetchUserInfo).Start();
        }

        private void fetchUserInfo()
        {
            new Thread(fetchUserPosts).Start();
            new Thread(fetchUserAlbums).Start();
            new Thread(fetchUserEvents).Start();
            new Thread(fetchUserLikedPages).Start();
            new Thread(fetchUserFavoriteTeams).Start();
        }

        private void fetchUserFavoriteTeams()
        {
            try
            {
                List<Page> favoriteTeams = r_AppEngineSingleton.FetchFavoriteTeams();
                listBoxFavoriteTeams.Invoke(new Action(() =>  listBoxFavoriteTeams.Items.Clear()));
                listBoxFavoriteTeams.Invoke(new Action(() => listBoxFavoriteTeams.DisplayMember = "Name"));

                if(favoriteTeams.Count == 0)
                {
                    listBoxFavoriteTeams.Invoke(new Action(() => listBoxFavoriteTeams.Items.Add("@No liked Teams to retrieve")));
                    listBoxFavoriteTeams.Invoke(new Action(() => listBoxFavoriteTeams.Enabled = false));
                }
                else
                {
                    foreach(Page team in favoriteTeams)
                    {
                        listBoxFavoriteTeams.Invoke(
                            new Action(() => listBoxFavoriteTeams.Items.Add(team)));
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
            try
            {
                List<Page> userLikedPages = r_AppEngineSingleton.FetchUserLikedPages();
                listBoxLikedPages.Invoke(new Action(() => listBoxLikedPages.Items.Clear()));
                listBoxLikedPages.Invoke(
                    new Action(() => listBoxLikedPages.DisplayMember = "Name"));

                if(userLikedPages.Count == 0)
                {
                    listBoxLikedPages.Invoke(new Action(() =>
                        listBoxLikedPages.Items.Add(@"No Liked Pages to retrieve")));
                    listBoxLikedPages.Invoke(
                        new Action(() => listBoxLikedPages.Enabled = false));
                }
                else
                {
                    listBoxLikedPages.Invoke(
                        new Action(() => listBoxLikedPages.Enabled = true));
                    foreach (Page page in userLikedPages)
                    {
                        listBoxLikedPages.Invoke(
                            new Action(() => listBoxLikedPages.Items.Add(page)));
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
        }

        private void fetchUserEvents()
        {
            try
            {
                List<Event> userEvents = r_AppEngineSingleton.FetchUserEvents();
                listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Clear()));
                listBoxEvents.Invoke(new Action(() => listBoxEvents.DisplayMember = "Name"));

                if(userEvents.Count == 0)
                {
                    listBoxEvents.Invoke(new Action(()=> 
                        listBoxEvents.Items.Add(@"No Events to retrieve")));
                    listBoxEvents.Invoke(new Action(() => listBoxEvents.Enabled = false));
                }
                else
                {
                    listBoxEvents.Enabled = true;
                    foreach(Event fbEvent in userEvents)
                    {
                        listBoxEvents.Invoke(new Action(() => listBoxEvents.Items.Add(fbEvent)));
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
                List<Album> userAlbums = r_AppEngineSingleton.FetchUserAlbums();
                listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Clear()));
                listBoxAlbums.Invoke(new Action(() => listBoxAlbums.DisplayMember = "Name"));

                if(userAlbums.Count == 0)
                {
                    
                    listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(@"No Albums to retrieve")));
                    listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Enabled = false));
                }
                else
                {
                    listBoxAlbums.Enabled = true;
                    foreach(Album album in userAlbums)
                    {
                        listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(album)));
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
                List<Post> userPosts = r_AppEngineSingleton.FetchUserPosts();
                listBoxUserPosts.Invoke(new Action(()=> listBoxUserPosts.Items.Clear()));
                listBoxUserPosts.Invoke(new Action(() => listBoxUserPosts.DisplayMember = "Message"));

                if(userPosts.Count == 0)
                {
                    listBoxUserPosts.Invoke(new Action(()=>
                        listBoxUserPosts.Items.Add("No Posts To retrieve")));
                    listBoxUserPosts.Enabled = false;
                }
                else
                {
                    listBoxUserPosts.Invoke(new Action(() => listBoxUserPosts.Enabled = true));

                    foreach(Post post in userPosts)
                    {
                        if(post.Message != null)
                        {
                            listBoxUserPosts.Invoke(new Action(()=>listBoxUserPosts.Items.Add(post.Message)));
                        }
                        else if(post.Caption != null)
                        {
                            listBoxUserPosts.Invoke(new Action(()=>listBoxUserPosts.Items.Add(post.Caption)));
                        }
                        else
                        {
                            listBoxUserPosts.Invoke(new Action(()=>listBoxUserPosts.Items.Add($"{post.Type}")));
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

            richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Clear()));
            if(listBoxEvents.SelectedIndex >= 0)
            {
                if(!listBoxEvents.Enabled)
                {
                    richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = k_NoDescription));
                }
                else
                {
                    try
                    {
                        selectedEvent = listBoxEvents.SelectedItem as Event;
                        richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = selectedEvent.Description ?? k_NoDescription));

                        if(selectedEvent.PictureNormalURL != null)
                        {
                            pictureBoxEvents.LoadAsync(selectedEvent.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxEvents.ImageLocation = null;
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

            richTextBoxDescription.Invoke(new Action(()=>richTextBoxDescription.Clear()));
            if(listBoxLikedPages.SelectedIndex >= 0)
            {
                if(!listBoxLikedPages.Enabled)
                {
                    richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = k_NoDescription));
                }
                else
                {
                    try
                    {
                        likedPage = listBoxLikedPages.SelectedItem as Page;
                        richTextBoxDescription.Invoke(new Action(()=>
                            richTextBoxDescription.Text = likedPage.Description ?? k_NoDescription));

                        if(likedPage.PictureNormalURL != null)
                        {
                            pictureBoxLikedPages.LoadAsync(likedPage.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxLikedPages.ImageLocation = null;
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

            richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Clear()));
            if(listBoxUserPosts.SelectedIndex >= 0)
            {
                if(!listBoxUserPosts.Enabled)
                {
                    richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = k_NoDescription));
                }
                else
                {
                    try
                    {
                        selectedUserPost = r_AppEngineSingleton.LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex];
                        richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = selectedUserPost.Message ?? k_NoDescription));
                        if(selectedUserPost.PictureURL != null)
                        {
                            pictureBoxMyPosts.LoadAsync(selectedUserPost.PictureURL);
                        }
                        else
                        {
                            pictureBoxMyPosts.ImageLocation = null;
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
            new Thread(fetchUserEvents).Start();
        }

        private void buttonFetchAlbums_Click(object sender, EventArgs e)
        {
            new Thread(fetchUserAlbums).Start();
        }

        private void buttonLikedPages_Click(object sender, EventArgs e)
        {
            new Thread(fetchUserLikedPages).Start();
        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            new Thread(fetchUserPosts).Start();
        }

        private void buttonFetchFavoriteTeams_Click(object sender, EventArgs e)
        {
            new Thread(fetchUserFavoriteTeams).Start();
        }

        private void listBoxFavoriteTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page favoriteTeamPage;

            richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Clear()));
            if(listBoxFavoriteTeams.SelectedIndex >= 0)
            {
                if(!listBoxFavoriteTeams.Enabled
                   || listBoxFavoriteTeams.SelectedIndex > listBoxFavoriteTeams.Items.Count)
                {
                    richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = k_NoDescription));
                }
                else
                {
                    try
                    {
                        favoriteTeamPage = listBoxFavoriteTeams.SelectedItem as Page;
                        richTextBoxDescription.Invoke(new Action(() => richTextBoxDescription.Text = favoriteTeamPage.Description ?? k_NoDescription));

                        if(favoriteTeamPage.PictureNormalURL != null)
                        {
                            pictureBoxFavoriteTeams.LoadAsync(favoriteTeamPage.PictureNormalURL);
                        }
                        else
                        {
                            pictureBoxFavoriteTeams.ImageLocation = null;
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
            new Thread(fetchUserPostCreatedPerMonth).Start();
        }

        private void fetchUserPostCreatedPerMonth()
        {
            List<KeyValuePair<string, int>> userPostsCreatedPerMonth;

            try
            {
                userPostsCreatedPerMonth = r_AppEngineSingleton.FetchUserPostCreatedPerMonth();
                chartUserCreatedPostsPerMonth.Invoke(
                    new Action(() => chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points.Clear()));
                foreach(KeyValuePair<string, int> month in userPostsCreatedPerMonth)
                {
                    chartUserCreatedPostsPerMonth.Invoke(
                        new Action(
                            () => chartUserCreatedPostsPerMonth.Series["Number of Posts"].Points
                                .AddXY(month.Key, month.Value)));
                }

                chartUserCreatedPostsPerMonth.Invoke(new Action(() => chartUserCreatedPostsPerMonth.Visible = true));
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
        }

        private void buttonShowEventOnBirthdayMonth_Click(object sender, EventArgs e)
        {
            new Thread(fetchEventsOnBirthdayMonth).Start();
        }

        private void fetchEventsOnBirthdayMonth()
        {
            try
            {
                listBoxEventsOnUserBirthdayMonth.Invoke(new Action(() =>
                    eventOnUserBirthDayBindingSource.DataSource = r_AppEngineSingleton.FetchEventsOnBirthdayMonth()));
            }
            catch(Exception exception)
            {
                MessageBox.Show($@"Error getting events: {exception.Message}");
            }
        }

        
        private void comboBoxAppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_AppEngineSingleton.AppID = comboBoxAppID.Items[comboBoxAppID.SelectedIndex].ToString();
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
            new Thread(postStatus).Start();
        }

        private void postStatus()
        {
            Status statusToPost;

            try
            {
                textBoxStatus.Invoke(
                    new Action(() =>
                        { 
                            if(textBoxStatus.Text != string.Empty)
                            {
                                statusToPost =
                                    r_AppEngineSingleton.LoginResult.LoggedInUser.PostStatus(textBoxStatus.Text);
                                MessageBox.Show("Status Posted! ID: " + statusToPost.Id);
                            }
                        }));
            }
            catch(Exception exception)
            {
                MessageBox.Show(
                    string.Format(
                        @"Error, unable to post at the moment.{0}Error Details: {1}",
                        Environment.NewLine,
                        exception.Message));
            }
        }

        private void changeUserPostsPerMonth()
        {
            if(chartUserCreatedPostsPerMonth.Visible)
            {
                buttonFetchUserPostCreatedPerMonthGraph_Click(null, EventArgs.Empty);
            }
        }

        private void comboBoxSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSortOrder.SelectedIndex != -1 && 
               r_AppEngineSingleton.SortType != (eSortType)comboBoxSortOrder.SelectedIndex)
            {
                r_AppEngineSingleton.SortType = (eSortType)comboBoxSortOrder.SelectedIndex;
                ChangedSortCheckBox?.Invoke();
            }
        }
        
    }
}
