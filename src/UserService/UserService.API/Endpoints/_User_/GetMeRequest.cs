
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_;

internal class GetMeRequest
{
    [Authorize]
    internal static Task<User> Request(IUserService userService, HttpContext httpContext)
    {
        var userIdString = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;

        if (userIdString == null)
        {
            throw new ArgumentNullException(nameof(userIdString));
        }

        var userId = Guid.Parse(userIdString);

        return userService.GetUserById(userId)!;
    }
}