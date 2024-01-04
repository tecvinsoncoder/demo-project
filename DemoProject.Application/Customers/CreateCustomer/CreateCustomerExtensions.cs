using DemoProject.Domain.Customers;

namespace DemoProject.Application.Customers.CreateCustomer
{
    internal static class CreateCustomerExtensions
    {
        public static Customer ToEntity(this CreateCustomerCommand command) 
        {
            return Customer.CreateCustomer(
                command.FirstName, 
                command.LastName, 
                command.Phone, 
                command.Email);
        }
    }
}
