﻿using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class PersonUpdateValidator : AbstractValidator<PersonUpdateDTO>
    {
        public PersonUpdateValidator()
        {
            RuleFor(p => p.Status).NotNull().WithMessage("Status is a required field");
            RuleFor(p => p.Name).NotNull().WithMessage("Name is a required field");
            RuleFor(p => p.Document).NotNull().WithMessage("Document is a required field").MaximumLength(15).WithMessage("Document cannot be greater than 15");
        }
    }
}
