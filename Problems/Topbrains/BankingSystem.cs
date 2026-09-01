using System;
using System.Collections.Generic;

namespace BankingSystemExample
{
    // Custom Exceptions
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }

    public class DailyLimitExceededException : Exception
    {
        public DailyLimitExceededException(string message) : base(message) { }
    }

    public class AccountFrozenException : Exception
    {
        public AccountFrozenException(string message) : base(message) { }
    }

    public class NetworkException : Exception
    {
        public NetworkException(string message) : base(message) { }
    }

    // BankAccount Class
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
        public bool IsFrozen { get; set; }
        public decimal DailyWithdrawn { get; set; }
    }

    // Transaction Service
    public class TransactionService
    {
        private Dictionary<string, BankAccount> accounts;
        private List<string> transactionLogs;
        private Random random;

        public TransactionService()
        {
            accounts = new Dictionary<string, BankAccount>()
            {
                {
                    "ACC1001",
                    new BankAccount
                    {
                        AccountNumber = "ACC1001",
                        HolderName = "Pankaj",
                        Balance = 25000,
                        IsFrozen = false,
                        DailyWithdrawn = 10000
                    }
                },
                {
                    "ACC1002",
                    new BankAccount
                    {
                        AccountNumber = "ACC1002",
                        HolderName = "Rahul",
                        Balance = 100000,
                        IsFrozen = true,
                        DailyWithdrawn = 0
                    }
                }
            };

            transactionLogs = new List<string>();
            random = new Random();
        }

        public void Withdraw(string accountNo, decimal amount)
        {
            // Step 1: Validate Account
            if (!accounts.ContainsKey(accountNo))
            {
                throw new InvalidAccountException($"Account {accountNo} not found.");
            }

            BankAccount account = accounts[accountNo];

            // Step 2: Check Frozen Status
            if (account.IsFrozen)
            {
                throw new AccountFrozenException("Account is currently frozen.");
            }

            // Step 3: Check Daily Limit
            if (account.DailyWithdrawn + amount > 50000)
            {
                throw new DailyLimitExceededException("Daily withdrawal limit exceeded.");
            }

            // Step 4: Check Balance
            if (account.Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient funds.");
            }

            // Step 5: Simulate Network Failure
            if (random.Next(1, 10) == 5)
            {
                throw new NetworkException("Unable to connect to banking server.");
            }

            // Process withdrawal
            account.Balance -= amount;
            account.DailyWithdrawn += amount;

            string log = $"{DateTime.Now:dd-MMM-yyyy hh:mm tt} Withdraw ₹{amount} from {accountNo} - Success";
            transactionLogs.Add(log);
        }

        public void Deposit(string accountNo, decimal amount)
        {
            // Validate Account
            if (!accounts.ContainsKey(accountNo))
            {
                throw new InvalidAccountException($"Account {accountNo} not found.");
            }

            BankAccount account = accounts[accountNo];

            // Simulate Network Failure
            if (random.Next(1, 10) == 5)
            {
                throw new NetworkException("Unable to connect to banking server.");
            }

            // Process deposit
            account.Balance += amount;

            string log = $"{DateTime.Now:dd-MMM-yyyy hh:mm tt} Deposit ₹{amount} to {accountNo} - Success";
            transactionLogs.Add(log);
        }

        public void Transfer(string fromAccount, string toAccount, decimal amount)
        {
            // Validate both accounts
            if (!accounts.ContainsKey(fromAccount))
            {
                throw new InvalidAccountException($"Account {fromAccount} not found.");
            }

            if (!accounts.ContainsKey(toAccount))
            {
                throw new InvalidAccountException($"Account {toAccount} not found.");
            }

            BankAccount fromAcc = accounts[fromAccount];
            BankAccount toAcc = accounts[toAccount];

            // Check Frozen Status
            if (fromAcc.IsFrozen)
            {
                throw new AccountFrozenException($"Account {fromAccount} is currently frozen.");
            }

            // Check Balance
            if (fromAcc.Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient funds for transfer.");
            }

            // Simulate Network Failure
            if (random.Next(1, 10) == 5)
            {
                throw new NetworkException("Unable to connect to banking server.");
            }

            // Process transfer
            fromAcc.Balance -= amount;
            toAcc.Balance += amount;

            string log = $"{DateTime.Now:dd-MMM-yyyy hh:mm tt} Transfer ₹{amount} from {fromAccount} to {toAccount} - Success";
            transactionLogs.Add(log);
        }

        public void DisplayBalance(string accountNo)
        {
            if (accounts.ContainsKey(accountNo))
            {
                BankAccount account = accounts[accountNo];
                Console.WriteLine($"Account: {account.AccountNumber}");
                Console.WriteLine($"Holder: {account.HolderName}");
                Console.WriteLine($"Balance: ₹{account.Balance}");
                Console.WriteLine($"Frozen: {account.IsFrozen}");
                Console.WriteLine($"Daily Withdrawn: ₹{account.DailyWithdrawn}");
            }
            else
            {
                Console.WriteLine($"Account {accountNo} not found.");
            }
        }

        public void DisplayTransactionLogs()
        {
            Console.WriteLine("\n========== TRANSACTION LOGS ==========");
            if (transactionLogs.Count == 0)
            {
                Console.WriteLine("No transactions recorded.");
            }
            else
            {
                foreach (string log in transactionLogs)
                {
                    Console.WriteLine(log);
                }
            }
            Console.WriteLine("======================================\n");
        }

        private void LogFailedTransaction(string operation, string accountNo, decimal amount, string reason)
        {
            string log = $"{DateTime.Now:dd-MMM-yyyy hh:mm tt} {operation} ₹{amount} from {accountNo} - Failed. Reason: {reason}";
            transactionLogs.Add(log);
        }

        // Withdraw with retry logic
        public void WithdrawWithRetry(string accountNo, decimal amount, int maxRetries = 3)
        {
            int attempt = 0;
            while (attempt < maxRetries)
            {
                try
                {
                    attempt++;
                    Withdraw(accountNo, amount);
                    Console.WriteLine($"✓ Transaction Successful");
                    Console.WriteLine($"Remaining Balance: ₹{accounts[accountNo].Balance}");
                    return;
                }
                catch (NetworkException ex)
                {
                    if (attempt < maxRetries)
                    {
                        Console.WriteLine($"Network error. Retrying... (Attempt {attempt}/{maxRetries})");
                        LogFailedTransaction("Withdraw", accountNo, amount, $"Network failure - Retry {attempt}");
                    }
                    else
                    {
                        LogFailedTransaction("Withdraw", accountNo, amount, "Network failure - Max retries exceeded");
                        throw;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TransactionService service = new TransactionService();

            Console.WriteLine("========== BANKING SYSTEM - TRANSACTION PROCESSING ==========\n");

            // Task 1: Withdraw ₹5,000 from ACC1001
            Console.WriteLine("Task 1: Withdraw ₹5,000 from ACC1001");
            try
            {
                service.Withdraw("ACC1001", 5000);
                Console.WriteLine("✓ Transaction Successful");
                service.DisplayBalance("ACC1001");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.\n");
            }

            // Task 2: Withdraw ₹30,000 from ACC1001 (Insufficient Funds)
            Console.WriteLine("Task 2: Withdraw ₹30,000 from ACC1001");
            try
            {
                service.Withdraw("ACC1001", 30000);
                Console.WriteLine("✓ Transaction Successful");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"✗ InsufficientFundsException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.\n");
            }

            // Task 3: Withdraw ₹45,000 (Daily Limit Exceeded)
            Console.WriteLine("Task 3: Withdraw ₹45,000 from ACC1001 (Daily limit check)");
            try
            {
                service.Withdraw("ACC1001", 45000);
                Console.WriteLine("✓ Transaction Successful");
            }
            catch (DailyLimitExceededException ex)
            {
                Console.WriteLine($"✗ DailyLimitExceededException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.\n");
            }

            // Task 4: Withdraw from ACC9999 (Invalid Account)
            Console.WriteLine("Task 4: Withdraw from ACC9999 (Invalid Account)");
            try
            {
                service.Withdraw("ACC9999", 1000);
                Console.WriteLine("✓ Transaction Successful");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"✗ InvalidAccountException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.\n");
            }

            // Task 5: Withdraw from ACC1002 (Frozen Account)
            Console.WriteLine("Task 5: Withdraw from ACC1002 (Frozen Account)");
            try
            {
                service.Withdraw("ACC1002", 5000);
                Console.WriteLine("✓ Transaction Successful");
            }
            catch (AccountFrozenException ex)
            {
                Console.WriteLine($"✗ AccountFrozenException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.\n");
            }

            // Task 6: Simulate Network Failure with Retry
            Console.WriteLine("Task 6: Withdraw with Network Retry Logic");
            try
            {
                service.WithdrawWithRetry("ACC1001", 2000, 3);
            }
            catch (NetworkException ex)
            {
                Console.WriteLine($"✗ NetworkException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.\n");
            }

            // Display all transaction logs
            service.DisplayTransactionLogs();

            // Final account status
            Console.WriteLine("========== FINAL ACCOUNT STATUS ==========");
            service.DisplayBalance("ACC1001");
            Console.WriteLine();
            service.DisplayBalance("ACC1002");

            Console.ReadLine();
        }
    }
}
