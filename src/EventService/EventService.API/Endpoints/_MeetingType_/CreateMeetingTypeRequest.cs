
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.API.Endpoints._MeetingType_;

internal record CreateMeetingTypeModel
{
    public string Title { get; init; } = null!;
}

internal class CreateMeetingTypeRequest
{
    public static async Task Request(CreateMeetingTypeModel model, IMeetingTypeService meetingTypeService)
    {
        var meetingType = new MeetingType()
        {
            Title = model.Title,
        };

        await meetingTypeService.CreateMeetingType(meetingType);
    }
}