
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.API.Endpoints._Meeting_;

internal record UpdateMeetingModel
{
    public Guid MeetingId { get; init; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime DateTime { get; init; }
    public Guid TypeId { get; init; }
}

internal class UpdateMeetingRequest
{
    internal static async Task Request(UpdateMeetingModel model, IMeetingService meetingService, IMeetingTypeService meetingTypeService)
    {
        var meetingType = await meetingTypeService.GetMeetingTypeById(model.TypeId);

        if (meetingType is null)
        {
            throw new ArgumentNullException(nameof(meetingType));
        }

        var meeting = new Meeting()
        {
            DateTime = model.DateTime,
            Description = model.Description,
            Title = model.Title,
            Id = model.MeetingId,
            Type = meetingType
        };

        await meetingService.UpdateMeeting(meeting);
    }
}
