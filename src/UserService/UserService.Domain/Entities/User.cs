using DreamGetter.Shared.Abstractions.Entities;
using DreamGetter.Shared.Enums;

namespace UserService.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; }
    public string Password { get; set; } = null!;
    public string? JwtRefresh { get; set; }
    public Role Role { get; set; } = Role.Default;

    public ICollection<User> Subscribers { get; set; } = [];
    public ICollection<User> SubscribedOn { get; set; } = [];
}
