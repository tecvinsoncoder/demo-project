using DemoProject.Domain.Customers;
using DemoProject.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoProject.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler :
        IRequestHandler<DeleteCustomerCommand, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository
                .GetById(request.CustomerId, cancellationToken);

            if (existingCustomer == null)
            {
                return Result<Customer>.Failure(CustomerErrors.CustomerNotFound);
            }

            var rsp = await _customerRepository.Delete(request.CustomerId, cancellationToken);

            return Result<int>.Success(rsp);
        }
    }
}
