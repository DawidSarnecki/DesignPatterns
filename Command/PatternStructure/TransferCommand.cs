using System;

namespace Command
{
    class TransferCommand : MyICommand
    {
        //state
        private bool isExecuted = false;
        private BankAccount _senderAccount;
        private BankAccount _receiverAccount;
        private decimal _transferValue;

        public TransferCommand(BankAccount senderAccount, BankAccount receiverAccount, decimal transferValue)
        {
            _senderAccount = senderAccount;
            _receiverAccount = receiverAccount;
            _transferValue = transferValue;
        }

        public bool CanExecute()
        {
            return !isExecuted && _transferValue > 0;
        }

        public void Execute()
        {
            if (isExecuted)
            {
                Console.WriteLine("Transfer was executed yet.");
                return;
            }

            isExecuted = BankAccount.MakeTransfer(_senderAccount, _receiverAccount, _transferValue);
            _senderAccount.ShowBalance();
            _receiverAccount.ShowBalance();
        }
    }
}
