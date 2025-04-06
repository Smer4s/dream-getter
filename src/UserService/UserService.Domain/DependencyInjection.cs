using DreamGetter.Shared.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Services._Auth_;
using DreamGetter.Shared.Authentication;
using UserService.Domain.Services._Subscription_;

namespace UserService.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddAuth();
        services.AddGrpc();

        services.AddScoped<IUserService, Services._User_.UserService>();
        services.AddScoped<ISubscriptionService, SubscriptionService>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddDreamGetterAuthorization();

        services.AddScoped<IAuthService, AuthService>();
        services.AddSingleton<SHA256>(x => SHA256.Create());
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
