namespace HighVelocityPaymentsLibrary.Model
{
    using System.ComponentModel;

    public class EmployeeBenefitsCostViewModel : Employee
    {
        [DisplayName("Employee Benefit Cost")]
        public decimal EmployeeCost { get; set; }

        [DisplayName("Employee Dependent Benefit Cost")]
        public decimal DependentCost { get; set; }

        [DisplayName("Total Benefit Cost")]
        public decimal TotalCost { get; set; }
        
        public string Notes { get; set; }

        public bool IsDiscountApplied { get; set; }
    }
}
