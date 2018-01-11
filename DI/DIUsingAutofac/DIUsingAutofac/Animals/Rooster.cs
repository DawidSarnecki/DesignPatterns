
namespace DIUsingAutofac
{
    public class Rooster : IAnimal
    {
        private string _sound = "kukuk - ryku";

        public string GetName => GetType().Name;
        public string GetSound => _sound;
    }
}
