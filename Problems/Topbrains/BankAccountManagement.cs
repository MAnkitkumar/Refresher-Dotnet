using System;

namespace BankSys
{
    public class Account
    {
        private string name;
        private double balance;

        public Account(string name, double initialBalance)
        {
            this.name = name;
            this.balance = initialBalance;
        }

        public double deposit(double depositAmount)
        {
            if (depositAmount > 0)
            {
                this.balance += depositAmount;
            }
            return this.balance;
        }

        public double getBalance()
        {
            return this.balance;
        }

        public void setName(string newName)
        {
            this.name = newName;
        }

        public string getName()
        {
            return this.name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account("John Doe", 1250);
            Console.WriteLine(account1.getBalance());
            Console.WriteLine(account1.getName());

            Account account2 = new Account("Riya", 500);
            Console.WriteLine(account2.getBalance());
            Console.WriteLine(account2.deposit(750.5));
            Console.WriteLine(account2.getBalance());

            account2.setName("Riya Amit Mehta");
            Console.WriteLine(account2.getName());
        }
    }
}
