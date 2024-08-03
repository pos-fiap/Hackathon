using Hackathon.Application.Interfaces;
using Hackathon.Application.Services;
using Hackathon.Infra.Messaging.Interfaces;
using Hackathon.Infra.Messaging.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infra.Ioc.Services
{
    public static class AppServices
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleAccessService, RoleAccessService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IMessaging, MessagingService>();
            services.AddScoped<IEmailService, EmailService>();

        }
    }
}
