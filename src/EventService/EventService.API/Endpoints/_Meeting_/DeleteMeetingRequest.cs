
using EventService.Domain.Abstractions.Services;

namespace EventService.API.Endpoints._Meeting_;

internal class DeleteMeetingRequest
{
    internal static async Task Request(Guid meetingId, IMeetingService meetingService)
    {
        await meetingService.DeleteMeetingById(meetingId);
    }
}