using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEngine
{
    public interface IPostMonthComparer
    {
        bool ShouldSwap(KeyValuePair<string, int> i_FirstMonthData,
                        KeyValuePair<string, int> i_SecondMonthData);
    }
}
