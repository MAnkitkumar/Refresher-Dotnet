using System;
using System.Collections.Generic;

namespace DictionaryLookupExample
{
    class DictionaryLookup
    {
        // Method to calculate total salary from dictionary lookup
        static int CalculateTotalSalary(List<int> employeeIds, Dictionary<int, int> salaryDict)
        {
            int totalSalary = 0;

            foreach (int id in employeeIds)
            {
                if (salaryDict.ContainsKey(id))
                {
                    totalSalary += salaryDict[id];
                }
            }

            return totalSalary;
        }

        static void Main(string[] args)
        {
            // Test case 1: From problem statement
            List<int> ids1 = new List<int> { 1, 4, 5 };
            Dictionary<int, int> salaries1 = new Dictionary<int, int>
            {
                { 1, 20000 },
                { 4, 40000 },
                { 5, 15000 }
            };
            int result1 = CalculateTotalSalary(ids1, salaries1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Employee IDs: [{string.Join(", ", ids1)}]");
            Console.WriteLine($"Salary Dictionary: {{1:20000, 4:40000, 5:15000}}");
            Console.WriteLine($"Total Salary: {result1}");
            Console.WriteLine();

            // Test case 2: Some IDs not in dictionary
            List<int> ids2 = new List<int> { 1, 2, 3, 4 };
            Dictionary<int, int> salaries2 = new Dictionary<int, int>
            {
                { 1, 25000 },
                { 3, 30000 },
                { 4, 35000 }
            };
            int result2 = CalculateTotalSalary(ids2, salaries2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Employee IDs: [{string.Join(", ", ids2)}]");
            Console.WriteLine($"Salary Dictionary: {{1:25000, 3:30000, 4:35000}}");
            Console.WriteLine($"Total Salary: {result2}");
            Console.WriteLine("Note: ID 2 not found in dictionary, skipped");
            Console.WriteLine();

            // Test case 3: Empty ID list
            List<int> ids3 = new List<int> { };
            Dictionary<int, int> salaries3 = new Dictionary<int, int>
            {
                { 1, 50000 },
                { 2, 60000 }
            };
            int result3 = CalculateTotalSalary(ids3, salaries3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Employee IDs: []");
            Console.WriteLine($"Total Salary: {result3}");
            Console.WriteLine();

            // Test case 4: Large salaries
            List<int> ids4 = new List<int> { 101, 102, 103, 104, 105 };
            Dictionary<int, int> salaries4 = new Dictionary<int, int>
            {
                { 101, 75000 },
                { 102, 82000 },
                { 103, 91000 },
                { 104, 68000 },
                { 105, 79000 }
            };
            int result4 = CalculateTotalSalary(ids4, salaries4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Employee IDs: [{string.Join(", ", ids4)}]");
            Console.WriteLine($"Total Salary: {result4}");
            Console.WriteLine();

            // Test case 5: None of the IDs exist
            List<int> ids5 = new List<int> { 10, 20, 30 };
            Dictionary<int, int> salaries5 = new Dictionary<int, int>
            {
                { 1, 40000 },
                { 2, 50000 }
            };
            int result5 = CalculateTotalSalary(ids5, salaries5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Employee IDs: [{string.Join(", ", ids5)}]");
            Console.WriteLine($"Salary Dictionary: {{1:40000, 2:50000}}");
            Console.WriteLine($"Total Salary: {result5}");
            Console.WriteLine("Note: No matching IDs found");

            Console.ReadLine();
        }
    }
}
