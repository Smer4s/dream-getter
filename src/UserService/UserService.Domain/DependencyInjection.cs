using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Abstractions.Services;

namespace UserService.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {

        services.AddScoped<IUserService, Services.UserService>();

        return services;
    }
}
