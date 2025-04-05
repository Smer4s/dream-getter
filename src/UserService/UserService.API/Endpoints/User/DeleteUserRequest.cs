
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints.User;

internal class DeleteUserRequest
{
    internal static Task Request([FromRoute] Guid userId, IUserService userService)
    {
        return userService.DeleteUserById(userId);
    }
}