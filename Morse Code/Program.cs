using System;

namespace Morse_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentence to translate it to Morse Code.");

            Console.Write(" > ");

            string[] sentence = Console.ReadLine().Split("");

            foreach (string c in sentence)
            {

            }
        }
    }
}
