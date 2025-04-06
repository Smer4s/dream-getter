using Mapster;
using MapsterMapper;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_;

internal record UserDto : IMapFrom<User>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string? Email { get; init; }

    public ICollection<UserSlimDto> Subscribers { get; init; } = [];
    public ICollection<UserSlimDto> SubscribedOn { get; init; } = [];
}

internal record UserSlimDto : IMapFrom<User>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string? Email { get; init; }
}

internal class GetUsersRequest
{
    public static async Task<List<UserDto>> Request(IUserService userService, IMapper mapper)
    {
        var users = await userService.GetUsers();

        var mappedUsers = users.Select(mapper.Map<UserDto>).ToList();

        return mappedUsers;
    }
}

