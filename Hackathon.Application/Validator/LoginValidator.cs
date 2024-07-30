using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Username)
                .NotEmpty()
                .WithMessage("Username is a required field");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password is a required field");
        }
    }
}
