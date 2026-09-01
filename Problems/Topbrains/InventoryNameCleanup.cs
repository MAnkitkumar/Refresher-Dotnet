using System;
using System.Text;
using System.Globalization;

namespace InventoryNameCleanupExample
{
    class InventoryNameCleanup
    {
        // Method to clean up product name
        static string CleanProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                return "";
            }

            // Step 1: Remove duplicate consecutive characters
            StringBuilder sb = new StringBuilder();
            sb.Append(productName[0]);

            for (int i = 1; i < productName.Length; i++)
            {
                if (productName[i] != productName[i - 1])
                {
                    sb.Append(productName[i]);
                }
            }

            // Step 2: Trim extra spaces and convert to proper format
            string result = sb.ToString().Trim();

            // Step 3: Convert to TitleCase
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            result = textInfo.ToTitleCase(result.ToLower());

            return result;
        }

        static void Main(string[] args)
        {
            // Test case 1: From problem statement
            string input1 = " llapppptop bag ";
            string output1 = CleanProductName(input1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Input: \"{input1}\"");
            Console.WriteLine($"Output: \"{output1}\"");
            Console.WriteLine();

            // Test case 2: Multiple duplicates
            string input2 = "  sssmmaarrrttt    phhhoonnne  ";
            string output2 = CleanProductName(input2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Input: \"{input2}\"");
            Console.WriteLine($"Output: \"{output2}\"");
            Console.WriteLine();

            // Test case 3: No duplicates
            string input3 = "  wireless mouse  ";
            string output3 = CleanProductName(input3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Input: \"{input3}\"");
            Console.WriteLine($"Output: \"{output3}\"");
            Console.WriteLine();

            // Test case 4: Mixed case with duplicates
            string input4 = "BLUEEEtoooothhh  SPPPeaker";
            string output4 = CleanProductName(input4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Input: \"{input4}\"");
            Console.WriteLine($"Output: \"{output4}\"");
            Console.WriteLine();

            // Test case 5: All duplicates
            string input5 = "aaabbbcccddd";
            string output5 = CleanProductName(input5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Input: \"{input5}\"");
            Console.WriteLine($"Output: \"{output5}\"");

            Console.ReadLine();
        }
    }
}
