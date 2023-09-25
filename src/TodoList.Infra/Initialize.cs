using TodoList.Domain.Interfaces;
using TodoList.Infra.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Infra.Data;
using TodoList.Infra.Repositories.Task;
using TodoList.Infra.Repositories.Note;
using TodoList.Infra.Repositories.Dashboard;

namespace TodoList.Infra
{
    public static class Initialize
    {
        public static void AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            AddContext(services, configuration);
            AddRepositories(services);
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

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
        }

    }
}