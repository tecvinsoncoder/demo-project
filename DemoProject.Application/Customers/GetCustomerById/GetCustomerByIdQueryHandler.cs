using DemoProject.Domain.Customers;
using DemoProject.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoProject.Application.Customers.GetCustomerById
{
    public class GetCustomerByIdQueryHandler :
        IRequestHandler<GetCustomerByIdQuery, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomerByIdQueryHandler> _logger;

        public GetCustomerByIdQueryHandler(
            ICustomerRepository customerRepository,
            ILogger<GetCustomerByIdQueryHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository
                .GetById(request.Id, cancellationToken);

            if (existingCustomer == null)
            {
                return Result<Customer>.Failure(CustomerErrors.CustomerNotFound);
            }

            _logger.LogInformation("Details of Customer { @Id } retrieved", request.Id);
            var customer = existingCustomer.ToDto();

            return Result<CustomerDto>.Success(customer);
        }
    }
}
