using EventService.Domain.Entities.Abstractions;

namespace EventService.Infrastructure.Database.Seeds.Abstractions;

public interface ISeeder
{
    Task SeedAsync();
}

internal interface ISeeder<T> : ISeeder where T : Entity;