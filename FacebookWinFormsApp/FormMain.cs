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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        private FacebookWrapper.LoginResult m_LoginResult;
        private string m_AppID = "1542194956558397";

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            textBoxAppID.Text = m_AppID;

            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
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
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
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

            foreach(Page page in m_LoginResult.LoggedInUser.LikedPages)
            {
                listBoxGroups.Items.Add(page.Name);
            }

            if(listBoxGroups.Items.Count == 0)
            {
                listBoxGroups.Items.Add("No Liked Pages to retrieve");
            }
        }

        private void fetchUserEvents()
        {
            listBoxEvents.Items.Clear();

            foreach(Event fbEvent in m_LoginResult.LoggedInUser.Events)
            {
                listBoxEvents.Items.Add(fbEvent.Name);
            }

            if(listBoxEvents.Items.Count == 0)
            {
                listBoxEvents.Items.Add("No Events to retrieve");
            }
        }

        private void fetchUserAlbums()
        {
            listBoxAlbums.Items.Clear();

            foreach(Album album in m_LoginResult.LoggedInUser.Albums)
            {
                listBoxAlbums.Items.Add(album.Name);
            }

            if(listBoxAlbums.Items.Count == 0)
            {
                listBoxAlbums.Items.Add("No Albums to retrieve");
            }
        }

        private void fetchUserPosts()
        {
            listBoxUserPosts.Items.Clear();

            foreach(Post post in m_LoginResult.LoggedInUser.Posts)
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
                    listBoxUserPosts.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if(listBoxUserPosts.Items.Count == 0)
            {
                listBoxUserPosts.Items.Add("No Posts to retrieve");
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            richTextBoxDescription.Text = m_LoginResult.LoggedInUser.Events[listBoxEvents.SelectedIndex].Description;
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            richTextBoxDescription.Text = m_LoginResult.LoggedInUser.LikedPages[listBoxGroups.SelectedIndex].Description;
        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {
            m_AppID = textBoxAppID.Text;
        }

        private void listBoxUserPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxDescription.Clear();
            richTextBoxDescription.Text = m_LoginResult.LoggedInUser.Posts[listBoxUserPosts.SelectedIndex].Message;
        }
    }
}
