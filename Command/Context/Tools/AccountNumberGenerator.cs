using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public static class AccountNumberGenerator
    {
        //source: https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min = 100000, int max = 199999 )
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
    }
}
