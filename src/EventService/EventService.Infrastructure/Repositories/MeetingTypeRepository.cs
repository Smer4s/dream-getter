using DreamGetter.Shared.Abstractions.Repositories;
using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Entities;
using EventService.Infrastructure.Database;

namespace EventService.Infrastructure.Repositories;

internal class MeetingTypeRepository(AppDbContext dbContext) : RepositoryBase<MeetingType>(dbContext), IMeetingTypeRepository;
