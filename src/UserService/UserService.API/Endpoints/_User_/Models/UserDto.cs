using Mapster;
using UserService.Domain.Entities;

namespace UserService.API.Endpoints._User_.Models;

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
