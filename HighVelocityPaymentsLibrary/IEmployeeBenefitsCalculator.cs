namespace HighVelocityPaymentsLibrary
{
    using Model;

    public interface IEmployeeBenefitsCalculator
    {
        EmployeeBenefitsCostViewModel CalculateEmployeeBenefitCost(Employee employee);
    }
}