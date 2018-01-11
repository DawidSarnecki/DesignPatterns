using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIUsingAutofac
{
    interface IPrinter
    {
        string GetName { get; }
        void Print(string content);
    }
}
