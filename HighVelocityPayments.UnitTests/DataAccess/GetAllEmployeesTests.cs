namespace HighVelocityPaymentsLibrary.UnitTests.DataAccess
{
    using System.Linq;
    using DapperExtensions;
    using HighVelocityPaymentsLibrary.DataAccess;
    using FluentAssertions;
    using Model;
    using NUnit.Framework;

    public class WhenWeAskForAllEmployees
    {
        private GetAllEmployees sut;

        [Test]
        public void ThenAllEmployeesShouldBeReturned()
        {
            using (var connection = GetDatabaseConnection.Create())
            {
                sut = new GetAllEmployees(connection);

                var fakeEmployee = new Employee {Name = "Chris Brannon", NumberOfDependents = 2};
                connection.Open();
                connection.Insert(fakeEmployee);
                var listOfAllEmployees = sut.Execute();
                listOfAllEmployees.Count().Should().Be(1);
                connection.Close();
            }
        }
    }
}