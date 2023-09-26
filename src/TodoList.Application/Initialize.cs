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
using TodoList.Application.Services.Task;
using HashidsNet;
using TodoList.Application.Mapper;
using TodoList.Application.Services.Note;
using TodoList.Application.DTOs.Note;
using TodoList.Application.Services.Dashboard;
using TodoList.Application.Services.Record;

namespace TodoList.Application;
public static class Initialize
{
    public static void AddApplication(this IServiceCollection services,
    IConfiguration configuration)
    {
        AddServices(services);
        AddValidators(services);
        AddAuthentication(services, configuration);
        AddHashids(services, configuration);
        AddAutoMapper(services);
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserLogged, UserLogged>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IHashidsService, HashidsService>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IRecordService, RecordService>();
    }
    public static void AddHashids(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IHashids>(_ =>
            new Hashids(configuration.GetValue<string>("HashIds:Salt"), 3)
        );
    }
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile(provider.GetService<IHashids>()));
        }).CreateMapper());
    }
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserRequestJson>, RegisterUserValidator>();
        services.AddScoped<IValidator<AuthenticationRequestJson>, AuthenticationValidator>();
        services.AddScoped<IValidator<UpdatePasswordRequestJson>, UpdatePasswordValidator>();
        services.AddScoped<IValidator<RegisterTaskRequestJson>, RegisterTaskValidator>();
        services.AddScoped<IValidator<UpdateTaskRequestJson>, UpdateTaskValidator>();
        services.AddScoped<IValidator<RegisterNoteRequestJson>, RegisterNoteValidator>();
        services.AddScoped<IValidator<UpdateNoteRequestJson>, UpdateNoteValidator>();
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
