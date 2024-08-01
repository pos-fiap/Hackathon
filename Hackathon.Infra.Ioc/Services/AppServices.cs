using Hackathon.Application.Interfaces;
using Hackathon.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infra.Ioc.Services
{
    public static class AppServices
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            //services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleAccessService, RoleAccessService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
