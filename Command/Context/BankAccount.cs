using System;

namespace Command
{
    internal class BankAccount
    {
        private int accountNumber;
        private decimal balance;

        public BankAccount()
        {
            balance = 0;
            accountNumber = AccountNumberGenerator.GetRandomNumber();
        }

        int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public void DepositMoney(decimal depositValue)
        {
            balance += depositValue;
            Console.WriteLine($"Deposited money: {depositValue}. Actual balance: {balance}");
        }

        public bool WithdrawMoney(decimal withdrawValue)
        {
            if (withdrawValue > balance)
            {
                Console.WriteLine($"There is no enough money. Withdrowed request: {withdrawValue}. Actual balance: {balance}");
                return false;
            }

            balance -= withdrawValue;
            Console.WriteLine($"Withdrowed money: {withdrawValue}. Actual balance: {balance}");
            return true; 
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balance for account number {accountNumber}: {balance}");
        }

        public static bool MakeTransfer(BankAccount senderAccount, BankAccount receiverAccount, decimal transferAmount)
        {
            Console.WriteLine($"Started transfer money: {transferAmount}");

            if (senderAccount == receiverAccount )
            {
                Console.WriteLine("The account number error. Canceled operation.");
            }

            if (senderAccount.WithdrawMoney(transferAmount))
            {
                receiverAccount.DepositMoney(transferAmount);
                return true;
            }

            return false;
        }

    }
}
