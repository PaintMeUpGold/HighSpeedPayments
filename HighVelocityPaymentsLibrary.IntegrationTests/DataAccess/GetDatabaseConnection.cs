namespace HighVelocityPaymentsLibrary.IntegrationTests.DataAccess
{
    using System.Data;
    using System.Data.SqlClient;

    public static class GetDatabaseConnection
    {
        public static IDbConnection Create()
        {
            //const string connectionString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=PayFun;Integrated Security=True;";
            const string connectionString = @"Data Source=localhost;Initial Catalog=PayFun;Integrated Security=True;";
            return new SqlConnection(connectionString);
        }
    }
}