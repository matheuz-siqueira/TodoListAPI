using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Infra.Data;

namespace TodoList.Infra
{
    public static class Initialize
    {
        public static void AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            AddContext(services, configuration);
        }

        public static void AddContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)
                )
            );
        }


    }
}