
using EventService.Domain.Abstractions.Services;

namespace EventService.API.Endpoints._MeetingType_;

internal class DeleteMeetingTypeRequest
{
    internal static async Task Request(Guid meetingTypeId, IMeetingTypeService meetingTypeService)
    {
        await meetingTypeService.DeleteMeetingTypeById(meetingTypeId);
    }
}