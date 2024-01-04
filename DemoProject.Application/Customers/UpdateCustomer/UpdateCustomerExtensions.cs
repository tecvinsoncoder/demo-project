using DemoProject.Domain.Customers;

namespace DemoProject.Application.Customers.UpdateCustomer
{
    internal static class UpdateCustomerExtensions
    {
        public static Customer ToEntity(this UpdateCustomerCommand command)
        {
            return Customer.UpdateCustomer(
                command.Id,
                command.FirstName,
                command.LastName,
                command.Phone,
                command.Email);
        }
    }
}
