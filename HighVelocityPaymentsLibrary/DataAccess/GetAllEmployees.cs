namespace HighVelocityPaymentsLibrary.DataAccess
{
    using System.Collections.Generic;
    using System.Data;
    using DapperExtensions;
    using Model;

    public class GetAllEmployees : IGetAllEmployees
    {
        private readonly IDbConnection connection;

        public GetAllEmployees(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Employee> Execute()
        {
            connection.Open();
            var employeeList = connection.GetList<Employee>();
            connection.Close();
            return employeeList;
        }
    }
}