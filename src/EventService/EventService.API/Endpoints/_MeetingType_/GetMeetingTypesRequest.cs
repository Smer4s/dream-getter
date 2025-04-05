using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.API.Endpoints._MeetingType_;

internal class GetMeetingTypesRequest
{
    public static Task<List<MeetingType>> Request(IMeetingTypeService meetingTypeService)
        => meetingTypeService.GetMeetingTypes();
}
