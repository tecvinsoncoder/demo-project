using Asp.Versioning;
using DemoProject.ApiModels.Customer;
using DemoProject.Application.Customers.CreateCustomer;
using DemoProject.Application.Customers.GetCustomerById;
using DemoProject.Application.Customers.GetCustomers;
using DemoProject.Application.Customers.UpdateCustomer;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Presentation.Controllers.v1
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CreateCustomerRequest req,
            IValidator<CreateCustomerCommand> validator,
            CancellationToken cancellationToken)
        {
            var command = new CreateCustomerCommand()
            {
                Email = req.Email,
                Phone = req.Phone,
                FirstName = req.FirstName,
                LastName = req.LastName
            };

            var validationRst = validator.Validate(command);

            if (validationRst != null)
            {
                return BadRequest(Results.ValidationProblem(validationRst.ToDictionary()));
            }

            var result = await _sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            Guid customerId,
            [FromBody] UpdateCustomerRequest req,
             IValidator<UpdateCustomerCommand> validator,
            CancellationToken cancellationToken)
        {
            var command = new UpdateCustomerCommand()
            {
                Id = customerId,
                Email = req.Email,
                Phone = req.Phone,
                FirstName = req.FirstName,
                LastName = req.LastName
            };

            var validationRst = validator.Validate(command);

            if (validationRst != null)
            {
                return BadRequest(Results.ValidationProblem(validationRst.ToDictionary()));
            }

            var result = await _sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet]

        public async Task<IActionResult> GetCustomers(
            int page = 0,
            int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var command = new GetCustomersQuery()
            {
                Page = page,
                PageSize = pageSize,
            };
            var result = await _sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("/{customerId}")]

        public async Task<IActionResult> GetCustomer(
            Guid customerId,
            CancellationToken cancellationToken = default)
        {
            var command = new GetCustomerByIdQuery()
            {
                Id = customerId
            };
            var result = await _sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
