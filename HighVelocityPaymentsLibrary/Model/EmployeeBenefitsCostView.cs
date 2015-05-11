namespace HighVelocityPaymentsLibrary.Model
{
    public class EmployeeBenefitsCostView : Employee
    {
        public decimal EmployeeCost { get; set; }
        public decimal DependentCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Notes { get; set; }
    }
}
