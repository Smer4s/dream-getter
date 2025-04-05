using EventService.Domain.Entities;

namespace EventService.Domain.Abstractions.Services;

public interface IMeetingService
{
    Task<List<Meeting>> GetMeetings();
    Task<Meeting?> GetMeetingById(Guid meetingId);
    Task CreateMeeting(Meeting meeting);
    Task UpdateMeeting(Meeting meeting);
    Task DeleteMeetingById(Guid meetingId);
}
