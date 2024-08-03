using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class DoctorValidator : AbstractValidator<DoctorDto>
    {
        public DoctorValidator()
        {
            RuleFor(p => p.PersonalInformations.CPF).NotNull().WithMessage("CPF is a required field");
            RuleFor(p => p.CRM).NotNull().WithMessage("CRM is a required field");
            RuleFor(p => p.Specialty).NotNull().WithMessage("Specialty is a required field");
        }
    }

    public class PostDoctorValidator : AbstractValidator<PostDoctorDto>
    {
        public PostDoctorValidator()
        {
            RuleFor(p => p.User.PersonalInformations.CPF).NotNull().WithMessage("CPF is a required field");
            RuleFor(p => p.CRM).NotNull().WithMessage("CRM is a required field");
            RuleFor(p => p.Specialty).NotNull().WithMessage("Specialty is a required field");
        }
    }
}
