using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.DTOs.User;
using TodoList.Application.Interfaces;
using TodoList.Application.Services.Authentication;
using TodoList.Application.Services.User;
using TodoList.Application.Validations;
using TodoList.Application.Services.BaseServices;
using TodoList.Application.DTOs.Task;

namespace TodoList.Application;
public static class Initialize
{
    public static void AddApplication(this IServiceCollection services,
    IConfiguration configuration)
    {
        AddServices(services);
        AddValidators(services);
        AddAuthentication(services, configuration);
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserLogged, UserLogged>();

    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserRequestJson>, RegisterUserValidator>();
        services.AddScoped<IValidator<AuthenticationRequestJson>, AuthenticationValidator>();
        services.AddScoped<IValidator<UpdatePasswordRequestJson>, UpdatePasswordValidator>();
        services.AddScoped<IValidator<RegisterTaskRequestJson>, RegisterTaskValidator>();
    }

    public static void AddAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        var JWTKey = Encoding.ASCII.GetBytes(configuration["JWTKey"]);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(JWTKey),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}
