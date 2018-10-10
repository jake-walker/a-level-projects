using System;

namespace Biggest_Number_Out_Of_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set a variable for storing the biggest number.
            int biggest = int.MinValue;

            // This is a loop which runs 10 times (1 to 10).
            for (int i = 1; i <= 10; i++)
            {
                // Set the text colour to white.
                Console.ForegroundColor = ConsoleColor.White;
                // Ask the user to enter a number.
                Console.WriteLine($"Enter #{i}:");

                // Set the text colour to gray.
                Console.ForegroundColor = ConsoleColor.Gray;
                // Add a cursor so the user knows to type something.
                Console.Write(" > ");

                // Set a variable to store the parsed input.
                int input;

                // Keep asking the user for an input until it's a valid
                // integer.
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    // Set the text colour to red for error.
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Print a new line and tell the user that they didn't
                    // enter a valid integer.
                    Console.WriteLine("\nPlease enter a valid integer.");

                    // Set the text colour to grey
                    Console.ForegroundColor = ConsoleColor.Gray;
                    // Print another cursor.
                    Console.Write(" > ");
                }

                // If the inputted number is bigger than the biggest number.
                if (input >= biggest)
                {
                    // Set the biggest number to the inputted number.
                    biggest = input;
                }
            }

            // After the loop has finished.

            // Set the text colour to cyan.
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Print out the biggest number.
            Console.WriteLine($"Biggest Number: {biggest}");

            // Set the text colour to gray.
            Console.ForegroundColor = ConsoleColor.Gray;
            // Tell the user to press enter to quit.
            Console.WriteLine("Press enter to quit...");

            // Wait until the enter key has been pressed, if not keep
            // going through the loop.
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                continue;
            }
        }
    }
}
