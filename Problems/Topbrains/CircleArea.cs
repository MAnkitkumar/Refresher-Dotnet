using System;

namespace CircleAreaExample
{
    class CircleArea
    {
        // Method to calculate area of a circle
        static double CalculateCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            
            // Round to 2 decimal places using AwayFromZero
            return Math.Round(area, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            // Test case 1: Basic radius
            double radius1 = 5.0;
            double result1 = CalculateCircleArea(radius1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Radius: {radius1}");
            Console.WriteLine($"Area: {result1}");
            Console.WriteLine();

            // Test case 2: Zero radius
            double radius2 = 0.0;
            double result2 = CalculateCircleArea(radius2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Radius: {radius2}");
            Console.WriteLine($"Area: {result2}");
            Console.WriteLine();

            // Test case 3: Radius of 1
            double radius3 = 1.0;
            double result3 = CalculateCircleArea(radius3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Radius: {radius3}");
            Console.WriteLine($"Area: {result3}");
            Console.WriteLine();

            // Test case 4: Decimal radius
            double radius4 = 7.5;
            double result4 = CalculateCircleArea(radius4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Radius: {radius4}");
            Console.WriteLine($"Area: {result4}");
            Console.WriteLine();

            // Test case 5: Large radius
            double radius5 = 100.0;
            double result5 = CalculateCircleArea(radius5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Radius: {radius5}");
            Console.WriteLine($"Area: {result5}");
            Console.WriteLine();

            // Test case 6: Very small radius
            double radius6 = 0.5;
            double result6 = CalculateCircleArea(radius6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"Radius: {radius6}");
            Console.WriteLine($"Area: {result6}");
            Console.WriteLine();

            // Test case 7: Rounding test
            double radius7 = 3.0;
            double result7 = CalculateCircleArea(radius7);
            Console.WriteLine("Test Case 7 (Rounding):");
            Console.WriteLine($"Radius: {radius7}");
            Console.WriteLine($"Area: {result7}");
            Console.WriteLine($"Calculation: π × {radius7}² = {Math.PI * radius7 * radius7}");
            Console.WriteLine($"Rounded to 2 decimals: {result7}");

            Console.ReadLine();
        }
    }
}
