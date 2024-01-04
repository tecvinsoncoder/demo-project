using DemoProject.Domain.Customers;
using DemoProject.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoProject.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler :
        IRequestHandler<UpdateCustomerCommand, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ILogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository
                .GetById(request.Id, cancellationToken);

            if (existingCustomer == null)
            {
                return Result<Customer>.Failure(CustomerErrors.CustomerNotFound);
            }

            var customerToUpdate = request.ToEntity();
            var updatedCustomer = await _customerRepository
                .Update(customerToUpdate, cancellationToken);

            _logger.LogInformation("Customer { @id } updated successfully", updatedCustomer.Id);

            return await Task.FromResult(Result<CustomerDto>.Success(updatedCustomer.ToDto()));
        }
    }
}
