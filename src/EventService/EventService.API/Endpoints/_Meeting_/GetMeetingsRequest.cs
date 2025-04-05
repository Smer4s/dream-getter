using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.API.Endpoints._Meeting_;

internal class GetMeetingsRequest
{
    public static Task<List<Meeting>> Request(IMeetingService meetingService)
        => meetingService.GetMeetings();
}
