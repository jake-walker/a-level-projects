using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Search
    {
        /// <summary>
        /// Search for an object (using a linear search) in a list of objects and return the index where the item is found.
        /// </summary>
        /// <param name="list">List of items to search</param>
        /// <param name="target">Item to search for</param>
        /// <returns>Index where item is found, or -1 if not found</returns>
        public static int Linear<T>(List<T> list, T target)
        {
            // Loop through every item in the input list.
            for (var i = 0; i < list.Count; i++)
            {
                // If the item in the list is equal to the item that we are looking for
                if (list[i].Equals(target))
                {
                    // Return the index of the item
                    return i;
                }
            }

            // If we couldn't find anything, return -1
            return -1;
        }

        /// <summary>
        /// Search for an integer (using a binary search) in a list of integers and return the index where the item is found.
        /// </summary>
        /// <param name="list">List of integers to search</param>
        /// <param name="target">Integer to search for</param>
        /// <returns>Index where integer is found, or -1 if not found</returns>
        public static int Binary(List<int> list, int target)
        {
            // Sort the list into order
            list.Sort();

            // Set the min and max variables of the list
            var min = 0;
            var max = list.Count - 1;
            
            // While the part of the list we are looking at is not 1 or less in length
            while (min <= max)
            {
                // Find the midpoint of the list that we are looking at
                var mid = (min + max) / 2;

                // If the item we are looking for is in the middle of the list
                if (target == list[mid])
                {
                    // Return the index of the middle of the list
                    return mid;
                }

                // If the item we are looking for is lower than the midpoint of the list
                if (target < list[mid])
                {
                    // Reduce the upper part of the list to half way down the list
                    max = mid - 1;
                }
                else
                {
                    // Reduce the lower part of the list to half way up the list
                    min = mid + 1;
                }
            }

            // Return -1 as the item hasn't been found
            return -1;
        }
    }
}
