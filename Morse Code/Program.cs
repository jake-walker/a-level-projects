using System;

namespace Morse_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please enter a sentence to translate it to Morse Code.");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > ");

            Console.ForegroundColor = ConsoleColor.White;
            string morse = Translator.ToMorse(Console.ReadLine().Trim());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(morse);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press enter to exit...");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                continue;
            }
        }
    }
}
