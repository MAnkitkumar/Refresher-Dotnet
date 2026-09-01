using System;

namespace MultiplicationTableExample
{
    class MultiplicationTable
    {
        // Method to return multiplication table row for a number n from 1 to upto
        static int[] GetMultiplicationTableRow(int n, int upto)
        {
            int[] row = new int[upto];
            
            for (int i = 0; i < upto; i++)
            {
                row[i] = n * (i + 1);
            }
            
            return row;
        }

        static void Main(string[] args)
        {
            // Example 1: n=3, upto=5
            int n1 = 3;
            int upto1 = 5;
            int[] result1 = GetMultiplicationTableRow(n1, upto1);
            
            Console.WriteLine($"Multiplication table for n={n1}, upto={upto1}:");
            Console.WriteLine($"[{string.Join(", ", result1)}]");
            Console.WriteLine();

            // Example 2: n=7, upto=10
            int n2 = 7;
            int upto2 = 10;
            int[] result2 = GetMultiplicationTableRow(n2, upto2);
            
            Console.WriteLine($"Multiplication table for n={n2}, upto={upto2}:");
            Console.WriteLine($"[{string.Join(", ", result2)}]");
            Console.WriteLine();

            // Example 3: n=-5, upto=4
            int n3 = -5;
            int upto3 = 4;
            int[] result3 = GetMultiplicationTableRow(n3, upto3);
            
            Console.WriteLine($"Multiplication table for n={n3}, upto={upto3}:");
            Console.WriteLine($"[{string.Join(", ", result3)}]");
            Console.WriteLine();

            // Example 4: Edge case - upto=0
            int n4 = 5;
            int upto4 = 0;
            int[] result4 = GetMultiplicationTableRow(n4, upto4);
            
            Console.WriteLine($"Multiplication table for n={n4}, upto={upto4}:");
            Console.WriteLine($"[{string.Join(", ", result4)}]");
            
            Console.ReadLine();
        }
    }
}
