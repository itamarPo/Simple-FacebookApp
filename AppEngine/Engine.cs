using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace AppEngine
{
    public sealed class Engine
    {
        private Engine() { }
        public bool IsLoggedIn { get; set; }
        public LoginResult LoginResult { get; set; }
        public string AppID { get; set; }

        public List<Post> FetchUserPosts()
        {
            try
            {
               return LoginResult.LoggedInUser.Posts.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception($"Failed to fetch user posts: {exception.Message}");
            }
        }

        public List<Page> FetchUserLikedPages()
        {
            try
            {
                return LoginResult.LoggedInUser.LikedPages.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception($"Failed to fetch user liked pages: {exception.Message}");
            }
        }

        public List<Event> FetchUserEvents()
        {
            try
            {
                return LoginResult.LoggedInUser.Events.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception($"Failed to fetch user events: {exception.Message}");
            }
        }

        public List<Album> FetchUserAlbums()
        {
            try
            {
                return LoginResult.LoggedInUser.Albums.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception($"Failed to fetch user albums: {exception.Message}");
            }
        }

        public List<Page> FetchFavoriteTeams()
        {
            try
            {
                return LoginResult.LoggedInUser.FavofriteTeams.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception($"Failed to fetch user groups: {exception.Message}");
            }
        }

        //inject strategy somewhere
        public Dictionary<string, int> FetchUserPostCreatedPerMonth()
        {
            string postMonth;
            List<Post> userPosts = FetchUserPosts();
            Dictionary<string, int> postsPerMonth = getMonthDictionary();

            foreach(Post post in userPosts)
            {
                if(post.CreatedTime != null)
                {
                    postMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(post.CreatedTime.Value.Month);
                    postsPerMonth[postMonth]++;
                }
            }

            return postsPerMonth;
        }

        public List<Event> FetchEventsOnBirthdayMonth()
        {
            AdapterUserDetails adapterUserDetails = new AdapterUserDetails();
            List<Event> userEvents = FetchUserEvents();
            foreach(Event userEvent in userEvents)
            {
                if(userEvent.StartTime != null)
                {
                    if(userEvent.StartTime.Value.Month == adapterUserDetails.GetUserBirthday().Month)
                    {
                        userEvents.Add(userEvent);
                    }
                }
            }

            return userEvents;
        }

        //might inject strategy
        private Dictionary<string, int> getMonthDictionary()
        {
            Dictionary<string, int> monthDictionary = new Dictionary<string, int>();

            for(int i = 1; i <= 12; i++)
            {
                monthDictionary.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i), 0);
            }

            return monthDictionary;
        }
    }
}
