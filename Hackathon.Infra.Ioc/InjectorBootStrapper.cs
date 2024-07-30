using Hackathon.Infra.Ioc.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infra.Ioc
{
    public static class InjectorBootStrapper
    {
        public static void Setup(IServiceCollection services)
        {
            AppServices.RegisterAppServices(services);
            DataServices.RegisterDataServices(services);
            ValidatorServices.RegisterValidatorServices(services);
            AutoMapperServices.RegisterAutoMapperServices(services);
        }

    }
}
