using Bogus;
using DreamGetter.Shared.Abstractions.Seeds;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.Enums;

namespace UserService.Infrastructure.Database.Seeders;

internal class UserSeeder(AppDbContext dbContext)
    : Seeder<User>(dbContext), ISeeder<User>
{
    public override async Task SeedAsync()
    {
        var users = await dbContext.Users.ToListAsync();
        if (users.Count > MaxEntitiesCount)
        {
            return;
        }

        var delta = MaxEntitiesCount - users.Count;

        var faker = new Faker<User>()
            .Rules((f, u) =>
            {
                u.Name = f.Name.FirstName();
                u.Email = f.Random.Bool(0.75f) ? f.Internet.Email(firstName: u.Name, lastName: f.Name.LastName()) : null;
                u.PhoneNumber = f.Phone.PhoneNumber("+###(##)###-##-##");
                u.Role = f.Random.Bool(0.1f) ? Role.Admin : Role.Default;
            });

        await AddEntitiesAsync(faker, delta);
    }
}
