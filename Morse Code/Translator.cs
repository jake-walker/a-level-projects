using System;
using System.Collections.Generic;
using System.Text;

namespace Morse_Code
{
    class Translator
    {
        private static readonly Dictionary<char, string> Morse = new Dictionary<char, string>()
        {
            { 'A', ".-" },
            { 'B', "-..." },
            { 'C', "-.-." },
            { 'D', "-.." },
            { 'E', "." },
            { 'F', "..-." },
            { 'G', "--." },
            { 'H', "...." },
            { 'I', ".." },
            { 'J', ".---" },
            { 'K', "-.-" },
            { 'L', ".-.." },
            { 'M', "--" },
            { 'N', "-." },
            { 'O', "---" },
            { 'P', ".--." },
            { 'Q', "--.-" },
            { 'R', "..." },
            { 'T', "-" },
            { 'U', "..-" },
            { 'V', "...-" },
            { 'W', ".--" },
            { 'X', "-..-" },
            { 'Y', "-.--" },
            { 'Z', "--.." },
            { '1', ".----" },
            { '2', "..---" },
            { '3', "...--" },
            { '4', "....-" },
            { '5', "....." },
            { '6', "-...." },
            { '7', "--..." },
            { '8', "---.." },
            { '9', "----." },
            { '0', "-----" },
        };

        public static string ToMorse(string sentence)
        {
            char[] letters = sentence.Trim().ToUpper().ToCharArray();
            string output = string.Empty;

            foreach (char letter in letters)
            {
                if (Morse.ContainsKey(letter))
                {
                    output += Morse[letter];
                } else if (letter == ' ')
                {
                    output += "/";
                }

                output += " ";
            }

            return output;
        }
    }
}
