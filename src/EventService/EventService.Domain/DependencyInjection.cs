using DreamGetter.Shared.Authentication;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddGrpcClient<UserServiceGrpc.UserServiceGrpcClient>(options =>
        {
            options.Address = new Uri("https://localhost:7176");
        });

        services.AddScoped<IGrpcUserService, GrpcUserService>();

        services.AddDomainServices();

        services.AddDreamGetterAuthorization();

        return services;
    }


    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IMeetingService, MeetingService>();
        services.AddScoped<IMeetingTypeService, MeetingTypeService>();

        return services;
    }

}
