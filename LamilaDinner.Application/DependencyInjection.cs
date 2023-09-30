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
        return services;
    }
}


