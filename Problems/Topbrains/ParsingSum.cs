using System;

namespace ParsingSumExample
{
    class ParsingSum
    {
        // Method to sum only valid 32-bit integers from string array
        static int SumParsableIntegers(string[] tokens)
        {
            int sum = 0;

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int value))
                {
                    sum += value;
                }
                // If TryParse fails, ignore the value
            }

            return sum;
        }

        static void Main(string[] args)
        {
            // Test case 1: Mixed valid and invalid values
            string[] tokens1 = { "10", "20", "abc", "30", "xyz" };
            int result1 = SumParsableIntegers(tokens1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Tokens: [{string.Join(", ", Array.ConvertAll(tokens1, t => $"\"{t}\""))}]");
            Console.WriteLine($"Sum: {result1}");
            Console.WriteLine("Explanation: 10 + 20 + 30 = 60 (ignored 'abc' and 'xyz')");
            Console.WriteLine();

            // Test case 2: All valid integers
            string[] tokens2 = { "5", "15", "25", "35" };
            int result2 = SumParsableIntegers(tokens2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Tokens: [{string.Join(", ", Array.ConvertAll(tokens2, t => $"\"{t}\""))}]");
            Console.WriteLine($"Sum: {result2}");
            Console.WriteLine();

            // Test case 3: All invalid values
            string[] tokens3 = { "hello", "world", "test" };
            int result3 = SumParsableIntegers(tokens3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Tokens: [{string.Join(", ", Array.ConvertAll(tokens3, t => $"\"{t}\""))}]");
            Console.WriteLine($"Sum: {result3}");
            Console.WriteLine("Explanation: No valid integers");
            Console.WriteLine();

            // Test case 4: Overflow values (exceeds int.MaxValue)
            string[] tokens4 = { "100", "2147483648", "200", "-2147483649", "300" };
            int result4 = SumParsableIntegers(tokens4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Tokens: [{string.Join(", ", Array.ConvertAll(tokens4, t => $"\"{t}\""))}]");
            Console.WriteLine($"Sum: {result4}");
            Console.WriteLine("Explanation: 100 + 200 + 300 = 600 (ignored overflow values)");
            Console.WriteLine();

            // Test case 5: Negative numbers
            string[] tokens5 = { "-10", "20", "-30", "40" };
            int result5 = SumParsableIntegers(tokens5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Tokens: [{string.Join(", ", Array.ConvertAll(tokens5, t => $"\"{t}\""))}]");
            Console.WriteLine($"Sum: {result5}");
            Console.WriteLine("Explanation: -10 + 20 + (-30) + 40 = 20");
            Console.WriteLine();

            // Test case 6: Decimals and floats (invalid for int)
            string[] tokens6 = { "10", "20.5", "30", "40.7", "50" };
            int result6 = SumParsableIntegers(tokens6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"Tokens: [{string.Join(", ", Array.ConvertAll(tokens6, t => $"\"{t}\""))}]");
            Console.WriteLine($"Sum: {result6}");
            Console.WriteLine("Explanation: 10 + 30 + 50 = 90 (ignored decimal values)");
            Console.WriteLine();

            // Test case 7: Empty strings and whitespace
            string[] tokens7 = { "10", "", "20", "   ", "30" };
            int result7 = SumParsableIntegers(tokens7);
            Console.WriteLine("Test Case 7:");
            Console.WriteLine($"Tokens: [\"10\", \"\", \"20\", \"   \", \"30\"]");
            Console.WriteLine($"Sum: {result7}");
            Console.WriteLine("Explanation: 10 + 20 + 30 = 60 (ignored empty/whitespace)");

            Console.ReadLine();
        }
    }
}
