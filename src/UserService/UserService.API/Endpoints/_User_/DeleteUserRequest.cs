using DreamGetter.Shared.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints._User_;

internal class DeleteUserRequest
{
    [Authorize(Policy = AuthPolicyConstants.AdminPolicyName)]
    internal static Task Request([FromRoute] Guid userId, IUserService userService)
    {
        return userService.DeleteUserById(userId);
    }
}