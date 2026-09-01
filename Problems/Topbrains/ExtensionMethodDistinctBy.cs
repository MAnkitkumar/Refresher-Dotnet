using System;
using System.Collections.Generic;

namespace ExtensionMethodExample
{
    // Extension method class
    static class StringArrayExtensions
    {
        // Custom DistinctBy extension method
        public static string[] DistinctBy(this string[] items)
        {
            HashSet<string> seenIds = new HashSet<string>();
            List<string> distinctNames = new List<string>();

            foreach (string item in items)
            {
                // Parse the id:name format
                string[] parts = item.Split(':');
                string id = parts[0];
                string name = parts[1];

                // If this id hasn't been seen, add the name
                if (!seenIds.Contains(id))
                {
                    seenIds.Add(id);
                    distinctNames.Add(name);
                }
            }

            return distinctNames.ToArray();
        }
    }

    class ExtensionMethodDistinctBy
    {
        static void Main(string[] args)
        {
            // Test case 1: Basic distinct by id
            string[] items1 = { "1:Alice", "2:Bob", "1:Alicia", "3:Charlie", "2:Robert" };
            string[] result1 = items1.DistinctBy();
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Input: [{string.Join(", ", Array.ConvertAll(items1, s => $"\"{s}\""))}]");
            Console.WriteLine($"Output: [{string.Join(", ", Array.ConvertAll(result1, s => $"\"{s}\""))}]");
            Console.WriteLine("Explanation: First occurrence of each ID - 1:Alice, 2:Bob, 3:Charlie");
            Console.WriteLine();

            // Test case 2: All unique IDs
            string[] items2 = { "1:John", "2:Jane", "3:Jack", "4:Jill" };
            string[] result2 = items2.DistinctBy();
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Input: [{string.Join(", ", Array.ConvertAll(items2, s => $"\"{s}\""))}]");
            Console.WriteLine($"Output: [{string.Join(", ", Array.ConvertAll(result2, s => $"\"{s}\""))}]");
            Console.WriteLine("Explanation: All IDs are unique");
            Console.WriteLine();

            // Test case 3: All same ID
            string[] items3 = { "1:Tom", "1:Tim", "1:Ted", "1:Tony" };
            string[] result3 = items3.DistinctBy();
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Input: [{string.Join(", ", Array.ConvertAll(items3, s => $"\"{s}\""))}]");
            Console.WriteLine($"Output: [{string.Join(", ", Array.ConvertAll(result3, s => $"\"{s}\""))}]");
            Console.WriteLine("Explanation: Only first occurrence kept - 1:Tom");
            Console.WriteLine();

            // Test case 4: Empty array
            string[] items4 = { };
            string[] result4 = items4.DistinctBy();
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Input: []");
            Console.WriteLine($"Output: [{string.Join(", ", Array.ConvertAll(result4, s => $"\"{s}\""))}]");
            Console.WriteLine();

            // Test case 5: Order preservation
            string[] items5 = { "3:David", "1:Alice", "2:Bob", "3:Dave", "1:Alex" };
            string[] result5 = items5.DistinctBy();
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Input: [{string.Join(", ", Array.ConvertAll(items5, s => $"\"{s}\""))}]");
            Console.WriteLine($"Output: [{string.Join(", ", Array.ConvertAll(result5, s => $"\"{s}\""))}]");
            Console.WriteLine("Explanation: Order preserved - 3:David, 1:Alice, 2:Bob");
            Console.WriteLine();

            // Test case 6: Numeric IDs with different names
            string[] items6 = { "100:Product1", "200:Product2", "100:Product1v2", "300:Product3", "200:Product2v2" };
            string[] result6 = items6.DistinctBy();
            Console.WriteLine("Test Case 6:");
            Console.WriteLine($"Input: [{string.Join(", ", Array.ConvertAll(items6, s => $"\"{s}\""))}]");
            Console.WriteLine($"Output: [{string.Join(", ", Array.ConvertAll(result6, s => $"\"{s}\""))}]");
            Console.WriteLine("Explanation: First occurrence of each ID");

            Console.ReadLine();
        }
    }
}
