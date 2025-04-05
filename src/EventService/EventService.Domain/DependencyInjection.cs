using EventService.Domain.Abstractions.Services;
using EventService.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddDomainServices();

        return services;
    }


    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IMeetingService, MeetingService>();

        return services;
    }

}
