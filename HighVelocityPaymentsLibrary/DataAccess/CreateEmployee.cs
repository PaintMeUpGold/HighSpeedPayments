namespace HighVelocityPaymentsLibrary.DataAccess
{
    using System.Data;
    using DapperExtensions;
    using Model;

    public class CreateEmployee : IDataAccess
    {
        private readonly IDbConnection connection;

        public CreateEmployee(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int Execute(Employee employeeToCreate)
        {
            connection.Open();
            var employeeId = connection.Insert(employeeToCreate);
            connection.Close();
            return employeeId;
        }
    }
}