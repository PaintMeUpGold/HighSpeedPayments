namespace HighVelocityPaymentsLibrary.DataAccess
{
    using System.Data;
    using DapperExtensions;
    using Model;

    public class DeleteEmployee : IDataAccess
    {
        private readonly IDbConnection connection;

        public DeleteEmployee(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Execute(int id)
        {
            connection.Open();
            var predicate = Predicates.Field<Employee>(field => field.Id, Operator.Eq, id);
            connection.Delete<Employee>(predicate);
            connection.Close();
        }
    }
}