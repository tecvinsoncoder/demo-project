using DemoProject.Shared;
using MediatR;

namespace DemoProject.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Result>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
