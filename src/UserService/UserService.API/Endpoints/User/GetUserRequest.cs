using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints.User;

public class GetUserRequest
{
    public static async Task<Domain.Entities.User> Request([FromRoute] Guid userId, IUserService userService)
    {
        var user = await userService.GetUserById(userId);

        return user ?? throw new ArgumentException();
    }
}
