﻿using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints.User;

public class GetUsersRequest
{
    public static async Task<List<Domain.Entities.User>> Request(IUserService userService)
    {
        var users = await userService.GetUsers();

        return users;
    }
}

