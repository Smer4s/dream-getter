using Bogus;
using DreamGetter.Shared.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamGetter.Shared.Abstractions.Seeds;

public abstract class Seeder<T>(DbContext dbContext)
    : ISeeder<T>
    where T : Entity
{
    protected virtual int MaxEntitiesCount { get; } = 15;
    protected readonly DbContext _dbContext = dbContext;

    public abstract Task SeedAsync();

    protected async Task AddEntitiesAsync(Faker<T> faker, int count)
    {
        var entities = faker.Generate(count);

        await _dbContext.Set<T>().AddRangeAsync(entities);

        await _dbContext.SaveChangesAsync();
    }
}
