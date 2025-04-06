using DreamGetter.Shared.WebInjections;

namespace EventService.API;

internal static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddDreamGetterSwagger();

        return services;
    }
}

