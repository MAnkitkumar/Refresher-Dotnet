using System;

namespace LuckyNumbersExample
{
    class LuckyNumbers
    {
        // Method to calculate sum of digits
        static int SumOfDigits(long n)
        {
            int sum = 0;
            n = Math.Abs(n);
            while (n > 0)
            {
                sum += (int)(n % 10);
                n /= 10;
            }
            return sum;
        }

        // Method to check if a number is prime
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Method to check if a number is a Lucky Number
        static bool IsLuckyNumber(int x)
        {
            // Must be non-prime and positive
            if (x <= 0 || IsPrime(x)) return false;

            long square = (long)x * x;
            int sumX = SumOfDigits(x);
            int sumSquare = SumOfDigits(square);

            return sumSquare == sumX * sumX;
        }

        // Method to count Lucky Numbers in range [m, n]
        static int CountLuckyNumbers(int m, int n)
        {
            int count = 0;
            for (int i = m; i <= n; i++)
            {
                if (IsLuckyNumber(i))
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            // Sample Input
            Console.WriteLine("Enter the range (m n):");
            Console.WriteLine("Example: 20 30");
            
            int m = 20;
            int n = 30;

            Console.WriteLine($"\nFinding Lucky Numbers between {m} and {n}:");
            Console.WriteLine("\nLucky Numbers found:");
            
            for (int i = m; i <= n; i++)
            {
                if (IsLuckyNumber(i))
                {
                    long square = (long)i * i;
                    int sumI = SumOfDigits(i);
                    int sumSquare = SumOfDigits(square);
                    Console.WriteLine($"{i}: S({i}) = {sumI}, S({square}) = {sumSquare}, {sumI} × {sumI} = {sumI * sumI}");
                }
            }

            int result = CountLuckyNumbers(m, n);
            Console.WriteLine($"\nTotal Lucky Numbers: {result}");

            Console.ReadLine();
        }
    }
}
