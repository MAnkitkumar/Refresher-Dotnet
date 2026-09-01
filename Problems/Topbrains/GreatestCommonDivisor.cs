using System;

namespace GreatestCommonDivisorExample
{
    class GreatestCommonDivisor
    {
        // Recursive method to compute GCD using Euclid's algorithm
        static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }

        static void Main(string[] args)
        {
            // Test case 1: Basic example
            int a1 = 48, b1 = 18;
            int result1 = GCD(a1, b1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"GCD({a1}, {b1}) = {result1}");
            Console.WriteLine();

            // Test case 2: One number is 0
            int a2 = 25, b2 = 0;
            int result2 = GCD(a2, b2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"GCD({a2}, {b2}) = {result2}");
            Console.WriteLine();

            // Test case 3: Both numbers are the same
            int a3 = 15, b3 = 15;
            int result3 = GCD(a3, b3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"GCD({a3}, {b3}) = {result3}");
            Console.WriteLine();

            // Test case 4: Co-prime numbers (GCD = 1)
            int a4 = 17, b4 = 19;
            int result4 = GCD(a4, b4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"GCD({a4}, {b4}) = {result4}");
            Console.WriteLine();

            // Test case 5: Large numbers
            int a5 = 1071, b5 = 462;
            int result5 = GCD(a5, b5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"GCD({a5}, {b5}) = {result5}");
            Console.WriteLine();

            // Test case 6: Very large numbers
            int a6 = 2000000000, b6 = 1000000000;
            int result6 = GCD(a6, b6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"GCD({a6}, {b6}) = {result6}");
            Console.WriteLine();

            // Test case 7: Powers of 2
            int a7 = 256, b7 = 64;
            int result7 = GCD(a7, b7);
            Console.WriteLine("Test Case 7:");
            Console.WriteLine($"GCD({a7}, {b7}) = {result7}");

            Console.ReadLine();
        }
    }
}
