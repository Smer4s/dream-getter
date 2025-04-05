using DreamGetter.Shared.Abstractions.Seeds;
using DreamGetter.Shared.Utils;
using EventService.API.Endpoints;
using EventService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.API;

internal static class WebApplicationExtensions
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddMeetingEndpoints();
    }

    public static async Task ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await DatabaseMigrator.MigrateAsync(dbContext);

        var seeders = scope.ServiceProvider.GetServices<ISeeder>();
        await DatabaseMigrator.ApplySeeds(seeders);
    }
}
