using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).NotNull().WithMessage("Username is a required field").EmailAddress().WithMessage("Username has to be a valid email");
            RuleFor(p => p.Password).NotNull().WithMessage("Password is a required field");
        }
    }
}
