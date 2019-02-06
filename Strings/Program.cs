using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type a sentence:");
            Console.Write(" > ");
            var sentence = Console.ReadLine();

            Console.WriteLine($"There are {GetNumberOfWords(sentence)} words in the sentence.");
            Console.WriteLine($"There are {GetNumberOfVowels(sentence)} vowels in the sentence.");

            var palindromes = GetPalindromes(sentence);

            Console.WriteLine($"There are {palindromes.Count} palindromes in the sentence:");
            
            foreach (string palindrome in palindromes)
            {
                Console.WriteLine($" - {palindrome}");
            }

            Console.WriteLine($"There are {GetNumberOfNumbers(sentence)} numbers in the sentence.");

            Console.WriteLine($"There {(ContainsEmail(sentence) ? "is" : "is not")} an email address in the sentence.");

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        static bool ContainsEmail(string sentence)
        {
            Regex regex = new Regex(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|" + '"' + @"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*" + '"' + @")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", RegexOptions.IgnoreCase);

            sentence = SanitizeSentence(sentence);

            foreach (string part in sentence.Split(' '))
            {
                if (regex.IsMatch(part))
                {
                    return true;
                }
            }

            return false;
        }

        static string SanitizeSentence(string sentence)
        {
            // Replace multiple spaces with a single space.
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            sentence = regex.Replace(sentence, " ");

            return sentence;
        }

        static int GetNumberOfWords(string sentence)
        {
            sentence = SanitizeSentence(sentence);

            return sentence.Split(' ').Length;
        }

        static int GetNumberOfVowels(string sentence)
        {            
            return sentence.ToLower().Count("aeiou".Contains);
        }

        static string ReverseString(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            return new string(a);
        }

        static List<string> GetPalindromes(string sentence)
        {
            var output = new List<string>();

            sentence = SanitizeSentence(sentence);

            foreach (string word in sentence.Split(' '))
            {
                if (word == ReverseString(word) && word.Length > 1)
                {
                    output.Add(word);
                }
            }

            return output;
        }

        static int GetNumberOfNumbers(string sentence)
        {
            return sentence.Count("0123456789".Contains);
        }
    }
}
