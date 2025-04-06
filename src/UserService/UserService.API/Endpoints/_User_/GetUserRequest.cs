using DreamGetter.Shared.Authentication;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Endpoints._User_.Models;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_;

internal class GetUserRequest
{
    [Authorize(Policy = AuthPolicyConstants.DefaultPolicyName)]
    public static async Task<UserDto> Request([FromRoute] Guid userId, IUserService userService, IMapper mapper)
    {
        var user = await userService.GetUserById(userId) ?? throw new ArgumentException();

        return mapper.Map<UserDto>(user);
    }
}
