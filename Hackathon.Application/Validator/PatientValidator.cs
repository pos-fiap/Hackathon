﻿using FluentValidation;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Validator
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(p => p.PersonalInformations.CPF).NotNull().WithMessage("CPF is a required field");
        }
    }

    public class PostPatientValidator : AbstractValidator<PostPatientDto>
    {
        public PostPatientValidator()
        {
            RuleFor(p => p.PersonalInformations.CPF).NotNull().WithMessage("CPF is a required field");

        }
    }
}
