using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Sort
    {
        public static List<int> Bubble(List<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                var swapped = false;
                for (var j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] <= list[j + 1]) continue;

                    // swap
                    var temp = list[j];
                    list[j] = list[j+1];
                    list[j+1] = temp;

                    swapped = true;
                }

                if (!swapped)
                {
                    break;
                }
            }

            return list;
        }
    }
}
