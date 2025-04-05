using UserService.Domain.Abstractions.Services;

namespace UserService.API.Endpoints._User_;

public record CreateUserModel
{
    public string Name { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string? Email { get; init; }
}

public class CreateUserRequest
{

    public static async Task<Domain.Entities.User> Request(CreateUserModel model, IUserService userService)
    {
        var user = new Domain.Entities.User()
        {
            Name = model.Name,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        await userService.CreateUser(user);

        return user;
    }
}
