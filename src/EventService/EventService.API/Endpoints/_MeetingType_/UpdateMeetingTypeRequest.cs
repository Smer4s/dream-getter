
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.API.Endpoints._MeetingType_;

internal record UpdateMeetingTypeModel
{
    public Guid MeetingTypeId { get; init; }
    public string Title { get; init; } = null!;
}

internal class UpdateMeetingTypeRequest
{
    internal static async Task Request(UpdateMeetingTypeModel model, IMeetingTypeService meetingTypeService)
    {
        var meetingType = new MeetingType()
        {
            Id = model.MeetingTypeId,
            Title = model.Title,
        };

        await meetingTypeService.UpdateMeetingType(meetingType);
    }
}
