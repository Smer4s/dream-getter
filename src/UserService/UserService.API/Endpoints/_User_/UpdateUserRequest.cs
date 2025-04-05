using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints._User_;

internal record UpdateUserModel
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string? Email { get; init; }
}


internal class UpdateUserRequest
{
    internal static async Task Request(UpdateUserModel model, IUserService userService)
    {
        var user = new Domain.Entities.User()
        {
            Email = model.Email,
            Id = model.UserId,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber,
        };

        await userService.UpdateUser(user);
    }
}