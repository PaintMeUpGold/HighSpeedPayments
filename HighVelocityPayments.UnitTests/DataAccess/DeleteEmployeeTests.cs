namespace HighVelocityPaymentsLibrary.UnitTests.DataAccess
{
    using System.Linq;
    using DapperExtensions;
    using HighVelocityPaymentsLibrary.DataAccess;
    using FluentAssertions;
    using Model;
    using NUnit.Framework;

    public class DeleteEmployeeTests
    {
        private DeleteEmployee sut;
        
        [Test]
        public void ThenAllEmployeesShouldBeReturned()
        {
            using (var connection = GetDatabaseConnection.Create())
            {
                connection.Open();
                sut = new DeleteEmployee(connection);
                var currentEmployeeCount = connection.GetList<Employee>().Count();
                var fakeEmployee = new Employee { Name = "Chris Brannon", NumberOfDependents = 2 };
                var newId = connection.Insert(fakeEmployee);
                connection.Close();
                sut.Execute(newId);
                connection.Open();
                var newEmployeeCount = connection.GetList<Employee>().Count();
                connection.Close();
                newEmployeeCount.Should().Be(currentEmployeeCount);
            }
        } 
    }
}