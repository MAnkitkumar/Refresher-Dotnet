using System;

namespace DisplayHeightExample
{
    class DisplayHeight
    {
        // Method to determine height category
        static string GetHeightCategory(int heightCm)
        {
            if (heightCm < 150)
            {
                return "Short";
            }
            else if (heightCm < 180)
            {
                return "Average";
            }
            else
            {
                return "Tall";
            }
        }

        static void Main(string[] args)
        {
            // Test cases
            int[] heights = { 140, 150, 165, 179, 180, 200, 0, 300 };

            Console.WriteLine("=== Height Category Classifier ===\n");

            foreach (int height in heights)
            {
                string category = GetHeightCategory(height);
                Console.WriteLine($"Height: {height} cm -> Category: {category}");
            }

            Console.ReadLine();
        }
    }
}
