using DreamGetter.Shared.Abstractions.Entities;

namespace DreamGetter.Shared.Abstractions.Seeds;

public interface ISeeder
{
    Task SeedAsync();
}

public interface ISeeder<T>
    : ISeeder
    where T : Entity;