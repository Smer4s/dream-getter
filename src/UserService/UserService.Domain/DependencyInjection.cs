using DreamGetter.Shared.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Injections;
using UserService.Domain.Services._Auth_;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UserService.Domain.Enums;

namespace UserService.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddAuth();

        services.AddScoped<IUserService, Services._User_.UserService>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddScoped<AuthInjections>(x =>
        {
            var Issuer = EnvFetcher.GetRequiredEnvVariable("ISSUER");
            var Audience = EnvFetcher.GetRequiredEnvVariable("AUDIENCE");
            var Key = EnvFetcher.GetRequiredEnvVariable("KEY");
            var AccessTokenLifeTimeMinutes = EnvFetcher.GetRequiredEnvVariable("ACCESS_TOKEN_LIFETIME_MINUTES", Convert.ToInt32);
            var RefreshTokenLifeTimeDays = EnvFetcher.GetRequiredEnvVariable("REFRESH_TOKEN_LIFETIME_DAYS", Convert.ToInt32);


            return new AuthInjections(Issuer, Audience, Key, AccessTokenLifeTimeMinutes, RefreshTokenLifeTimeDays);
        });

        var serviceProvider = services.BuildServiceProvider();
        var authInjections = serviceProvider.GetRequiredService<AuthInjections>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = authInjections.Issuer,
                            ValidateAudience = true,
                            ValidAudience = authInjections.Audience,
                            ValidateLifetime = true,
                            IssuerSigningKey = authInjections.SymmetricSecurityKey,
                            ValidateIssuerSigningKey = true,
                        };
                    });

        services.AddAuthorizationBuilder()
            .AddPolicy("Default", policy =>
            {
                policy.RequireRole(Role.Default.ToString(), Role.Admin.ToString());
            })
            .AddPolicy("Admin", policy =>
            {
                policy.RequireRole(Role.Admin.ToString());
            });

        services.AddScoped<IAuthService, AuthService>();
        services.AddSingleton<SHA256>(x => SHA256.Create());
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
