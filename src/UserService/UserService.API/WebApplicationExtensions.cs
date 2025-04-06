using DreamGetter.Shared.Abstractions.Seeds;
using DreamGetter.Shared.Utils;
using UserService.API.Endpoints._Auth_;
using UserService.API.Endpoints._User_;
using UserService.Domain.Services;
using UserService.Domain.Services.Grpc;
using UserService.Infrastructure.Database;

namespace UserService.API;

internal static class WebApplicationExtensions
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddUserEndpoints();
        app.AddAuthEndpoints();
    }
    
    public static void AddGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<UserGrpcService>();
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
