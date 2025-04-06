using DreamGetter.Shared.WebInjections;
using Mapster;

namespace UserService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddDreamGetterSwagger();
        services.AddMapster();


        return services;
    }
}
