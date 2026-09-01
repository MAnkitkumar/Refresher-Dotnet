using System;
using System.IO;
using System.Linq;

namespace FileIOLogFilterExample
{
    class FileIOLogFilter
    {
        // Method to filter ERROR logs from input file and save to output file
        static void FilterErrorLogs(string inputFile, string outputFile)
        {
            try
            {
                // Read all lines from the input file
                string[] allLines = File.ReadAllLines(inputFile);

                // Filter only ERROR logs
                var errorLogs = allLines.Where(line => line.Contains("ERROR")).ToArray();

                // Write ERROR logs to output file
                File.WriteAllLines(outputFile, errorLogs);

                Console.WriteLine($"✓ Successfully filtered {errorLogs.Length} ERROR log(s) from {inputFile}");
                Console.WriteLine($"✓ ERROR logs saved to {outputFile}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"✗ Error: File '{inputFile}' not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            string inputFile = "log.txt";
            string outputFile = "error.txt";

            // Create sample log file for demonstration
            CreateSampleLogFile(inputFile);

            Console.WriteLine("=== Log File Filter - Extract ERROR Logs ===\n");

            // Filter ERROR logs
            FilterErrorLogs(inputFile, outputFile);

            // Display input file content
            Console.WriteLine($"\n--- Content of {inputFile} ---");
            DisplayFileContent(inputFile);

            // Display output file content
            Console.WriteLine($"\n--- Content of {outputFile} (Filtered ERROR logs) ---");
            DisplayFileContent(outputFile);

            Console.ReadLine();
        }

        // Helper method to create a sample log file
        static void CreateSampleLogFile(string fileName)
        {
            string[] sampleLogs = {
                "[2026-09-01 10:00:00] INFO: Application started successfully",
                "[2026-09-01 10:05:23] ERROR: Database connection failed - Timeout",
                "[2026-09-01 10:10:45] WARN: Low memory detected",
                "[2026-09-01 10:15:12] INFO: User logged in - UserID: 1001",
                "[2026-09-01 10:20:34] ERROR: NullReferenceException at line 245",
                "[2026-09-01 10:25:56] INFO: Data sync completed",
                "[2026-09-01 10:30:18] ERROR: File not found - config.xml",
                "[2026-09-01 10:35:42] WARN: Cache size exceeds 80%",
                "[2026-09-01 10:40:09] INFO: Backup process initiated",
                "[2026-09-01 10:45:27] ERROR: API request failed - Status code 500"
            };

            File.WriteAllLines(fileName, sampleLogs);
            Console.WriteLine($"✓ Sample log file '{fileName}' created with {sampleLogs.Length} entries\n");
        }

        // Helper method to display file content
        static void DisplayFileContent(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
    }
}
