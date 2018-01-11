
namespace DIUsingAutofac
{
    using System;
    using System.Speech.Synthesis;

    public class ColorPrinter : IPrinter
    {
        public string GetName => GetType().Name;

        public void Print(string content)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(content);
        }
    }
}
