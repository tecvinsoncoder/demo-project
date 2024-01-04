﻿using DemoProject.Domain.Customers;
using FluentValidation;

namespace DemoProject.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandValidator
        : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator(ICustomerRepository customerRepository)
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync( async (email, _) =>
            {
                return await customerRepository.IsEmailUnique(email);
            })
            .WithMessage("Email must be unique");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MaximumLength(15);
        }
    }
}
