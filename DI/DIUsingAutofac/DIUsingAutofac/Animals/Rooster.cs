
namespace DIUsingAutofac
{
    public class Rooster : IAnimal
    {
        private string _sound = "kuku - ryku";

        public string GetName => GetType().Name;
        public string GetSound => _sound;
    }
}
