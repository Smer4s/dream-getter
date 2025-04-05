using DreamGetter.Shared.Abstractions.Seeds;
using Microsoft.EntityFrameworkCore;
namespace DreamGetter.Shared.Utils;

public class DatabaseMigrator
{
    public static async Task MigrateAsync(DbContext dbContext)
    {
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
    }

    public static async Task ApplySeeds(IEnumerable<ISeeder> seeders)
    {
        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync();
        }
    }
}
