
namespace DIUsingAutofac
{
    public class Frog : IAnimal
    {
        private string _sound = "Rere - kumkum";

        public string GetName => GetType().Name;
        public string GetSound => _sound;
    }
}
