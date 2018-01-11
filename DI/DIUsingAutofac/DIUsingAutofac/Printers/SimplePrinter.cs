using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUsingAutofac
{
    class SimplePrinter : IPrinter
    {
        public string GetName => GetType().Name;

        public void Print(string content)
        {
            Console.WriteLine(content);
        }
    }
}
