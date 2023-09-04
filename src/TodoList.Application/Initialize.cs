using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.DTOs.User;
using TodoList.Application.Interfaces;
using TodoList.Application.Services.User;
using TodoList.Application.Validations;

namespace TodoList.Application;
public static class Initialize
{
    public static void AddApplication(this IServiceCollection services,
    IConfiguration configuration)
    {
        AddServices(services);
        AddValidators(services);
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserRequestJson>, RegisterUserValidator>();
    }
}
