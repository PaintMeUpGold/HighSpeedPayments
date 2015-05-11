namespace HighVelocityPaymentsLibrary.DataAccess
{
    using Model;

    public interface ICreateEmployee
    {
        int Execute(Employee employeeToCreate);
    }
}