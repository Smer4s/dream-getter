using DreamGetter.Shared.Enums;
using DreamGetter.Shared.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DreamGetter.Shared.Authentication;

public static class AuthenticationInjector
{
    public static IServiceCollection AddDreamGetterAuthorization(this IServiceCollection services)
    {
        services.AddAuthInjections();

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

        services.AddDreamGetterAuthorizationBuilder();

        return services;
    }

    internal static IServiceCollection AddAuthInjections(this IServiceCollection services)
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


        return services;
    }

    internal static IServiceCollection AddDreamGetterAuthorizationBuilder(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(AuthPolicyConstants.DefaultPolicyName, policy =>
            {
                policy.RequireRole(Role.Default.ToString(), Role.Admin.ToString());
            })
            .AddPolicy(AuthPolicyConstants.AdminPolicyName, policy =>
            {
                policy.RequireRole(Role.Admin.ToString());
            });

        return services;
    }
}
