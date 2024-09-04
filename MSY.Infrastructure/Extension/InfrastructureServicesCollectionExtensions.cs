using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MSY.Infrastructure.Extension
{
    public static class InfrastructureServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            return services;
        }
    }
}