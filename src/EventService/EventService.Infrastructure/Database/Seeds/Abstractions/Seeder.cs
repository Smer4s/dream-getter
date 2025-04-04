using Bogus;
using EventService.Domain.Entities.Abstractions;

namespace EventService.Infrastructure.Database.Seeds.Abstractions;

internal abstract class Seeder<T>(AppDbContext dbContext)
    : ISeeder<T>
    where T : Entity
{
    protected virtual int MaxEntitiesCount { get; } = 15;
    protected readonly AppDbContext _dbContext = dbContext;

    public abstract Task SeedAsync();

    protected async Task AddEntitiesAsync(Faker<T> faker, int count)
    {
        var entities = faker.Generate(count);

        await _dbContext.Set<T>().AddRangeAsync(entities);

        await _dbContext.SaveChangesAsync();
    }
}
