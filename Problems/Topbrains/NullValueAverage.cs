using System;
using System.Linq;

namespace NullValueAverageExample
{
    class NullValueAverage
    {
        // Method to compute average of non-null values
        static double? ComputeAverage(double?[] values)
        {
            // Filter non-null values
            var nonNullValues = values.Where(v => v.HasValue).Select(v => v.Value).ToList();

            // If no non-null values, return null
            if (nonNullValues.Count == 0)
            {
                return null;
            }

            // Calculate average
            double average = nonNullValues.Average();

            // Round to 2 decimals (AwayFromZero)
            return Math.Round(average, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            // Test case 1: Mixed values with nulls
            double?[] values1 = { 10.5, null, 20.3, 15.7, null, 8.9 };
            double? result1 = ComputeAverage(values1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Values: [{string.Join(", ", values1.Select(v => v.HasValue ? v.Value.ToString() : "null"))}]");
            Console.WriteLine($"Average: {(result1.HasValue ? result1.Value.ToString() : "null")}");
            Console.WriteLine();

            // Test case 2: All null values
            double?[] values2 = { null, null, null };
            double? result2 = ComputeAverage(values2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Values: [null, null, null]");
            Console.WriteLine($"Average: {(result2.HasValue ? result2.Value.ToString() : "null")}");
            Console.WriteLine();

            // Test case 3: No null values
            double?[] values3 = { 5.5, 10.0, 15.25, 20.75 };
            double? result3 = ComputeAverage(values3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Values: [{string.Join(", ", values3.Select(v => v.Value))}]");
            Console.WriteLine($"Average: {result3}");
            Console.WriteLine();

            // Test case 4: Empty array
            double?[] values4 = { };
            double? result4 = ComputeAverage(values4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Values: []");
            Console.WriteLine($"Average: {(result4.HasValue ? result4.Value.ToString() : "null")}");
            Console.WriteLine();

            // Test case 5: Single non-null value
            double?[] values5 = { null, null, 42.567, null };
            double? result5 = ComputeAverage(values5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Values: [null, null, 42.567, null]");
            Console.WriteLine($"Average: {result5}");
            Console.WriteLine();

            // Test case 6: Rounding test (AwayFromZero)
            double?[] values6 = { 10.125, 20.125, 30.125 };
            double? result6 = ComputeAverage(values6);
            Console.WriteLine("Test Case 6 (Rounding):");
            Console.WriteLine($"Values: [{string.Join(", ", values6.Select(v => v.Value))}]");
            Console.WriteLine($"Average: {result6}");
            Console.WriteLine("Explanation: (10.125 + 20.125 + 30.125) / 3 = 20.125 → rounds to 20.13");

            Console.ReadLine();
        }
    }
}
