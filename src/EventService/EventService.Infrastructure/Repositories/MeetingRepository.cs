using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Entities;
using EventService.Infrastructure.Database;
using EventService.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Repositories;

internal class MeetingRepository(AppDbContext dbContext) : RepositoryBase<Meeting>(dbContext), IMeetingRepository
{
    public override async Task<List<Meeting>> GetAll()
    {
        var meetings = await _dbContext.Meetings.Include(x => x.Type).ToListAsync();

        return meetings;
    }
}
