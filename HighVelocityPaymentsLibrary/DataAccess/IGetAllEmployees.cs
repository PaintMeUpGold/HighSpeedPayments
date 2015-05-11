namespace HighVelocityPaymentsLibrary.DataAccess
{
    using System.Collections.Generic;

    using Model;

    public interface IGetAllEmployees
    {
        IEnumerable<Employee> Execute();
    }
}