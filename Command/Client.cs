using System;
using Command.Context;
using System.Windows.Input;

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
            TransferData firstDateSet = new TransferData() {
                                                                SenderAccount = _accountFirst,
                                                                ReceiverAccount = _accountSecond,
                                                                transferValue = 100
                                                            };
            ICommand transferCommand = new RelayCommand(
                (object parameter) =>
            {
                TransferData data = (TransferData)parameter;
                if (data.isExecuted)
                {
                    Console.WriteLine("Transfer was executed yet.");
                    return;
                }
                BankAccount.MakeTransfer(data.SenderAccount, data.ReceiverAccount, data.transferValue);
                data.isExecuted = true;
            },
                (object parameter) =>
                {
                    TransferData data = (TransferData)parameter;
                    return !data.isExecuted && data.transferValue > 0;
                });

            //execution
            if (transferCommand.CanExecute(firstDateSet))
            {
                transferCommand.Execute(firstDateSet);
            }
            else
            {
                Console.WriteLine("Can't execute transer");
            }

            //without checking with CanExecute() operation is not allowed becouse transfer was executed yet;
            transferCommand.Execute(firstDateSet);
        }
    }
}
