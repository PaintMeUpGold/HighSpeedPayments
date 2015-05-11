namespace HighVelocityPaymentsLibrary.UnitTests
{
    using FluentAssertions;
    using Model;
    using NUnit.Framework;

    public static class EmployeeBenefitCalculatorTests
    {
        public class WhenCalculatingBenefitsForEmployeeWhoseNameDoesntBeginWithA
        {
            private EmployeeBenefitsCalculator sut = new EmployeeBenefitsCalculator();
            private readonly Employee employeeWhoseNameDoesntBeginWithA = new Employee { Name = "Chris Brannon" };
            const decimal ExpectedBenefitCost = 1000.00m;
            protected decimal ActualBenefitCost;
            
            [Test]
            public void ThenTheEmployeesBenefitCostShouldBe1000()
            {
                sut = new EmployeeBenefitsCalculator();
                ActualBenefitCost = sut.CalculateEmployeeBenefitCost(employeeWhoseNameDoesntBeginWithA).TotalCost;    
                ActualBenefitCost.Should().Be(ExpectedBenefitCost);
            }
        }

        public class WhenCalculatingBenefitsForEmployeeWhoseNameBeginsWithA
        {
            private EmployeeBenefitsCalculator sut = new EmployeeBenefitsCalculator();
            private readonly Employee employeeWhoseNameBeginsWithA = new Employee { Name = "Alfred E. Neuman" };
            const decimal ExpectedBenefitCost = 900.00m;
            protected decimal ActualBenefitCost;

            [Test]
            public void ThenTheEmployeesBenefitCostShouldBe900()
            {
                sut = new EmployeeBenefitsCalculator();
                ActualBenefitCost = sut.CalculateEmployeeBenefitCost(employeeWhoseNameBeginsWithA).TotalCost;
                ActualBenefitCost.Should().Be(ExpectedBenefitCost);
            }
        }

        public class WhenCalculatingBenefitsForEmployeeWhoseNameDoesntBeginWithAWithOneDependent
        {
            private EmployeeBenefitsCalculator sut = new EmployeeBenefitsCalculator();
            private readonly Employee employeeWhoseNameDoesntBeginWithA = new Employee { Name = "Chris Brannon", NumberOfDependents = 1};
            const decimal ExpectedBenefitCost = 1500.00m;
            protected decimal ActualBenefitCost;

            [Test]
            public void ThenTheEmployeesBenefitCostShouldBe1500()
            {
                sut = new EmployeeBenefitsCalculator();
                ActualBenefitCost = sut.CalculateEmployeeBenefitCost(employeeWhoseNameDoesntBeginWithA).TotalCost;
                ActualBenefitCost.Should().Be(ExpectedBenefitCost);
            }
        }

        public class WhenCalculatingBenefitsForEmployeeWhoseNameDoesntBeginWithAWithTwentyDependents
        {
            private EmployeeBenefitsCalculator sut = new EmployeeBenefitsCalculator();
            private readonly Employee employeeWhoseNameDoesntBeginWithA = new Employee { Name = "Chris Brannon", NumberOfDependents = 20 };
            const decimal ExpectedBenefitCost = 11000.00m;
            protected decimal ActualBenefitCost;

            [Test]
            public void ThenTheEmployeesBenefitCostShouldBe11000()
            {
                sut = new EmployeeBenefitsCalculator();
                ActualBenefitCost = sut.CalculateEmployeeBenefitCost(employeeWhoseNameDoesntBeginWithA).TotalCost;
                ActualBenefitCost.Should().Be(ExpectedBenefitCost);
            }
        }

        public class WhenCalculatingBenefitsForEmployeeWhoseNameBeginsWithAWithOneDependent
        {
            private EmployeeBenefitsCalculator sut = new EmployeeBenefitsCalculator();
            private readonly Employee employeeWhoseNameDoesntBeginWithA = new Employee { Name = "Alfred E. Neuman", NumberOfDependents = 1 };
            const decimal ExpectedBenefitCost = 1400.00m;
            protected decimal ActualBenefitCost;

            [Test]
            public void ThenTheEmployeesBenefitCostShouldBe1400()
            {
                sut = new EmployeeBenefitsCalculator();
                ActualBenefitCost = sut.CalculateEmployeeBenefitCost(employeeWhoseNameDoesntBeginWithA).TotalCost;
                ActualBenefitCost.Should().Be(ExpectedBenefitCost);
            }
        }

        public class WhenCalculatingBenefitsForEmployeeWhoseNameBeginsWithAWithTwentyDependents
        {
            private EmployeeBenefitsCalculator sut = new EmployeeBenefitsCalculator();
            private readonly Employee employeeWhoseNameDoesntBeginWithA = new Employee { Name = "Alfred E. Neuman", NumberOfDependents = 20 };
            const decimal ExpectedBenefitCost = 10900.00m;
            protected decimal ActualBenefitCost;

            [Test]
            public void ThenTheEmployeesBenefitCostShouldBe10900()
            {
                sut = new EmployeeBenefitsCalculator();
                ActualBenefitCost = sut.CalculateEmployeeBenefitCost(employeeWhoseNameDoesntBeginWithA).TotalCost;
                ActualBenefitCost.Should().Be(ExpectedBenefitCost);
            }
        }
    }
}