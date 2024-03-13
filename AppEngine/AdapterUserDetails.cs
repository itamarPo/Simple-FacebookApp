using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEngine
{
    public class AdapterUserDetails : IUserDetails
    {
        private readonly Engine r_AppEngine = Singleton<Engine>.Instance;
        public DateTime GetUserBirthday()
        {
            //facebook returns the birthday date in the format MM/DD/YYYY as string
            int day, month, year;
            string birthday = r_AppEngine.LoginResult.LoggedInUser.Birthday;

            month = int.Parse(birthday.Substring(0, 2)); //returns the month
            day = int.Parse(birthday.Substring(3, 2)); //returns the day
            year = int.Parse(birthday.Substring(6, 4)); //returns the year

            return new DateTime(year, month, day);
        }
    }
}
