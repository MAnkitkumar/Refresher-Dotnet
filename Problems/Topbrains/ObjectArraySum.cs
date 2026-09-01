using System;

namespace ObjectArraySumExample
{
    class ObjectArraySum
    {
        // Method to sum only integer values from object array using pattern matching
        static int SumIntegerValues(object[] values)
        {
            int sum = 0;

            foreach (object value in values)
            {
                if (value is int x)
                {
                    sum += x;
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            // Test case 1: Mixed types
            object[] values1 = { 10, "hello", 20, true, 30, null, 15 };
            int result1 = SumIntegerValues(values1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Values: [10, \"hello\", 20, true, 30, null, 15]");
            Console.WriteLine($"Sum of integers: {result1}");
            Console.WriteLine("Explanation: 10 + 20 + 30 + 15 = 75");
            Console.WriteLine();

            // Test case 2: All integers
            object[] values2 = { 5, 10, 15, 20, 25 };
            int result2 = SumIntegerValues(values2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Values: [5, 10, 15, 20, 25]");
            Console.WriteLine($"Sum of integers: {result2}");
            Console.WriteLine();

            // Test case 3: No integers
            object[] values3 = { "test", true, 3.14, null, false };
            int result3 = SumIntegerValues(values3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Values: [\"test\", true, 3.14, null, false]");
            Console.WriteLine($"Sum of integers: {result3}");
            Console.WriteLine("Explanation: No integers found");
            Console.WriteLine();

            // Test case 4: Negative integers
            object[] values4 = { -10, "world", 20, -5, 15, null };
            int result4 = SumIntegerValues(values4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Values: [-10, \"world\", 20, -5, 15, null]");
            Console.WriteLine($"Sum of integers: {result4}");
            Console.WriteLine("Explanation: -10 + 20 + (-5) + 15 = 20");
            Console.WriteLine();

            // Test case 5: Empty array
            object[] values5 = { };
            int result5 = SumIntegerValues(values5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Values: []");
            Console.WriteLine($"Sum of integers: {result5}");
            Console.WriteLine();

            // Test case 6: Mixed with doubles (should be ignored)
            object[] values6 = { 10, 20.5, 30, 15.75, 40 };
            int result6 = SumIntegerValues(values6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"Values: [10, 20.5, 30, 15.75, 40]");
            Console.WriteLine($"Sum of integers: {result6}");
            Console.WriteLine("Explanation: 10 + 30 + 40 = 80 (doubles ignored)");
            Console.WriteLine();

            // Test case 7: Zero and negative
            object[] values7 = { 0, -100, 50, 0, "text", 50 };
            int result7 = SumIntegerValues(values7);
            Console.WriteLine("Test Case 7:");
            Console.WriteLine($"Values: [0, -100, 50, 0, \"text\", 50]");
            Console.WriteLine($"Sum of integers: {result7}");
            Console.WriteLine("Explanation: 0 + (-100) + 50 + 0 + 50 = 0");

            Console.ReadLine();
        }
    }
}
