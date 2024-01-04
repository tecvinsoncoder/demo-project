using DemoProject.Shared;
using MediatR;

namespace DemoProject.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
