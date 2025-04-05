using DreamGetter.Shared.Abstractions.Entities;
using UserService.Domain.Enums;

namespace UserService.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; }
    public Role Role { get; set; } = Role.Default;
}
