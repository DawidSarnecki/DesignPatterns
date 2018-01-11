
namespace DIUsingAutofac
{
    using System;
    using Autofac;
    using EnvDTE;

    public class AutofacConfig
    {
        public IContainer Container { get; set; }
        public AutofacConfig()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Frog>().AsImplementedInterfaces();
            builder.RegisterType<SimplePrinter>().AsImplementedInterfaces();

            // if there are many registration for the same interface  (in this case: IPrinter) the latest registration overrides all earlier
            builder.RegisterType<SpeechPrinter>().AsImplementedInterfaces();

            ///Programmatically check the build configuration
            /// ref: https://stackoverflow.com/questions/38396377/programmatically-check-the-build-configuration

#if MOCKED_RELEASE
            builder.RegisterType<ColorPrinter>().AsImplementedInterfaces();
#endif

            Container = builder.Build();
            ///// Conditional registration  - not working
            ///// ref: http://autofaccn.readthedocs.io/en/latest/faq/conditional-registration.html
            ///// best practises and recomendations
            ///// http://autofaccn.readthedocs.io/en/latest/best-practices/index.html
            ///// Selection of an Implementation by Parameter Value:
            ///// http://autofaccn.readthedocs.io/en/latest/register/registration.html
            //builder.Register<IPrinter>(c =>
            //{
            //    string currentConfigName = GetCurrentConfigurationName();
            //    if (currentConfigName == MOCKED_RELEASE)
            //    {
            //        return new ColorPrinter();
            //    }
            //    else
            //    {
            //        return new SimplePrinter();
            //    }
            //})
            //.AsImplementedInterfaces();
        }

        //// Automation Access - dte.Solution.Projects.Count = 0 - this is an error cousing an exception
        ///// refs:
        ///// https://blogs.msdn.microsoft.com/kirillosenkov/2009/03/03/how-to-start-visual-studio-programmatically/
        ///// https://msdn.microsoft.com/en-us/library/ms228758.aspx
        ///// https://docs.microsoft.com/en-us/dotnet/api/envdte.configurationmanager.activeconfiguration?view=visualstudiosdk-2017

        //private string GetCurrentConfigurationName()
        //{
        //    string activConfigName = string.Empty;
        //    Type visualStudioType = Type.GetTypeFromProgID("VisualStudio.DTE", true);
        //    DTE dte = (DTE)Activator.CreateInstance(visualStudioType);
        //    if (dte.Solution.Projects.Count > 0)
        //    {
        //        Configuration activeConfig = dte.Solution.Projects.Item(0).ConfigurationManager.ActiveConfiguration;
        //        activConfigName = activeConfig.ConfigurationName;
        //    }

        //    return activConfigName;
        //}
    }
}
