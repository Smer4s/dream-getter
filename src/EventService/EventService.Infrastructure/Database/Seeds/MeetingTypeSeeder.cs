using Bogus;
using EventService.Domain.Entities;
using EventService.Infrastructure.Database.Seeds.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Database.Seeds;

internal class MeetingTypeSeeder(AppDbContext dbContext) : Seeder<MeetingType>(dbContext), ISeeder<MeetingType>
{
    public override async Task SeedAsync()
    {
        var meetingTypes = await _dbContext.MeetingTypes.ToListAsync();
        if (meetingTypes.Count >= MaxEntitiesCount)
        {
            return;
        }

        var delta = MaxEntitiesCount - meetingTypes.Count;

        var faker = new Faker<MeetingType>()
            .Rules((f, t) =>
            {
                t.Title = f.Lorem.Word();
            });

        await AddEntitiesAsync(faker, delta);
    }
}
