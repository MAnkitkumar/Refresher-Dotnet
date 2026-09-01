using System;
using System.Collections.Generic;
using System.Text;

namespace MahirlAlphabetsExample
{
    class MahirlAlphabets
    {
        // Method to check if a character is a vowel
        static bool IsVowel(char c)
        {
            char lower = char.ToLower(c);
            return lower == 'a' || lower == 'e' || lower == 'i' || lower == 'o' || lower == 'u';
        }

        // Method to process the words according to Mahirl's assignment
        static string ProcessWords(string word1, string word2)
        {
            // Step 1: Find all consonants in word2 (case-insensitive)
            HashSet<char> consonantsInWord2 = new HashSet<char>();
            foreach (char c in word2)
            {
                if (!IsVowel(c))
                {
                    consonantsInWord2.Add(char.ToLower(c));
                }
            }

            // Step 2: Remove common consonants from word1
            StringBuilder result = new StringBuilder();
            foreach (char c in word1)
            {
                // If it's a vowel, keep it
                if (IsVowel(c))
                {
                    result.Append(c);
                }
                // If it's a consonant not in word2, keep it
                else if (!consonantsInWord2.Contains(char.ToLower(c)))
                {
                    result.Append(c);
                }
                // Otherwise, it's a common consonant - skip it
            }

            // Step 3: Remove consecutive duplicate characters
            if (result.Length == 0)
            {
                return "";
            }

            StringBuilder final = new StringBuilder();
            final.Append(result[0]);

            for (int i = 1; i < result.Length; i++)
            {
                if (result[i] != result[i - 1])
                {
                    final.Append(result[i]);
                }
            }

            return final.ToString();
        }

        static void Main(string[] args)
        {
            // Test case 1
            string word1_1 = "hello";
            string word2_1 = "world";
            string result1 = ProcessWords(word1_1, word2_1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Word 1: {word1_1}");
            Console.WriteLine($"Word 2: {word2_1}");
            Console.WriteLine($"Output: {result1}");
            Console.WriteLine();

            // Test case 2
            string word1_2 = "programming";
            string word2_2 = "gaming";
            string result2 = ProcessWords(word1_2, word2_2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Word 1: {word1_2}");
            Console.WriteLine($"Word 2: {word2_2}");
            Console.WriteLine($"Output: {result2}");
            Console.WriteLine();

            // Test case 3
            string word1_3 = "Success";
            string word2_3 = "Celebrate";
            string result3 = ProcessWords(word1_3, word2_3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Word 1: {word1_3}");
            Console.WriteLine($"Word 2: {word2_3}");
            Console.WriteLine($"Output: {result3}");
            Console.WriteLine();

            // Test case 4 - with consecutive duplicates
            string word1_4 = "aabbcc";
            string word2_4 = "xyz";
            string result4 = ProcessWords(word1_4, word2_4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Word 1: {word1_4}");
            Console.WriteLine($"Word 2: {word2_4}");
            Console.WriteLine($"Output: {result4}");
            Console.WriteLine();

            // Test case 5 - case insensitive
            string word1_5 = "AaBbCc";
            string word2_5 = "bBdD";
            string result5 = ProcessWords(word1_5, word2_5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Word 1: {word1_5}");
            Console.WriteLine($"Word 2: {word2_5}");
            Console.WriteLine($"Output: {result5}");

            Console.ReadLine();
        }
    }
}
