using DreamGetter.Shared.Abstractions.Seeds;
using DreamGetter.Shared.Utils;
using UserService.API.Endpoints.User;
using UserService.Infrastructure.Database;

namespace UserService.API;

internal static class WebApplicationExtensions
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddUserEndpoints();
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
