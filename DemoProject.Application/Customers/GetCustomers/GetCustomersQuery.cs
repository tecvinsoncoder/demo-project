using DemoProject.Shared;
using MediatR;

namespace DemoProject.Application.Customers.GetCustomers
{
    public class GetCustomersQuery : IRequest<Result>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set;}
    }
}
