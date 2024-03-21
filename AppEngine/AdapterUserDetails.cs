using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace AppEngine
{
    public class AdapterUserDetails : IUserDetails
    {
        public User LoggedUser { get; } = EngineSingleton.Instance.LoginResult.LoggedInUser;
        public DateTime GetUserBirthday()
        {
            //facebook returns the birthday date in the format MM/DD/YYYY as string
            int day, month, year;
            string birthday = LoggedUser.Birthday;

            month = int.Parse(birthday.Substring(0, 2)); //returns the month
            day = int.Parse(birthday.Substring(3, 2)); //returns the day
            year = int.Parse(birthday.Substring(6, 4)); //returns the year

            return new DateTime(year, month, day);
        }

    }
}
