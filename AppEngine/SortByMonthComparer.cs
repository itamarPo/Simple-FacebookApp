using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEngine
{
    internal class SortByMonthComparer: IPostMonthComparer
    {
        public bool ShouldSwap(KeyValuePair<string, int> i_FirstMonthData, KeyValuePair<string, int> i_SecondMonthData)
        {
            string firstComparedMonth, secondComparedMonth;
            int firstComparedMonthNumber, secondComparedMonthNumber;

            firstComparedMonth = i_FirstMonthData.Key;
            secondComparedMonth = i_SecondMonthData.Key;
            firstComparedMonthNumber = getMonthNumber(firstComparedMonth);
            secondComparedMonthNumber = getMonthNumber(secondComparedMonth);

            return firstComparedMonthNumber < secondComparedMonthNumber;
        }

        private int getMonthNumber(string i_MonthName)
        {
            DateTime date = DateTime.ParseExact(i_MonthName, "MMM", System.Globalization.CultureInfo.InvariantCulture);
            return date.Month;
        }
    }
}
