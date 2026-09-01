using System;
using System.Collections.Generic;

namespace CustomSortingExample
{
    // Student class
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"Name: {Name,-15} Age: {Age,3}  Marks: {Marks,3}";
        }
    }

    // Custom Comparer for sorting students
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            // First, sort by Marks (highest first - descending)
            int marksComparison = y.Marks.CompareTo(x.Marks);
            
            if (marksComparison != 0)
            {
                return marksComparison;
            }
            
            // If marks are equal, sort by Age (youngest first - ascending)
            return x.Age.CompareTo(y.Age);
        }
    }

    class CustomSortingStudents
    {
        static void Main(string[] args)
        {
            // Create list of students
            List<Student> students = new List<Student>
            {
                new Student { Name = "Alice", Age = 22, Marks = 85 },
                new Student { Name = "Bob", Age = 20, Marks = 90 },
                new Student { Name = "Charlie", Age = 21, Marks = 90 },
                new Student { Name = "David", Age = 23, Marks = 85 },
                new Student { Name = "Eve", Age = 19, Marks = 95 },
                new Student { Name = "Frank", Age = 20, Marks = 85 },
                new Student { Name = "Grace", Age = 22, Marks = 90 },
                new Student { Name = "Henry", Age = 21, Marks = 80 },
                new Student { Name = "Ivy", Age = 20, Marks = 95 }
            };

            Console.WriteLine("========== BEFORE SORTING ==========");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            // Sort using custom comparer
            students.Sort(new StudentComparer());

            Console.WriteLine("\n========== AFTER SORTING ==========");
            Console.WriteLine("Sorted by: 1) Highest Marks  2) Youngest Age");
            Console.WriteLine("=========================================");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n========== SORTING RULES ==========");
            Console.WriteLine("1. Students with higher marks appear first");
            Console.WriteLine("2. If marks are equal, younger students appear first");

            Console.ReadLine();
        }
    }
}
