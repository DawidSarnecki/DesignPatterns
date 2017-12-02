using System;

namespace Command
{
    public class Client
    {
        BankAccount _accountFirst = new BankAccount();
        BankAccount _accountSecond = new BankAccount();
        public Client()
        {
            Initialize();
        }

       private void Initialize()
        {
            _accountFirst.DepositMoney(1000);
            _accountSecond.DepositMoney(1000);
        }
        public void TransferMoney(int transferValue)
        {
            //preparation of transfer
            MyICommand firstCommnad = new TransferCommand(_accountFirst, _accountSecond, transferValue);

            //execution
            if (firstCommnad.CanExecute())
            {
                firstCommnad.Execute();
            }
            else
            {
                Console.WriteLine("Can't execute transer");
            }

            //without checking with CanExecute() operation is not allowed becouse transfer was executed yet;
            firstCommnad.Execute();
        }
    }
}
