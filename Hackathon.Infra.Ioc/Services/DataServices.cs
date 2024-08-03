using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data;
using Hackathon.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infra.Ioc.Services
{
    public static class DataServices
    {
        public static void RegisterDataServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleAccessRepository, RoleAccessRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDefaultAvailabilityRepository, DefaultAvailabilityRepository>();
            services.AddScoped<ISpecificAvailabilityRepository, SpecificAvailabilityRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
