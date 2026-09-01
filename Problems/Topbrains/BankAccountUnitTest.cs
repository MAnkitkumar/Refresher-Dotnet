using NUnit.Framework;
using System;

namespace BankAccountNUnitExample
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            // Arrange
            Program account = new Program(1000);
            decimal depositAmount = 500;
            decimal expected = 1500;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expected, account.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            // Arrange
            Program account = new Program(1000);
            decimal negativeAmount = -100;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(negativeAmount));
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            // Arrange
            Program account = new Program(1000);
            decimal withdrawAmount = 300;
            decimal expected = 700;

            // Act
            account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(expected, account.Balance);
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            // Arrange
            Program account = new Program(1000);
            decimal withdrawAmount = 1500;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(withdrawAmount));
        }
    }
}
