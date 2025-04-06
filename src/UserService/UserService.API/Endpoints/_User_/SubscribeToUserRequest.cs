using DreamGetter.Shared.Authentication;
using DreamGetter.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints._User_;

internal record SubscribeToUserModel
{
    public Guid UserToSubscribeId { get; init; }
}

internal class SubscribeToUserRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    public static async Task Request(SubscribeToUserModel model, ISubscriptionService userService, HttpContext httpContext)
    {
        if (!httpContext.User.TryGetUserId(out var subscriberId))
        {
            throw new ArgumentException();
        }

        await userService.AddSubscription(subscriberId!.Value, model.UserToSubscribeId);
    }
}
