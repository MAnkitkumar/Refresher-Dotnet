using System;

namespace SwappingExamples
{
    class SwapWithOut
    {
        // Method to swap two numbers using out keyword
        static void SwapNumbers(int a, int b, out int swappedA, out int swappedB)
        {
            swappedA = b;
            swappedB = a;
        }

        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;

            Console.WriteLine("=== Swapping using out keyword ===");
            Console.WriteLine($"Before swap: num1 = {num1}, num2 = {num2}");

            // Call swap method with out keyword
            SwapNumbers(num1, num2, out int result1, out int result2);

            Console.WriteLine($"After swap: result1 = {result1}, result2 = {result2}");
            Console.ReadLine();
        }
    }
}
