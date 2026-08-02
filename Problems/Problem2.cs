using System;
namespace BankSys
{
    public class Account
    {
        // TODO: Add private fields
        private string name;
        private double balance;

        // TODO: Implement constructor
        public Account(string name, double initialBalance)
        {
            this.name = name;
            this.balance = initialBalance;
        }

        // TODO: Implement deposit method
        public double deposit(double depositAmount)
        {
            balance += depositAmount;
            return balance;
        }

        // TODO: Implement getBalance method
        public double getBalance()
        {
            return balance;
        }

        // TODO: Implement setName method
        public void setName(string newName)
        {
            name = newName;
        }

        // TODO: Implement getName method
        public string getName()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test your implementation here
            Account account1 = new Account("Alok Mittal", 1250.00);
            Console.WriteLine(account1.getBalance());
        }
    }
}