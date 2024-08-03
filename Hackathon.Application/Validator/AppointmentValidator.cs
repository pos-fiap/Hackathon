using FluentValidation;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Validator
{
    public class AppointmentValidator : AbstractValidator<AppointmentDto>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("DoctorId must be greater than 0.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("PatientId must be greater than 0.");

            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("AppointmentDate must be in the future.");

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .WithMessage("StartTime is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .WithMessage("EndTime is required.");

            RuleFor(x => x)
                .Must(x => x.EndTime > x.StartTime)
                .WithMessage("EndTime must be greater than StartTime.");

        }
    }
}
