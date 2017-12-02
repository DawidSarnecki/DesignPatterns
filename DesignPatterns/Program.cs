using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCommandPattern();
        }

        private static void RunCommandPattern()
        {
            Client client = new Client();
            client.TransferMoney(100);
        }

    }
}
