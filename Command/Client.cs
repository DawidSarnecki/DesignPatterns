using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BankAccount.MakeTransfer(_accountFirst, _accountSecond, transferValue);
            _accountFirst.ShowBalance();
            _accountSecond.ShowBalance();
        }
    }
}
