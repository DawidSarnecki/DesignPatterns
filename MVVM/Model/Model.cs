using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Model
    {
        public decimal Sum { get; private set; }
        public decimal Limit { get; private set; }

        public Model(decimal sum, decimal limit)
        {
            Sum = sum;
            Limit = limit;
        }

        private bool isAmountCorrect(decimal amount)
        {
            return !isAmountOverLimit(amount) && amount > 0;
        }

        private bool isAmountOverLimit(decimal amount)
        {
            return (Sum + amount > Limit) ? true : false;
        }

        public void Add(decimal amount)
        {
            if (isAmountCorrect(amount))
            {
                Sum += amount;
                return;
            }

            throw new ArgumentOutOfRangeException("Incorrect amount.");
        }
    }
}
