using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEngine
{
    public class PostByMonthSorter
    {
        public IPostMonthComparer PostMonthComparer { get; set; }

        public PostByMonthSorter(IPostMonthComparer i_PostMonthComparer)
        {
            PostMonthComparer = i_PostMonthComparer;
        }

        public void SortPostsByMonth(List<KeyValuePair<string, int>> i_PostsPerMonth)
        {
            int n = i_PostsPerMonth.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (PostMonthComparer.ShouldSwap(i_PostsPerMonth[j], i_PostsPerMonth[j + 1]))
                    {
                        // Swap elements
                        (i_PostsPerMonth[j], i_PostsPerMonth[j + 1]) = (i_PostsPerMonth[j + 1], i_PostsPerMonth[j]);
                    }
                }
            }
        }
    }
}
