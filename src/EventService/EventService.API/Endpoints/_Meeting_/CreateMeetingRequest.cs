using DreamGetter.Shared.Authentication;
using DreamGetter.Shared.Models;
using DreamGetter.Shared.Utils;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;
using MassTransit;
using MassTransit.Transports;
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
    public static async Task Request(
        CreateMeetingModel model,
        HttpContext httpContext,
        IMeetingService meetingService,
        IMeetingTypeService meetingTypeService,
        IGrpcUserService grpcUserService,
        IPublishEndpoint publishEndpoint)
    {
        if (!httpContext.User.TryGetUserId(out var userId))
        {
            throw new ArgumentException();
        }

        var user = await grpcUserService.GetUser(userId!.Value);

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
            Type = meetingType,
            IssuerId = Guid.Parse(user.Id)
        };

        await meetingService.CreateMeeting(meeting);

        foreach (var subscriber in user.Subscribers)
        {
            var notification = new UserNotification
            {
                SubscriberId = Guid.Parse(subscriber.Id),
                EventId = meeting.Id,
                Message = $"User {user.Name} has created a new meeting: {meeting.Title}"
            };

            await publishEndpoint.Publish(notification);
        }
    }
}