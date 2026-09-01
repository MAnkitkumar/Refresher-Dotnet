using System;

namespace TimeConversionExample
{
    class TimeConversion
    {
        // Method to convert seconds to m:ss format
        static string ConvertSecondsToFormat(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            // Format: m:ss (seconds must be 2 digits with leading zero if needed)
            return $"{minutes}:{seconds:D2}";
        }

        static void Main(string[] args)
        {
            // Test case 1: From problem statement
            int seconds1 = 125;
            string result1 = ConvertSecondsToFormat(seconds1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"{seconds1} seconds = \"{result1}\"");
            Console.WriteLine();

            // Test case 2: Exactly 1 minute
            int seconds2 = 60;
            string result2 = ConvertSecondsToFormat(seconds2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"{seconds2} seconds = \"{result2}\"");
            Console.WriteLine();

            // Test case 3: Less than 1 minute
            int seconds3 = 45;
            string result3 = ConvertSecondsToFormat(seconds3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"{seconds3} seconds = \"{result3}\"");
            Console.WriteLine();

            // Test case 4: Single digit seconds (leading zero)
            int seconds4 = 305;
            string result4 = ConvertSecondsToFormat(seconds4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"{seconds4} seconds = \"{result4}\"");
            Console.WriteLine();

            // Test case 5: Zero seconds
            int seconds5 = 0;
            string result5 = ConvertSecondsToFormat(seconds5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"{seconds5} seconds = \"{result5}\"");
            Console.WriteLine();

            // Test case 6: Large value
            int seconds6 = 3661;
            string result6 = ConvertSecondsToFormat(seconds6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"{seconds6} seconds = \"{result6}\"");
            Console.WriteLine("(61 minutes and 1 second)");
            Console.WriteLine();

            // Test case 7: Very large value
            int seconds7 = 1000000;
            string result7 = ConvertSecondsToFormat(seconds7);
            Console.WriteLine("Test Case 7:");
            Console.WriteLine($"{seconds7} seconds = \"{result7}\"");
            Console.WriteLine("(16,666 minutes and 40 seconds)");

            Console.ReadLine();
        }
    }
}
