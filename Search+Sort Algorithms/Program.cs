using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Print out a menu with different options
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine(" 1. Manual Search");
                Console.WriteLine(" 2. Benchmark");
                Console.WriteLine(" 0. Quit");
                Console.Write(" -> ");
                
                // Get the user's response
                var opt = Console.ReadLine()?.Trim();

                // If the user picked to do a manual search...
                if (opt == "1")
                {
                    // Start the manual search function
                    ManualSearch();
                // If the user picked to do a benchmark...
                } else if (opt == "2")
                {
                    // Run the benchmark function
                    RunBenchMark();
                }
                // If the user picked to quit...
                else if (opt == "0")
                {
                    // Break out of the while loop, which ends the program from running.
                    break;
                }
                // If the user picks something that wasn't on the menu...
                else
                {
                    // Tell the user that they have picked an invalid option
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }

        /// <summary>
        /// Function to test the speed of searching functions
        /// </summary>
        static void RunBenchMark()
        {
            // Variable for storing the list of randomly generated items to search through
            var benchList = new List<int>();
            // Instantiate a new random object 
            var rand = new Random();

            Console.WriteLine("Generating 100,000 random numbers...");

            // Loop through 100,000 times...
            for (var i = 0; i < 100000; i++)
            {
                // Generate a random number between 0 and 100,000, then add it to the list
                benchList.Add(rand.Next(0, 100000));
            }

            // Pick a random item from the list, which is the index that we expect to get returned.
            var expected = rand.Next(benchList.Count);
            // Get the actual item of the random index that we just generated.
            var benchTarget = benchList[expected];

            Console.WriteLine("Calculating average time of Linear Search...");

            // Start a new stopwatch to time how long the function takes.
            var linearWatch = Stopwatch.StartNew();

            // Run the function 1,000 times, so that we can find an average time.
            for (var i = 0; i < 1000; i++)
            {
                // Print a status message out to the user.
                Console.Write($" - Running Linear Search {i+1} of 1000...");
                // Get the result of the search
                var result = Search.Linear(benchList, benchTarget);
                // Print out the result that we got
                Console.WriteLine($" [DONE: R={result}]");
            }

            // After running 1,000 times, stop the stopwatch
            linearWatch.Stop();

            Console.WriteLine("Calculating average time of Binary Search...");

            // Start a new stopwatch to time how long the function takes.
            var binaryWatch = Stopwatch.StartNew();

            // Run the function 1,000 times, so that we can get an average time.
            for (var i = 0; i < 1000; i++)
            {
                // Print a status message out to the user.
                Console.Write($" - Running Binary Search {i+1} of 1000...");
                // Get the result of the search
                var result = Search.Binary(benchList, benchTarget);
                // Print out the result that we got
                Console.WriteLine($" [DONE: R={result}]");
            }

            // After running 1,000 times, stop the stopwatch
            binaryWatch.Stop();

            Console.WriteLine("Finished Benchmark!");
            // Calculate the average time that the linear search ran for by dividing the total time by the number of times we ran the function.
            var linearAvg = linearWatch.ElapsedMilliseconds / 1000;
            // ...same for the other searches
            var binaryAvg = binaryWatch.ElapsedMilliseconds / 1000;

            // Print out the results of the benchmark (to 4 decimal places)
            Console.WriteLine($"LINEAR Average: {linearAvg:F4} ms");
            Console.WriteLine($"BINARY Average: {binaryAvg:F4} ms");

            // 'Pause' the program.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Function for asking a user which items to search for
        /// </summary>
        static void ManualSearch()
        {
            // Make a new list to store the items to search through
            List<int> searchList = new List<int>();

            // Make a new item for the item that we are searching through
            int searchItem;

            // Loop to ask the user for items to search through
            while (true)
            {
                // Ask the user to type a number
                Console.WriteLine("Type a number to add to the search list (or press enter to finish):");
                Console.Write(" -> ");

                // Read the number that the user types
                var num = Console.ReadLine();

                // Check that the user actually typed something, if they didn't...
                if (string.IsNullOrWhiteSpace(num))
                {
                    // If the search list is empty...
                    if (searchList.Count <= 0)
                    {
                        // Add a few example items to the list
                        searchList.AddRange(new List<int>()
                        {
                            1, 8, 19, 53, 90, 13, 43, 86
                        });
                        Console.WriteLine("Added default items!");
                    }

                    // Break out the loop so that we don't keep asking for numbers from the user
                    break;

                }
                
                // If the user's input can be parsed as an integer...
                if (int.TryParse(num, out var i))
                {
                    // Add the PARSED item to the list
                    searchList.Add(i);
                    // Tell the user what was added
                    Console.WriteLine($"Added {i} to the list!");
                }
                else
                {
                    // If we couldn't parse the number, give the user an error message.
                    Console.WriteLine("That was an invalid number!");
                }
            }

            // Loop to ask user item to search for
            while (true)
            {
                // Ask the user to type in a number to search for
                Console.WriteLine("Type a number to search for:");
                Console.Write(" -> ");

                // Get the whatever the user typed in
                var num = Console.ReadLine();

                // If the number can be parsed to an integer
                if (int.TryParse(num, out searchItem))
                {
                    // Break out of the loop to stop asking the user numbers
                    break;
                }

                // If not, tell the user that they typed an invalid number
                Console.WriteLine("That was an invalid number!");
            }

            // Initialize some variables for the search
            var done = false;
            var result = -1;
            Stopwatch watch = null;

            // While we haven't completed the search
            while (done == false)
            {
                // Ask the user to pick a searching algorithm
                Console.WriteLine("Pick a searching algorithm to use:");
                Console.WriteLine(" (L) Linear Search");
                Console.WriteLine(" (B) Binary Search");
                Console.Write(" -> ");
                
                // Get the user's response.
                var selection = Console.ReadLine();

                switch (selection)
                {
                    // If the user chose linear search
                    case "L":
                        // Start the stopwatch
                        watch = Stopwatch.StartNew();
                        // Do the linear search
                        result = Search.Linear(searchList, searchItem);
                        // Stop the stopwatch
                        watch.Stop();
                        // Set done to true so that we know that the search completed
                        done = true;
                        // Break from the switch case
                        break;
                    // If the user chose a binary search
                    case "B":
                        // Start the stopwatch
                        watch = Stopwatch.StartNew();
                        // Do the binary search
                        result = Search.Binary(searchList, searchItem);
                        // Stop the stopwatch
                        watch.Stop();
                        // Set done to true so that we know that the search completed
                        done = true;
                        // Break from the switch case
                        break;
                    // If the user chooses anything else
                    default:
                        // Tell the user that they picked an invalid option
                        Console.WriteLine("That wasn't a valid selection!");
                        // Break from the switch case
                        break;
                }
            }

            Console.Write("Search List:");
            
            // For each item in the list we are searching through
            foreach (var item in searchList)
            {
                // Print the item to the console
                Console.Write($" {item} ");
            }

            // Tell the user where the item was found by the search algorithm
            Console.WriteLine($"\nFound {searchItem} at {result + 1}!");
            // Tell the user how long the search took
            Console.WriteLine($"This search took {watch.ElapsedMilliseconds} milliseconds!");

            // 'Pause' the program until the user presses a key
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(false);
        }
    }
}