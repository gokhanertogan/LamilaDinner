using LamilaDinner.Api.Common.Errors;
using LamilaDinner.Api.Common.Mapping;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace LamilaDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddControllers();
        //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        services.AddSingleton<ProblemDetailsFactory, LamilaDinnerProblemDetailsFactory>();
        return services;
    }
}


