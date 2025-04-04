using EventService.API.Endpoints;
using EventService.Infrastructure.Database;
using EventService.Infrastructure.Database.Seeds.Abstractions;
using Microsoft.EntityFrameworkCore;

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

        using var transaction = await dbContext.Database.BeginTransactionAsync();
        try
        {
            await dbContext.Database.MigrateAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
        }

        await ApplySeeds(scope.ServiceProvider);
    }

    private static async Task ApplySeeds(IServiceProvider serviceProvider)
    {
        var seeders = serviceProvider.GetServices<ISeeder>();

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync();
        }
    }
}
