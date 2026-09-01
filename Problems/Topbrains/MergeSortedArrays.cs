using System;

namespace MergeSortedArraysExample
{
    class MergeSortedArrays
    {
        // Generic method to merge two sorted arrays using IComparable<T> constraint
        static T[] MergeSorted<T>(T[] a, T[] b) where T : IComparable<T>
        {
            int lengthA = a.Length;
            int lengthB = b.Length;
            T[] merged = new T[lengthA + lengthB];

            int i = 0, j = 0, k = 0;

            // Merge elements from both arrays
            while (i < lengthA && j < lengthB)
            {
                if (a[i].CompareTo(b[j]) <= 0)
                {
                    merged[k++] = a[i++];
                }
                else
                {
                    merged[k++] = b[j++];
                }
            }

            // Copy remaining elements from array a
            while (i < lengthA)
            {
                merged[k++] = a[i++];
            }

            // Copy remaining elements from array b
            while (j < lengthB)
            {
                merged[k++] = b[j++];
            }

            return merged;
        }

        static void Main(string[] args)
        {
            // Test case 1: Integer arrays
            int[] intArray1 = { 1, 3, 5, 7, 9 };
            int[] intArray2 = { 2, 4, 6, 8, 10 };
            int[] mergedInt = MergeSorted(intArray1, intArray2);
            Console.WriteLine("Test Case 1 (Integers):");
            Console.WriteLine($"Array A: [{string.Join(", ", intArray1)}]");
            Console.WriteLine($"Array B: [{string.Join(", ", intArray2)}]");
            Console.WriteLine($"Merged: [{string.Join(", ", mergedInt)}]");
            Console.WriteLine();

            // Test case 2: String arrays
            string[] stringArray1 = { "apple", "cherry", "mango" };
            string[] stringArray2 = { "banana", "grape", "orange" };
            string[] mergedString = MergeSorted(stringArray1, stringArray2);
            Console.WriteLine("Test Case 2 (Strings):");
            Console.WriteLine($"Array A: [{string.Join(", ", stringArray1)}]");
            Console.WriteLine($"Array B: [{string.Join(", ", stringArray2)}]");
            Console.WriteLine($"Merged: [{string.Join(", ", mergedString)}]");
            Console.WriteLine();

            // Test case 3: Double arrays
            double[] doubleArray1 = { 1.5, 3.2, 5.7 };
            double[] doubleArray2 = { 2.1, 4.8, 6.3 };
            double[] mergedDouble = MergeSorted(doubleArray1, doubleArray2);
            Console.WriteLine("Test Case 3 (Doubles):");
            Console.WriteLine($"Array A: [{string.Join(", ", doubleArray1)}]");
            Console.WriteLine($"Array B: [{string.Join(", ", doubleArray2)}]");
            Console.WriteLine($"Merged: [{string.Join(", ", mergedDouble)}]");
            Console.WriteLine();

            // Test case 4: One empty array
            int[] intArray3 = { 1, 2, 3 };
            int[] intArray4 = { };
            int[] mergedEmpty = MergeSorted(intArray3, intArray4);
            Console.WriteLine("Test Case 4 (One empty):");
            Console.WriteLine($"Array A: [{string.Join(", ", intArray3)}]");
            Console.WriteLine($"Array B: []");
            Console.WriteLine($"Merged: [{string.Join(", ", mergedEmpty)}]");
            Console.WriteLine();

            // Test case 5: Different sizes with duplicates
            int[] intArray5 = { 1, 3, 3, 5 };
            int[] intArray6 = { 2, 3, 4, 5, 6, 7 };
            int[] mergedDuplicates = MergeSorted(intArray5, intArray6);
            Console.WriteLine("Test Case 5 (Duplicates):");
            Console.WriteLine($"Array A: [{string.Join(", ", intArray5)}]");
            Console.WriteLine($"Array B: [{string.Join(", ", intArray6)}]");
            Console.WriteLine($"Merged: [{string.Join(", ", mergedDuplicates)}]");

            Console.ReadLine();
        }
    }
}
