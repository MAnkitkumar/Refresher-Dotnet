using System;

namespace BankTransactionExample
{
    class BankTransaction
    {
        // Method to process bank transactions and return final balance
        static int ProcessTransactions(int initialBalance, int[] transactions)
        {
            int balance = initialBalance;

            foreach (int transaction in transactions)
            {
                if (transaction >= 0)
                {
                    // Deposit
                    balance += transaction;
                }
                else
                {
                    // Withdraw (only if enough balance)
                    if (balance + transaction >= 0)
                    {
                        balance += transaction;
                    }
                    // Otherwise ignore the transaction
                }
            }

            return balance;
        }

        static void Main(string[] args)
        {
            // Test case 1: Mixed transactions
            int initialBalance1 = 1000;
            int[] transactions1 = { 500, -200, -300, 100, -1500, 250 };
            int result1 = ProcessTransactions(initialBalance1, transactions1);
            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Initial Balance: ${initialBalance1}");
            Console.WriteLine($"Transactions: [{string.Join(", ", transactions1)}]");
            Console.WriteLine($"Final Balance: ${result1}");
            Console.WriteLine();

            // Test case 2: All deposits
            int initialBalance2 = 500;
            int[] transactions2 = { 100, 200, 300 };
            int result2 = ProcessTransactions(initialBalance2, transactions2);
            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Initial Balance: ${initialBalance2}");
            Console.WriteLine($"Transactions: [{string.Join(", ", transactions2)}]");
            Console.WriteLine($"Final Balance: ${result2}");
            Console.WriteLine();

            // Test case 3: Insufficient funds
            int initialBalance3 = 100;
            int[] transactions3 = { -50, -30, -40 };
            int result3 = ProcessTransactions(initialBalance3, transactions3);
            Console.WriteLine("Test Case 3:");
            Console.WriteLine($"Initial Balance: ${initialBalance3}");
            Console.WriteLine($"Transactions: [{string.Join(", ", transactions3)}]");
            Console.WriteLine($"Final Balance: ${result3}");
            Console.WriteLine();

            // Test case 4: Empty transactions
            int initialBalance4 = 750;
            int[] transactions4 = { };
            int result4 = ProcessTransactions(initialBalance4, transactions4);
            Console.WriteLine("Test Case 4:");
            Console.WriteLine($"Initial Balance: ${initialBalance4}");
            Console.WriteLine($"Transactions: []");
            Console.WriteLine($"Final Balance: ${result4}");
            Console.WriteLine();

            // Test case 5: Large values
            int initialBalance5 = 1000000000;
            int[] transactions5 = { -500000000, 200000000, -800000000 };
            int result5 = ProcessTransactions(initialBalance5, transactions5);
            Console.WriteLine("Test Case 5:");
            Console.WriteLine($"Initial Balance: ${initialBalance5}");
            Console.WriteLine($"Transactions: [{string.Join(", ", transactions5)}]");
            Console.WriteLine($"Final Balance: ${result5}");

            Console.ReadLine();
        }
    }
}
