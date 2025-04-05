using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_;

public class GetUserRequest
{
    public static async Task<User> Request([FromRoute] Guid userId, IUserService userService)
    {
        var user = await userService.GetUserById(userId);

        return user ?? throw new ArgumentException();
    }
}
