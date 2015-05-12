namespace HighVelocityPaymentsLibrary.IntegrationTests.DataAccess
{
    using System.Data;

    using DapperExtensions;

    using FluentAssertions;

    using HighVelocityPaymentsLibrary.DataAccess;

    using Model;

    using NUnit.Framework;

    public static class DeleteEmployeeTests
    {
        public class WhenWeDeleteAnEmployee
        {
            private DeleteEmployee sut;
            private int newEmployeeId;

            [TestFixtureSetUp]
            public void Setup()
            {
                using (var connection = GetDatabaseConnection.Create())
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    var fakeEmployee = new Employee { Name = "DELETE TEST", NumberOfDependents = 2 };
                    newEmployeeId = connection.Insert(fakeEmployee);
                    connection.Close();
                }
            }

            [Test]
            public void ThenEmployeeShouldBeDeleted()
            {
                using (var connection = GetDatabaseConnection.Create())
                {
                    sut = new DeleteEmployee(connection);
                    sut.Execute(newEmployeeId);
                    connection.Open();
                    var retrievedEmployee = connection.Get<Employee>(newEmployeeId);
                    connection.Close();
                    retrievedEmployee.Should().BeNull();
                }
            }
        }
    }
}