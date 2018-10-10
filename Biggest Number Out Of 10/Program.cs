using System;

namespace Biggest_Number_Out_Of_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int biggest = int.MinValue;

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Enter number {i}:");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" > ");

                int input;

                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" > ");
                }

                if (input >= biggest)
                {
                    biggest = input;
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Biggest Number: {biggest}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press enter to quit...");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                continue;
            }
        }
    }
}
