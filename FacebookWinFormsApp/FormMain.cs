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

            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                buttonLogin.BackColor = Color.LightGreen;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                buttonFetchData.Enabled = true;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            r_AppEngine.LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            richTextBoxDescription.Text = m_LoginResult.LoggedInUser.Albums[listBoxAlbums.SelectedIndex].Description;
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
        }

        private void fetchUserLikedPages()
        {
            listBoxGroups.Items.Clear();
            List<Page> userLikedPages = r_AppEngine.FetchUserLikedPages();

            if(userLikedPages.Count == 0)
            {
                listBoxGroups.Items.Add("No Liked Pages to retrieve");
            }
            else
            {
                foreach(Page page in userLikedPages)
                {
                    listBoxGroups.Items.Add(page.Name);
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
            }
            catch(Exception exception)
            {
                if(r_AppEngine.LoginResult.LoggedInUser.Events.Count != 0)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }
                richTextBoxDescription.Text = k_NoDescription;
            }
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            try
            {
                richTextBoxDescription.Text =
                    m_LoginResult.LoggedInUser.LikedPages[listBoxGroups.SelectedIndex].Description;
            }
            catch(Exception exception)
            {
                if(m_LoginResult.LoggedInUser.LikedPages.Count != 0)
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
                richTextBoxDescription.Text = m_LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex].Message;
            }
            catch (Exception exception)
            {
                if(m_LoginResult.LoggedInUser.Posts.Count != 0)
                {
                    MessageBox.Show($@"Error: {exception.Message}");
                }

                richTextBoxDescription.Text = k_NoDescription;
            }
        }
    }
}
