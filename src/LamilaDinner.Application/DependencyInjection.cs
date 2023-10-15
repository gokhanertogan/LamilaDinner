using System.Reflection;
using ErrorOr;
using FluentValidation;
using LamilaDinner.Application.Common.Behaviors;
using LamilaDinner.Application.Services.Authentication.Commands.Register;
using LamilaDinner.Application.Services.Authentication.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LamilaDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<IAuthenticationService, AuthenticationService>();
        // services.AddScoped<IAuthenticationCommandService,AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService,AuthenticationQueryService>();
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();     
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}


