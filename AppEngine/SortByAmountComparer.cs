using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEngine
{
    internal class SortByAmountComparer : IPostMonthComparer
    {
        public bool ShouldSwap(KeyValuePair<string, int> i_FirstMonthData, KeyValuePair<string, int> i_SecondMonthData)
        {
            return i_FirstMonthData.Value < i_SecondMonthData.Value;
        }
    }
}
