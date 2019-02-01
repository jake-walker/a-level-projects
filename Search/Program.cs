using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> searchList = new List<int>();
            int searchItem;
            while (true)
            {
                Console.WriteLine("Type a number to add to the search list (or press enter to finish):");
                Console.Write(" -> ");
                var num = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(num))
                {
                    if (searchList.Count <= 0)
                    {
                        searchList.AddRange(new List<int>()
                        {
                            1, 8, 19, 53, 90, 13, 43, 86
                        });
                        Console.WriteLine("Added default items!");
                    }
                    break;
                } else if (int.TryParse(num, out var i))
                {
                    searchList.Add(i);
                    Console.WriteLine($"Added {i} to the list!");
                }
                else
                {
                    Console.WriteLine("That was an invalid number!");
                }
            }

            while (true)
            {
                Console.WriteLine("Type a number to search for:");
                Console.Write(" -> ");
                var num = Console.ReadLine();

                if (int.TryParse(num, out searchItem))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That was an invalid number!");
                }
            }

            var done = false;
            var result = -1;
            Stopwatch watch = null;

            while (done == false)
            {
                Console.WriteLine("Pick a searching algorithm to use:");
                Console.WriteLine(" (L) Linear Search");
                Console.WriteLine(" (B) Binary Search");
                Console.Write(" -> ");
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "L":
                        watch = Stopwatch.StartNew();
                        result = Search.Linear(searchList, searchItem);
                        watch.Stop();
                        done = true;
                        break;
                    case "B":
                        watch = Stopwatch.StartNew();
                        result = Search.Binary(searchList, searchItem);
                        watch.Stop();
                        done = true;
                        break;
                    default:
                        Console.WriteLine("That wasn't a valid selection!");
                        break;
                }
            }

            Console.Write("Search List:");
            foreach (var item in searchList)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine($"\nFound {searchItem} at {result + 1}!");
            Console.WriteLine($"This search took {watch.ElapsedMilliseconds} milliseconds!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(false);
        }
    }
}