namespace HighVelocityPaymentsLibrary
{
    using Model;

    public class EmployeeBenefitsCalculator : IEmployeeBenefitsCalculator
    {
        public EmployeeBenefitsCostViewModel CalculateEmployeeBenefitCost(Employee employee)
        {
            var returnView = new EmployeeBenefitsCostViewModel();
            var discountPercentage = employee.Name.StartsWith("A") ? 10 : 0;
            returnView.EmployeeCost = 1000.00m * ((100.00m - discountPercentage) / 100);
            returnView.DependentCost = employee.NumberOfDependents * 500.00m;
            returnView.TotalCost = returnView.EmployeeCost + returnView.DependentCost;
            if (discountPercentage > 0.00)
            {
                returnView.IsDiscountApplied = true;
                returnView.Notes = "10% Letter-A discount applied";
            }
            returnView.Id = employee.Id;
            returnView.Name = employee.Name;
            returnView.NumberOfDependents = employee.NumberOfDependents;
            return returnView;
        }
    }
}