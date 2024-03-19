using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
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
        public eSortType SortType { get; set; }

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
                List<Event> events = LoginResult.LoggedInUser.Events.ToList();
                FacebookWrapper.ObjectModel.Event userEvent = new FacebookWrapper.ObjectModel.Event
                                                                  {
                                                                      Description = "Check"
                                                                  };
                events.Add(userEvent);
                return events;
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
        public List<KeyValuePair<string, int>> FetchUserPostCreatedPerMonth()
        {
            string postMonth;
            List<KeyValuePair<string, int>> postPerMonthList;
            List<Post> userPosts = FetchUserPosts();
            Dictionary<string, int> postsPerMonth = getMonthDictionary();
            IPostMonthComparer postMonthComparer = getPostMonthComparer();
            PostByMonthSorter postByMonthSorter = new PostByMonthSorter(postMonthComparer);

            foreach(Post post in userPosts)
            {
                if(post.CreatedTime != null)
                {
                    postMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(post.CreatedTime.Value.Month);
                    postsPerMonth[postMonth]++;
                }
            }

            postPerMonthList = postsPerMonth.ToList();
            postByMonthSorter.SortPostsByMonth(postPerMonthList);

           return postPerMonthList;
        }

        public List<Event> FetchEventsOnBirthdayMonth()
        {
            IUserDetails userDetails = new AdapterUserDetails();
            List<Event> userEvents = FetchUserEvents();
            foreach(Event userEvent in userEvents)
            {
                if(userEvent.StartTime != null)
                {
                    if(userEvent.StartTime.Value.Month == userDetails.GetUserBirthday().Month)
                    {
                        userEvents.Add(userEvent);
                    }
                }
            }

            return userEvents;
        }

        public List<string> FetchSortType()
        {
            List<string> sortTypes = new List<string>();

            foreach(string sortEnumName in typeof(eSortType).GetEnumNames())
            {
                sortTypes.Add(adjustSortName(sortEnumName));    
            }

            return sortTypes;
        }

        private string adjustSortName(string i_SortEnumName)
        {
            StringBuilder sortName = new StringBuilder();

            foreach(char letter in i_SortEnumName)
            {
                if(char.IsUpper(letter) && sortName.Length > 0)
                {
                    sortName.Append(' ');
                }
                sortName.Append(letter);
            }

            return sortName.ToString();
        }

        private Dictionary<string, int> getMonthDictionary()
        {
            Dictionary<string, int> monthDictionary = new Dictionary<string, int>();

            for(int i = 1; i <= 12; i++)
            {
                monthDictionary.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i), 0);
            }

            return monthDictionary;
        }

        private IPostMonthComparer getPostMonthComparer()
        {
            IPostMonthComparer postMonthComparer;
            Type strategyTypeClass = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(i_SortClassName => i_SortClassName.Name == string.Format($"{SortType.ToString()}Comparer"));

            if (strategyTypeClass != null)
            {
                postMonthComparer = Activator.CreateInstance(strategyTypeClass) as IPostMonthComparer;
            }
            else
            {
                throw new ArgumentException($"Unknown strategy type: {SortType}");
            }

            return postMonthComparer;
        }
    }
}
