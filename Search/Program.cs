using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine(" 1. Manual Search");
                Console.WriteLine(" 2. Benchmark");
                Console.WriteLine(" 0. Quit");
                Console.Write(" -> ");
                var opt = Console.ReadLine().Trim();

                if (opt == "1")
                {
                    ManualSearch();
                } else if (opt == "2")
                {
                    RunBenchMark();
                }
                else if (opt == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }

        static void RunBenchMark()
        {
            var benchList = new List<int>();
            var rand = new Random();

            Console.WriteLine("Generating 100,000 random numbers...");

            for (var i = 0; i < 100000; i++)
            {
                benchList.Add(rand.Next(0, 100000));
            }

            var expected = rand.Next(benchList.Count);
            var benchTarget = benchList[expected];

            Console.WriteLine("Calculating average time of Linear Search...");

            var linearWatch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++)
            {
                Console.Write($" - Running Linear Search {i+1} of 1000...");
                var result = Search.Linear(benchList, benchTarget);
                Console.WriteLine($" [DONE: R={result}]");
            }

            linearWatch.Stop();

            Console.WriteLine("Calculating average time of Binary Search...");

            var binaryWatch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++)
            {
                Console.Write($" - Running Binary Search {i+1} of 1000...");
                var result = Search.Binary(benchList, benchTarget);
                Console.WriteLine($" [DONE: R={result}]");
            }

            binaryWatch.Stop();

            Console.WriteLine("Finished Benchmark!");
            var linearAvg = linearWatch.ElapsedMilliseconds / 1000;
            var binaryAvg = binaryWatch.ElapsedMilliseconds / 1000;
            Console.WriteLine($"LINEAR Average: {linearAvg:F4} ms");
            Console.WriteLine($"BINARY Average: {binaryAvg:F4} ms");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void ManualSearch()
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