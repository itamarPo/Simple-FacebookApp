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
            textBoxAppID.Text = r_AppEngine.AppID;

            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            r_AppEngine.LoginResult = FacebookService.Login(
                /// (This is Desig Patter's App ID. replace it with your own)
                textBoxAppID.Text,
                /// requested permissions:
                "email",
                "public_profile",
                "user_events",
                "user_likes",
                "user_posts",
                "user_photos"
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
            buttonFetchGroups.Enabled = true;
        }

        private void disableButtons()
        {
            buttonFetchAllData.Enabled = false;
            buttonFetchAlbums.Enabled = false;
            buttonFetchEvents.Enabled = false;
            buttonFetchLikedPages.Enabled = false;
            buttonFetchPosts.Enabled = false;
            buttonFetchGroups.Enabled = false;
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
            fetchUserGroups();
        }

        private void fetchUserGroups()
        {
            try
            {
                List<Group> userGroups = r_AppEngine.FetchUserGroups();
                listBoxGroups.Items.Clear();
                if(userGroups.Count == 0)
                {
                    listBoxGroups.Items.Add("No Groups to retrieve");
                }
                else
                {
                    foreach(Group group in userGroups)
                    {
                        listBoxGroups.Items.Add(group.Name);
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
            try
            {
                richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex].Description;
                pictureBoxEvents.Load(r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex].PictureNormalURL);
            }
            catch(Exception exception)
            {
                if(r_AppEngine.LoginResult.LoggedInUser.Events.Count != 0 ||
                   r_AppEngine.LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex].Pictures != null)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }

                richTextBoxDescription.Text = k_NoDescription;
            }
        }

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            try
            {
                richTextBoxDescription.Text =
                    r_AppEngine.LoginResult.LoggedInUser.LikedPages[listBoxLikedPages.SelectedIndex].Description;
                pictureBoxLikedPages.Load(r_AppEngine.LoginResult.LoggedInUser.LikedPages[listBoxLikedPages.SelectedIndex].PictureNormalURL);
            }
            catch(Exception exception)
            {
                if(r_AppEngine.LoginResult.LoggedInUser.LikedPages.Count != 0 ||
                   r_AppEngine.LoginResult.LoggedInUser.LikedPages[listBoxLikedPages.SelectedIndex].Pictures != null)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }

                richTextBoxDescription.Text = k_NoDescription;
            }
        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {
            r_AppEngine.AppID = textBoxAppID.Text;
        }

        private void listBoxUserPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            try
            {
                richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex].Message;
                pictureBoxMyPosts.Load(r_AppEngine.LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex].PictureURL);
            }
            catch (Exception exception)
            {
                if(r_AppEngine.LoginResult.LoggedInUser.Posts.Count != 0 ||
                   r_AppEngine.LoginResult.LoggedInUser.Posts[listBoxLikedPages.SelectedIndex].PictureURL != null)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }

                richTextBoxDescription.Text = k_NoDescription;
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
            fetchUserGroups();
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            try
            {
                richTextBoxDescription.Text = r_AppEngine.LoginResult.LoggedInUser.Groups[listBoxGroups.SelectedIndex]
                    .Description;
                pictureBoxGroups.Load(
                    r_AppEngine.LoginResult.LoggedInUser.Groups[listBoxGroups.SelectedIndex].PictureNormalURL);
            }
            catch(Exception exception)
            {
                if(r_AppEngine.LoginResult.LoggedInUser.Groups.Count != 0
                   || r_AppEngine.LoginResult.LoggedInUser.Groups[listBoxGroups.SelectedIndex].Pictures != null)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }

                richTextBoxDescription.Text = k_NoDescription;
            }
        }

    }
}
