using System;

namespace FeetToCentimetersExample
{
    class FeetToCentimeters
    {
        // Method to convert feet to centimeters
        static double ConvertFeetToCentimeters(int feet)
        {
            const double conversionFactor = 30.48;
            double centimeters = feet * conversionFactor;
            
            // Round to 2 decimal places using AwayFromZero
            return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            // Test case 1: Basic conversion
            int feet1 = 5;
            double result1 = ConvertFeetToCentimeters(feet1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"{feet1} feet = {result1} cm");
            Console.WriteLine();

            // Test case 2: Zero feet
            int feet2 = 0;
            double result2 = ConvertFeetToCentimeters(feet2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"{feet2} feet = {result2} cm");
            Console.WriteLine();

            // Test case 3: Single foot
            int feet3 = 1;
            double result3 = ConvertFeetToCentimeters(feet3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"{feet3} foot = {result3} cm");
            Console.WriteLine();

            // Test case 4: Larger value
            int feet4 = 100;
            double result4 = ConvertFeetToCentimeters(feet4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"{feet4} feet = {result4} cm");
            Console.WriteLine();

            // Test case 5: Very large value
            int feet5 = 1000;
            double result5 = ConvertFeetToCentimeters(feet5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"{feet5} feet = {result5} cm");
            Console.WriteLine();

            // Test case 6: Common height (6 feet)
            int feet6 = 6;
            double result6 = ConvertFeetToCentimeters(feet6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"{feet6} feet = {result6} cm");
            Console.WriteLine("(Average human height)");
            Console.WriteLine();

            // Test case 7: Maximum constraint test
            int feet7 = 1000000;
            double result7 = ConvertFeetToCentimeters(feet7);
            Console.WriteLine("Test Case 7:");
            Console.WriteLine($"{feet7} feet = {result7} cm");

            Console.ReadLine();
        }
    }
}
