namespace HighVelocityPaymentsLibrary.DataAccess
{
    using Model;

    public interface IGetEmployee
    {
        Employee Execute(int id);
    }
}