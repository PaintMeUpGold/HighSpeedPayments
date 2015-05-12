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
            var featureToggles = container.Resolve<FeatureToggles>();

            try
            {
                container.Register(
                    Component.For<IDbConnection>().UsingFactoryMethod(DatabaseConnectionFactory.Create).LifestyleTransient(),
                    Component.For<IGetEmployee>().ImplementedBy<GetEmployee>().LifestyleTransient(),
                    Component.For<IGetAllEmployees>().ImplementedBy<GetAllEmployees>().LifestyleTransient(),
                    Component.For<ICreateEmployee>().ImplementedBy<CreateEmployee>().LifestyleTransient(),
                    Component.For<IDeleteEmployee>().ImplementedBy<DeleteEmployee>().LifestyleTransient(),
                    Component.For<IEmployeeBenefitsCalculator>().ImplementedBy<EmployeeBenefitsCalculator>().LifestyleTransient(),
                    Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()
                    );

                if (featureToggles.HandleDependents)
                {
                    // register Dependent-specific components here, if there are any.
                }
            }
            finally
            {
                container.Release(featureToggles);
            }
        }
    }
}