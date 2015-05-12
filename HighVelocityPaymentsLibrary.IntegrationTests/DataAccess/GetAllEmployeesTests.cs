namespace HighVelocityPaymentsLibrary.IntegrationTests.DataAccess
{
    using System.Data;
    using System.Linq;

    using DapperExtensions;

    using FizzWare.NBuilder;

    using FluentAssertions;

    using HighVelocityPaymentsLibrary.DataAccess;

    using Model;

    using NUnit.Framework;

    public class WhenWeAskForAllEmployees
    {
        private const int NumberOfEmployeesToCreate = 5;
        private GetAllEmployees sut;

        [TestFixtureSetUp]
        public void Setup()
        {
            using (var connection = GetDatabaseConnection.Create())
            {
                var employeeList = Builder<Employee>.CreateListOfSize(NumberOfEmployeesToCreate).Build();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                connection.Delete<Employee>(100);
                foreach (var fakeEmployee in employeeList)
                    connection.Insert(fakeEmployee);
                connection.Close();
            }
        }

        [Test]
        public void ThenAllEmployeesShouldBeReturned()
        {
            using (var connection = GetDatabaseConnection.Create())
            {
                sut = new GetAllEmployees(connection);
                var listOfAllEmployees = sut.Execute();
                listOfAllEmployees.Count().Should().Be(NumberOfEmployeesToCreate);
            }
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            using (var connection = GetDatabaseConnection.Create())
            {
                connection.Open();
                connection.Delete<Employee>(100);
                connection.Close();
            }
        }
    }
}