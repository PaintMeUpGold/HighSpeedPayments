namespace HighVelocityPaymentsWebApp.Installers
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class DatabaseConnectionFactory
    {
        public static IDbConnection Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["employeeDataStore"].ConnectionString;
            return new SqlConnection(connectionString);
        } 
    }
}