using DemoProject.Shared;
using MediatR;

namespace DemoProject.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Result>
    {
        public Guid CustomerId { get; set; }
    }
}
