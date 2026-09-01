using System;

namespace SwappingExamples
{
    class SwapWithRef
    {
        // Method to swap two numbers using ref keyword
        static void SwapNumbers(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;

            Console.WriteLine("=== Swapping using ref keyword ===");
            Console.WriteLine($"Before swap: num1 = {num1}, num2 = {num2}");

            // Call swap method with ref keyword
            SwapNumbers(ref num1, ref num2);

            Console.WriteLine($"After swap: num1 = {num1}, num2 = {num2}");
            Console.ReadLine();
        }
    }
}
