
using DreamGetter.Shared.Authentication;
using DreamGetter.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_;

internal class GetMeRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    internal static Task<User> Request(IUserService userService, HttpContext httpContext)
    {
        if (!httpContext.User.TryGetUserId(out var userId))
        {
            throw new ArgumentNullException(nameof(userId));
        }

        return userService.GetUserById(userId!.Value)!;
    }
}