using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace AppEngine
{
    public class Engine
    {
        public string UserName { get; set; }

        public bool IsLoggedIn { get; set; }

        public LoginResult LoginResult { get; set; }

        public string AppID { get; set; } = "1542194956558397";

        public Engine()
        {
        }

        public List<Post> FetchUserPosts()
        {
            List<Post> userPosts = new List<Post>();
            try
            {
                userPosts.AddRange(LoginResult.LoggedInUser.Posts.Where(post => post.Message != null));
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed to fetch user posts: {exception.Message}");
            }

            return userPosts;
        }

        public List<Page> FetchUserLikedPages()
        {
            try
            {
                return LoginResult.LoggedInUser.LikedPages.ToList();
            }
            catch (Exception exception)
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
            catch (Exception exception)
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
            catch (Exception exception)
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

        public Dictionary<string, int> FetchUserPostCreatedPerMonth()
        {
            List<Post> userPosts = FetchUserPosts();
            Dictionary<string, int> postsPerMonth = new Dictionary<string, int>();
            foreach(Post post in userPosts)
            {
                if(post.CreatedTime != null)
                {
                    if(postsPerMonth.ContainsKey(post.CreatedTime.Value.Month.ToString()))
                    {
                        postsPerMonth[post.CreatedTime.Value.Month.ToString()]++;
                    }
                    else
                    {
                        postsPerMonth.Add(post.CreatedTime.Value.Month.ToString(), 1);
                    }
                }
            }

            return postsPerMonth;
        }

        public List<Event> FetchEventsOnBirthdayMonth()
        {
            List<Event> userEvents = FetchUserEvents();

            foreach(Event userEvent in userEvents)
            {
                if(userEvent.StartTime != null)
                {
                    //if(userEvent.StartTime.Value.Month == LoginResult.LoggedInUser.Birthday)
                   // {
                     //   return userEvents;
                    //}
                    
                }
            }

            return userEvents;
        }

        private int getBirthdayMonth()
        {
            string birthday = LoginResult.LoggedInUser.Birthday;
            return 0;
        }
    }
}
