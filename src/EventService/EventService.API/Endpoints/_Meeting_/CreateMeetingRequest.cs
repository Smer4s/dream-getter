
using DreamGetter.Shared.Authentication;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace EventService.API.Endpoints._Meeting_;

internal record CreateMeetingModel
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime DateTime { get; init; }
    public Guid TypeId { get; init; }
}

internal class CreateMeetingRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    public static async Task Request(CreateMeetingModel model, IMeetingService meetingService, IMeetingTypeService meetingTypeService)
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
            Type = meetingType
        };

        await meetingService.CreateMeeting(meeting);
    }
}