
namespace DIUsingAutofac
{
    using Autofac;

    public class AutofacConfig
    {
        public IContainer Container { get; set; }

        public AutofacConfig()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Frog>().AsImplementedInterfaces();
            builder.RegisterType<ColorPrinter>().AsImplementedInterfaces();

            // if ther are many registration for the same interface  (in this case: IPrinter) the latest registration overrides all earlier
            builder.RegisterType<SpeechPrinter>().AsImplementedInterfaces();

#if DEBUG
            builder.RegisterType<Rooster>().AsImplementedInterfaces();
            builder.RegisterType<SimplePrinter>().AsImplementedInterfaces();
#endif

            Container = builder.Build();
        }
    }
}
