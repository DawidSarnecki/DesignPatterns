using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Context
{
     class TransferData
    {
        public BankAccount SenderAccount;
        public BankAccount ReceiverAccount;
        public decimal transferValue;
        public bool isExecuted;
    }
}
