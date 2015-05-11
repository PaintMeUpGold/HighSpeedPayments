namespace HighVelocityPaymentsWebApp.UnitTests.Controllers
{
    using FakeItEasy;

    using HighVelocityPaymentsLibrary;
    using HighVelocityPaymentsLibrary.DataAccess;
    using HighVelocityPaymentsLibrary.Model;

    using HighVelocityPaymentsWebApp.Controllers;

    using NUnit.Framework;

    public static class HomeControllerTests
    {
        public class WhenLookingAtEmployeeDetailView
        {
            private IGetAllEmployees fakeGetAllEmployees;
            private IGetEmployee fakeGetEmployee;
            private IDeleteEmployee fakeDeleteEmployee;
            private ICreateEmployee fakeCreateEmployee;
            private IEmployeeBenefitsCalculator fakeEmployeeBenefitsCalculator;
            private HomeController sut;

            [Test]
            public void ThenWeShouldGetEmployeeAndCalculateBenefitCost()
            {
                fakeGetAllEmployees = A.Fake<IGetAllEmployees>();
                fakeGetEmployee = A.Fake<IGetEmployee>();
                fakeDeleteEmployee = A.Fake<IDeleteEmployee>();
                fakeCreateEmployee = A.Fake<ICreateEmployee>();
                fakeEmployeeBenefitsCalculator = A.Fake<IEmployeeBenefitsCalculator>();
                sut = new HomeController(fakeGetAllEmployees, fakeCreateEmployee, fakeGetEmployee, fakeEmployeeBenefitsCalculator, fakeDeleteEmployee);

                var employee = new Employee() { Id = 1, Name = "Chris Brannon", NumberOfDependents = 2 };
                A.CallTo(() => fakeGetEmployee.Execute(1)).Returns(employee);                
                sut.Details(1);
                A.CallTo(() => fakeGetEmployee.Execute(1)).MustHaveHappened(Repeated.Exactly.Once);
                A.CallTo(() => fakeEmployeeBenefitsCalculator.CalculateEmployeeBenefitCost(employee)).MustHaveHappened(Repeated.Exactly.Once);
            }
        }
    }
}