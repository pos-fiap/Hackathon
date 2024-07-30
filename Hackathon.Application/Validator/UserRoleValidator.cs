using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class UserRoleValidator : AbstractValidator<UserRoleDto>
    {
        public UserRoleValidator()
        {
            RuleFor(p => p.UserId).NotNull().WithMessage("UserId is a required field");
            RuleFor(p => p.Roles).NotNull().WithMessage("RoleIds is a required field");
        }
    }
}
