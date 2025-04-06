
using DreamGetter.Shared.Authentication;
using DreamGetter.Shared.Utils;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using UserService.API.Endpoints._User_.Models;
using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints._User_;

internal class GetMeRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    internal static async Task<UserDto> Request(IUserService userService, HttpContext httpContext, IMapper mapper)
    {
        if (!httpContext.User.TryGetUserId(out var userId))
        {
            throw new ArgumentNullException(nameof(userId));
        }

        var user = await userService.GetUserById(userId!.Value) ?? throw new ArgumentException();

        return mapper.Map<UserDto>(user);
    }
}