using DemoProject.Domain.Customers;
using DemoProject.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DemoProject.Application.Customers.GetCustomers
{
    public class GetCustomersQueryHandler :
        IRequestHandler<GetCustomersQuery, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomersQueryHandler> _logger;

        public GetCustomersQueryHandler(
            ICustomerRepository customerRepository,
            ILogger<GetCustomersQueryHandler> logger) 
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository
                .GetCustomers(request.Page, request.PageSize, cancellationToken);

            var existingCustomers = customers.ToDto();

            _logger.LogInformation("Retrieved { @count } customers", existingCustomers.Count.ToString());
            
            return Result<List<CustomerDto>>.Success(existingCustomers);
        }
    }
}
