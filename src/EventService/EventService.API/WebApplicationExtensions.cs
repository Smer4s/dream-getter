using DreamGetter.Shared.Abstractions.Seeds;
using DreamGetter.Shared.Utils;
using EventService.API.Endpoints._Meeting_;
using EventService.API.Endpoints._MeetingType_;
using EventService.Infrastructure.Database;

namespace EventService.API;

internal static class WebApplicationExtensions
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddMeetingEndpoints();
        app.AddMeetingTypeEndpoints();
    }
    public static void AddAuth(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
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
