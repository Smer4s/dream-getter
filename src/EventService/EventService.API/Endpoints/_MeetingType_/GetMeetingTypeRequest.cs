using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Endpoints._MeetingType_;

internal class GetMeetingTypeRequest
{
    public static async Task<MeetingType> Request([FromRoute] Guid meetingTypeId, IMeetingTypeService meetingService)
    {
        var meetingType = await meetingService.GetMeetingTypeById(meetingTypeId);

        if (meetingType == null)
        {
            throw new ArgumentException(nameof(meetingType));
        }

        return meetingType;
    }
}
