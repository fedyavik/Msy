using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MSY.Database.Extension
{
    public static class DatabaseExtension
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbMSYContext>(options => options.UseNpgsql(
                configuration["DatabaseConnectionOptions:ConnectionString"]));
        }
    }
}