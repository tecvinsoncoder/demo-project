using DemoProject.ApiModels.Customer;
using DemoProject.Application.Customers.CreateCustomer;
using DemoProject.Application.Customers.UpdateCustomer;

namespace DemoProject.Presentation.Extensions
{
    public static class CustomerExtensions
    {
        public static CreateCustomerCommand ToCommand(
            this CreateCustomerRequest request)
        {
            return new CreateCustomerCommand()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone
            };
        }

        public static UpdateCustomerCommand Command(
            this UpdateCustomerRequest request)
        {
            return new UpdateCustomerCommand()
            {
                Id = request.CustomerId,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone
            };
        }
    }
}
