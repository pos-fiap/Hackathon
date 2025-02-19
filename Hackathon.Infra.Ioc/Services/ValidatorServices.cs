﻿using FluentValidation;
using Hackathon.Application.DTOs;
using Hackathon.Application.Validator;
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
            services.AddScoped<IValidator<PersonDTO>, PersonValidator>();
            services.AddScoped<IValidator<PersonUpdateDTO>, PersonUpdateValidator>();
        }
    }
}
