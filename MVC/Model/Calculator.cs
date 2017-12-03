using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    public class Calculator
    {
        public decimal Sum { get; private set; }
        public decimal Limit { get; private set; }

        public Calculator(decimal limit, decimal sum)
        {
            Sum = sum;
            Limit = limit;
            OnSumChanged(Sum, Limit);
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
                OnSumChanged(Sum, Limit);
                return;
            }

            throw new ArgumentOutOfRangeException("Incorrect amount.");
        }

        // add delegate (event type)
        public delegate void ChangedSumEventHandler(decimal sum, decimal limit);

        // add event    
        public event ChangedSumEventHandler SumChanged;

        //helper method
        private void OnSumChanged(decimal sum, decimal limit)
        {
            if (SumChanged != null)
            {
                SumChanged(sum, limit);
            }
        }

    }
}
