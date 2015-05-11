namespace HighVelocityPaymentsLibrary.DataAccess
{
    using System.Data;
    using DapperExtensions;
    using Model;

    public class GetEmployee : IGetEmployee
    {
        private readonly IDbConnection connection;

        public GetEmployee(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Employee Execute(int id)
        {
            connection.Open();
            var employee = connection.Get<Employee>(id);
            connection.Close();
            return employee;
        }
    }
}