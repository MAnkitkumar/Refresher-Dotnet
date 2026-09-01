using System;

namespace SumOfPositiveIntegersExample
{
    class SumOfPositiveIntegers
    {
        // Method to sum positive integers until reaching 0
        static int SumPositiveUntilZero(int[] nums)
        {
            int sum = 0;

            foreach (int num in nums)
            {
                // If 0, stop processing
                if (num == 0)
                {
                    break;
                }

                // If negative, ignore it
                if (num < 0)
                {
                    continue;
                }

                // If positive, add to sum
                sum += num;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            // Test case 1: Mixed with 0
            int[] nums1 = { 5, 10, -3, 7, 0, 2, 8 };
            int result1 = SumPositiveUntilZero(nums1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Array: [{string.Join(", ", nums1)}]");
            Console.WriteLine($"Sum: {result1}");
            Console.WriteLine("Explanation: 5 + 10 + 7 = 22 (stopped at 0, ignored -3)");
            Console.WriteLine();

            // Test case 2: No 0, all positive
            int[] nums2 = { 1, 2, 3, 4, 5 };
            int result2 = SumPositiveUntilZero(nums2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Array: [{string.Join(", ", nums2)}]");
            Console.WriteLine($"Sum: {result2}");
            Console.WriteLine("Explanation: All positive, no 0 encountered");
            Console.WriteLine();

            // Test case 3: 0 at the beginning
            int[] nums3 = { 0, 1, 2, 3 };
            int result3 = SumPositiveUntilZero(nums3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Array: [{string.Join(", ", nums3)}]");
            Console.WriteLine($"Sum: {result3}");
            Console.WriteLine("Explanation: Stopped immediately at 0");
            Console.WriteLine();

            // Test case 4: All negative until 0
            int[] nums4 = { -5, -10, -3, 0, 100 };
            int result4 = SumPositiveUntilZero(nums4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Array: [{string.Join(", ", nums4)}]");
            Console.WriteLine($"Sum: {result4}");
            Console.WriteLine("Explanation: Ignored all negatives, stopped at 0");
            Console.WriteLine();

            // Test case 5: No 0, with negatives
            int[] nums5 = { 10, -5, 20, -10, 30 };
            int result5 = SumPositiveUntilZero(nums5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Array: [{string.Join(", ", nums5)}]");
            Console.WriteLine($"Sum: {result5}");
            Console.WriteLine("Explanation: 10 + 20 + 30 = 60 (ignored negatives)");
            Console.WriteLine();

            // Test case 6: Empty array
            int[] nums6 = { };
            int result6 = SumPositiveUntilZero(nums6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"Array: []");
            Console.WriteLine($"Sum: {result6}");
            Console.WriteLine("Explanation: Empty array");

            Console.ReadLine();
        }
    }
}
