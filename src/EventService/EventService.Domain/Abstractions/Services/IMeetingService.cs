using EventService.Domain.Entities;

namespace EventService.Domain.Abstractions.Services;

public interface IMeetingService
{
    Task<List<Meeting>> GetMeetings();
}
