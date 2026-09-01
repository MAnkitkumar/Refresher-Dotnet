using System;
using System.Linq;
using System.Text.Json;

namespace StringFormatExample
{
    // C# record for Student
    record Student(string Name, int Score);

    class StringFormat
    {
        // Method to process students and return JSON
        static string ProcessStudents(string[] items, int minScore)
        {
            var students = items
                .Select(item => item.Split(':'))
                .Select(parts => new Student(parts[0], int.Parse(parts[1])))
                .Where(student => student.Score >= minScore)
                .OrderByDescending(student => student.Score)
                .ThenBy(student => student.Name)
                .ToList();

            string json = JsonSerializer.Serialize(students);
            return json;
        }

        static void Main(string[] args)
        {
            // Example 1
            string[] items1 = { "Alice:85", "Bob:90", "Charlie:78", "David:90", "Eve:92" };
            int minScore1 = 80;
            
            Console.WriteLine("Example 1:");
            Console.WriteLine($"Input: [{string.Join(", ", items1.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"MinScore: {minScore1}");
            string result1 = ProcessStudents(items1, minScore1);
            Console.WriteLine($"Output: {result1}");
            Console.WriteLine();

            // Example 2
            string[] items2 = { "John:75", "Jane:88", "Jack:88", "Jill:95" };
            int minScore2 = 85;
            
            Console.WriteLine("Example 2:");
            Console.WriteLine($"Input: [{string.Join(", ", items2.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"MinScore: {minScore2}");
            string result2 = ProcessStudents(items2, minScore2);
            Console.WriteLine($"Output: {result2}");
            Console.WriteLine();

            // Example 3: Edge case - no students meet criteria
            string[] items3 = { "Tom:60", "Tim:65", "Tina:70" };
            int minScore3 = 80;
            
            Console.WriteLine("Example 3 (No matches):");
            Console.WriteLine($"Input: [{string.Join(", ", items3.Select(s => $"\"{s}\""))}]");
            Console.WriteLine($"MinScore: {minScore3}");
            string result3 = ProcessStudents(items3, minScore3);
            Console.WriteLine($"Output: {result3}");
            
            Console.ReadLine();
        }
    }
}
