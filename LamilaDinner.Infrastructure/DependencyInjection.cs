using LamilaDinner.Application.Common.Interfaces.Authentication;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Application.Common.Interfaces.Services;
using LamilaDinner.Infrastructure.Authentication;
using LamilaDinner.Infrastructure.Persistence;
using LamilaDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LamilaDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}


