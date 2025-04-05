using Bogus;
using EventService.Domain.Entities;
using EventService.Infrastructure.Database.Seeds.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure.Database.Seeds
{
    internal class MeetingSeeder(AppDbContext dbContext) : Seeder<Meeting>(dbContext), ISeeder<Meeting>
    {
        public override async Task SeedAsync()
        {
            var meetings = await _dbContext.Meetings.ToListAsync();
            if (meetings.Count >= MaxEntitiesCount)
            {
                return;
            }

            var meetingTypes = await _dbContext.MeetingTypes.ToListAsync();
            if (meetingTypes.Count is 0)
            {
                throw new ArgumentException(nameof(meetingTypes));
            }

            var delta = MaxEntitiesCount - meetings.Count;

            var faker = new Faker<Meeting>()
                .Rules((f, m) =>
                {
                    m.Title = f.Lorem.Sentence();
                    m.Description = f.Lorem.Text();
                    m.Type = f.PickRandom(meetingTypes);
                    m.DateTime = f.Date.Future(refDate: DateTime.UtcNow);
                });

            await AddEntitiesAsync(faker, delta);
        }
    }
}
