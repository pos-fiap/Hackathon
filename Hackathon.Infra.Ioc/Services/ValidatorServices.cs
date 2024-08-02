using FluentValidation;
using Hackathon.Application.DTOs;
using Hackathon.Application.Validator;
using Hackathon.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infra.Ioc.Services
{
    public static class ValidatorServices
    {
        public static void RegisterValidatorServices(IServiceCollection services)
        {
            services.AddScoped<IValidator<UserDto>, UserValidator>();
            services.AddScoped<IValidator<UserUpdateDto>, UserUpdateValidator>();
            services.AddScoped<IValidator<UserRoleDto>, UserRoleValidator>();
            services.AddScoped<IValidator<RoleDto>, RoleValidator>();
            services.AddScoped<IValidator<RoleUpdateDto>, RoleUpdateValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginValidator>();
            services.AddScoped<IValidator<PatientDto>, PatientValidator>();
            services.AddScoped<IValidator<DoctorDto>, DoctorValidator>();
        }
    }
}
