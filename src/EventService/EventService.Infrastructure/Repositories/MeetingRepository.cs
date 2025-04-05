using DreamGetter.Shared.Abstractions.Repositories;
using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Entities;
using EventService.Infrastructure.Database;
using System.Linq.Expressions;

namespace EventService.Infrastructure.Repositories;

internal class MeetingRepository(AppDbContext dbContext) : RepositoryBase<Meeting>(dbContext), IMeetingRepository
{
    protected override Expression<Func<Meeting, object?>>[] IncludeExpressions => [x => x.Type];
}
