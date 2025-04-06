using DreamGetter.Shared.Authentication;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace EventService.API.Endpoints._Meeting_;

internal class GetMeetingsRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    public static Task<List<Meeting>> Request(IMeetingService meetingService)
        => meetingService.GetMeetings();
}
