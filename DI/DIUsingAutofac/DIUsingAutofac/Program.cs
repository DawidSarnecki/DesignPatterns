
namespace DIUsingAutofac
{
    using Autofac;

    class Program
    {
        static void Main(string[] args)
        {
            Print();
        }

        public static void Print()
        {
            AutofacConfig autofac = new AutofacConfig();
            using (ILifetimeScope scope = autofac.Container.BeginLifetimeScope())
            {
                IPrinter printer = scope.Resolve<IPrinter>();
                printer.Print(printer.GetName);

                IAnimal animal = scope.Resolve<IAnimal>();
                printer.Print($"{ animal.GetName} : {animal.GetSound}");
            }
        }
    }
}
