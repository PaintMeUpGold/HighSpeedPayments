namespace HighVelocityPaymentsLibrary.Model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [DisplayName("Employee Name")]
        [StringLength(1000), Required]
        public string Name { get; set; }

        [DisplayName("Number of Dependents")]
        public int NumberOfDependents { get; set; }
    }
}