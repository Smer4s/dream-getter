using Microsoft.AspNetCore.Authorization;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_;

public class GetUsersRequest
{
    [Authorize(Policy = "Default")]
    public static async Task<List<User>> Request( IUserService userService)
    {
        var users = await userService.GetUsers();

        return users;
    }
}

