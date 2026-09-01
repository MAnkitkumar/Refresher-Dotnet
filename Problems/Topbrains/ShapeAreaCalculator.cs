using System;
using System.Linq;

namespace ShapeAreaCalculatorExample
{
    // Interface for Area calculation
    interface IAreaCalculator
    {
        double CalculateArea();
    }

    // Abstract base class for Shape
    abstract class Shape : IAreaCalculator
    {
        public abstract double CalculateArea();
    }

    // Circle class
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // Rectangle class
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Triangle class
    class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }

    class ShapeAreaCalculator
    {
        // Method to parse shape string and create appropriate shape object
        static Shape ParseShape(string shapeString)
        {
            string[] parts = shapeString.Split(' ');
            string shapeType = parts[0];

            switch (shapeType)
            {
                case "C":
                    double radius = double.Parse(parts[1]);
                    return new Circle(radius);

                case "R":
                    double width = double.Parse(parts[1]);
                    double height = double.Parse(parts[2]);
                    return new Rectangle(width, height);

                case "T":
                    double baseLength = double.Parse(parts[1]);
                    double triangleHeight = double.Parse(parts[2]);
                    return new Triangle(baseLength, triangleHeight);

                default:
                    throw new ArgumentException($"Unknown shape type: {shapeType}");
            }
        }

        // Method to compute total area of all shapes
        static double ComputeTotalArea(string[] shapes)
        {
            double totalArea = 0;

            foreach (string shapeString in shapes)
            {
                Shape shape = ParseShape(shapeString);
                totalArea += shape.CalculateArea();
            }

            // Round to 2 decimals using AwayFromZero
            return Math.Round(totalArea, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            // Test case 1: Mixed shapes
            string[] shapes1 = { "C 5", "R 10 20", "T 8 6" };
            double result1 = ComputeTotalArea(shapes1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Shapes: [{string.Join(", ", shapes1.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"Total Area: {result1}");
            Console.WriteLine("Breakdown:");
            Console.WriteLine($"  Circle (r=5): {Math.Round(Math.PI * 5 * 5, 2)}");
            Console.WriteLine($"  Rectangle (10x20): 200.00");
            Console.WriteLine($"  Triangle (b=8, h=6): 24.00");
            Console.WriteLine();

            // Test case 2: Only circles
            string[] shapes2 = { "C 3", "C 4", "C 5" };
            double result2 = ComputeTotalArea(shapes2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Shapes: [{string.Join(", ", shapes2.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"Total Area: {result2}");
            Console.WriteLine();

            // Test case 3: Only rectangles
            string[] shapes3 = { "R 5 10", "R 3 7", "R 2 8" };
            double result3 = ComputeTotalArea(shapes3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Shapes: [{string.Join(", ", shapes3.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"Total Area: {result3}");
            Console.WriteLine("Breakdown: (5*10) + (3*7) + (2*8) = 50 + 21 + 16 = 87");
            Console.WriteLine();

            // Test case 4: Only triangles
            string[] shapes4 = { "T 10 5", "T 6 8" };
            double result4 = ComputeTotalArea(shapes4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Shapes: [{string.Join(", ", shapes4.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"Total Area: {result4}");
            Console.WriteLine("Breakdown: (0.5*10*5) + (0.5*6*8) = 25 + 24 = 49");
            Console.WriteLine();

            // Test case 5: Empty array
            string[] shapes5 = { };
            double result5 = ComputeTotalArea(shapes5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Shapes: []");
            Console.WriteLine($"Total Area: {result5}");
            Console.WriteLine();

            // Test case 6: Large values
            string[] shapes6 = { "C 100", "R 1000 500", "T 200 300" };
            double result6 = ComputeTotalArea(shapes6);
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"Shapes: [{string.Join(", ", shapes6.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"Total Area: {result6}");

            Console.ReadLine();
        }
    }
}
