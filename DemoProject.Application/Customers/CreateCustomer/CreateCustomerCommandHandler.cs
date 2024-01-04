using DemoProject.Domain.Customers;
using DemoProject.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace DemoProject.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler :
        IRequestHandler<CreateCustomerCommand, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateCustomerCommand command, 
            CancellationToken cancellationToken)
        {
            var customer = command.ToEntity();

            var customerExist = await _customerRepository.Exist(customer, cancellationToken);

            if (customerExist)
            {
                return Result<Customer>.Failure(CustomerErrors.CustomerExist);
            }
            
            var createdCustomer = await _customerRepository
                .Add(customer, cancellationToken);

            _logger.LogInformation("Customer { @id } created successfully", createdCustomer.Id);

            return await Task.FromResult(Result<CustomerDto>.Success(createdCustomer.ToDto()));
        }
    }
}
