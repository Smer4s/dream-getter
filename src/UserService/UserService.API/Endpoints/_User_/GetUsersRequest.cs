using DreamGetter.Shared.Authentication;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using UserService.API.Endpoints._User_.Models;
using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints._User_;

internal class GetUsersRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    public static async Task<List<UserDto>> Request(IUserService userService, IMapper mapper)
    {
        var users = await userService.GetUsers();

        var mappedUsers = users.Select(mapper.Map<UserDto>).ToList();

        return mappedUsers;
    }
}

