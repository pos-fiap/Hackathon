using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class CustomerVehicleValidator : AbstractValidator<CustomerVehicleDto>
    {
        public CustomerVehicleValidator()
        {
            //RuleFor(p => p.Plate).NotNull().WithMessage("Plate is a required field");
        }
    }
}