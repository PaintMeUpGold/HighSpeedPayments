namespace HighVelocityPaymentsWebApp.App_Start
{
    using System.Configuration;
    using System.Reflection;
    using DbUp;

    public class RegisterDatabaseScripts
    {
        public static void EnsureDatabaseSchemaIsInstalled()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["employeeDataStore"].ConnectionString;

            var upgrader =
                DeployChanges.To
                             .SqlDatabase(connectionString)
                             .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                             .LogToConsole()
                             .Build();

            var result = upgrader.PerformUpgrade();
        }
    }
}