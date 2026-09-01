using System;

namespace ArithmeticExpressionsExample
{
    class ArithmeticExpressions
    {
        static string EvaluateExpression(string expression)
        {
            // Split by space
            string[] parts = expression.Split(' ');

            // Check if format is valid (must have exactly 3 parts)
            if (parts.Length != 3)
            {
                return "Error:InvalidExpression";
            }

            // Parse operands
            if (!int.TryParse(parts[0], out int a))
            {
                return "Error:InvalidNumber";
            }

            if (!int.TryParse(parts[2], out int b))
            {
                return "Error:InvalidNumber";
            }

            string op = parts[1];

            // Evaluate based on operator
            switch (op)
            {
                case "+":
                    return (a + b).ToString();
                
                case "-":
                    return (a - b).ToString();
                
                case "*":
                    return (a * b).ToString();
                
                case "/":
                    if (b == 0)
                    {
                        return "Error:DivideByZero";
                    }
                    return (a / b).ToString();
                
                default:
                    return "Error:UnknownOperator";
            }
        }

        static void Main(string[] args)
        {
            // Test cases
            string[] testExpressions = {
                "10 + 5",
                "20 - 8",
                "6 * 7",
                "15 / 3",
                "10 / 0",
                "5 % 2",
                "10 + abc",
                "5+3",
                "10 + 5 + 2",
                "100 * 2"
            };

            Console.WriteLine("=== Arithmetic Expression Evaluator ===\n");

            foreach (string expr in testExpressions)
            {
                string result = EvaluateExpression(expr);
                Console.WriteLine($"Expression: \"{expr}\"");
                Console.WriteLine($"Result: {result}\n");
            }

            Console.ReadLine();
        }
    }
}
