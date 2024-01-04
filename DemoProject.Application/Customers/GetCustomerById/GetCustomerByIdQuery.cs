using DemoProject.Shared;
using MediatR;

namespace DemoProject.Application.Customers.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
