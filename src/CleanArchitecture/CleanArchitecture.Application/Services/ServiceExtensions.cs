using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using CleanArchitecture.Application.Shared.Behavior;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services.Token;

namespace CleanArchitecture.Application.Services;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<ITokenService, TokenService>();
    }
}
