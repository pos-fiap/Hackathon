using FluentValidation;
using Hackathon.Application.DTOs;

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
                .WithMessage("StartTime is required.")
                .Must(x => x.Minutes == 0 && x.Seconds == 0)
                .WithMessage("StartTime must be a whole hour.");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .WithMessage("EndTime is required.")
                .Must(x => x.Minutes == 0 && x.Seconds == 0)
                .WithMessage("StartTime must be a whole hour.");

            RuleFor(x => x)
                .Must(x => x.EndTime > x.StartTime)
                .WithMessage("EndTime must be greater than StartTime.");

            RuleFor(x => x)
                .Must(x => x.EndTime - x.StartTime == TimeSpan.FromHours(1))
                .WithMessage("StartTime and EndTime must have a 1 hour of difference.");

        }
    }
}
