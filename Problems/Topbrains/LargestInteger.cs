using System;

namespace LargestIntegerExample
{
    class LargestInteger
    {
        // Method to find the largest of three integers
        static int FindLargest(int a, int b, int c)
        {
            int largest = a;

            if (b > largest)
            {
                largest = b;
            }

            if (c > largest)
            {
                largest = c;
            }

            return largest;
        }

        static void Main(string[] args)
        {
            // Test case 1
            int result1 = FindLargest(10, 25, 15);
            Console.WriteLine($"Largest of 10, 25, 15: {result1}");

            // Test case 2
            int result2 = FindLargest(100, 50, 75);
            Console.WriteLine($"Largest of 100, 50, 75: {result2}");

            // Test case 3
            int result3 = FindLargest(-5, -10, -3);
            Console.WriteLine($"Largest of -5, -10, -3: {result3}");

            // Test case 4: All equal
            int result4 = FindLargest(7, 7, 7);
            Console.WriteLine($"Largest of 7, 7, 7: {result4}");

            // Test case 5: Edge case with large numbers
            int result5 = FindLargest(1000000000, 999999999, 1000000000);
            Console.WriteLine($"Largest of 1000000000, 999999999, 1000000000: {result5}");

            // Test case 6: Edge case with negative large numbers
            int result6 = FindLargest(-1000000000, -500000000, -750000000);
            Console.WriteLine($"Largest of -1000000000, -500000000, -750000000: {result6}");

            Console.ReadLine();
        }
    }
}
