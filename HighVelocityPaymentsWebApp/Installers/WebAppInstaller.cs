namespace HighVelocityPaymentsWebApp.Installers
{
    using System.Data;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using HighVelocityPaymentsLibrary;
    using HighVelocityPaymentsLibrary.DataAccess;

    public class WebAppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbConnection>().UsingFactoryMethod(DatabaseConnectionFactory.Create).LifestyleTransient(),
                Classes.FromAssemblyNamed("HighVelocityPaymentsLibrary").BasedOn<IDataAccess>(),
                //Component.For<GetAllEmployees>(),
                //Component.For<CreateEmployee>(),
                //Component.For<GetEmployee>(),
                Component.For<EmployeeBenefitsCalculator>(),
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()
                );
        }
    }
}