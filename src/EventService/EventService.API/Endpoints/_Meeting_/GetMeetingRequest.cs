using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Endpoints._Meeting_;

internal class GetMeetingRequest
{
    public static async Task<Meeting> Request([FromRoute] Guid meetingId, IMeetingService meetingService)
    {
        var meeting = await meetingService.GetMeetingById(meetingId);

        if (meeting == null)
        {
            throw new ArgumentException(nameof(meeting));
        }

        return meeting;
    }
}
