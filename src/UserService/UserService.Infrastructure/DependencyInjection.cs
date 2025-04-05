using DreamGetter.Shared.Abstractions.Repositories;
using DreamGetter.Shared.Abstractions.Seeds;
using DreamGetter.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Abstractions.Repositories;
using UserService.Infrastructure.Database;
using UserService.Infrastructure.Database.Seeders;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddDatabase()
            .AddRepositories()
            .AddSeeds();

        return services;
    }

    private static IServiceCollection AddSeeds(this IServiceCollection services)
    {
        services.AddScoped<ISeeder, UserSeeder>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<IUnitOfWork, AppDbContext>(builder => builder
            .UseSqlite(EnvFetcher.GetEnvVariable("CONNECTION_STRING")));

        return services;
    }
}
