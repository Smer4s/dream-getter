using DreamGetter.Shared.Abstractions.Repositories;
using DreamGetter.Shared.Abstractions.Seeds;
using DreamGetter.Shared.Utils;
using EventService.Domain.Abstractions.Repositories;
using EventService.Infrastructure.Database;
using EventService.Infrastructure.Database.Seeds;
using EventService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.Infrastructure;

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
        services.AddScoped<ISeeder, MeetingTypeSeeder>();
        services.AddScoped<ISeeder, MeetingSeeder>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMeetingRepository, MeetingRepository>();
        services.AddScoped<IMeetingTypeRepository, MeetingTypeRepository>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<IUnitOfWork, AppDbContext>(builder => builder
            .UseSqlite(EnvFetcher.GetRequiredEnvVariable("CONNECTION_STRING")));

        return services;
    }
}
