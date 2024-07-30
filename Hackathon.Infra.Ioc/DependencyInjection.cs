using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            InjectorBootStrapper.Setup(services);
        }
    }
}
