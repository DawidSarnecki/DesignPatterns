using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using MVC.Controller;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            RunMVC();
        }

        private static void RunCommandPattern()
        {
            Client client = new Client();
            client.TransferMoney(100);
        }

        private static void RunMVC()
        {
            decimal limitOfValue = 100; 
            Controller controller = new Controller(limitOfValue);
            controller.Run();
        }

    }
}
