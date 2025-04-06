using UserService.Domain.Abstractions.Services;
using UserService.Domain.Models;

namespace UserService.Domain.Services._Auth_;

internal class AuthService(ITokenService tokenService, IUserService userService) : IAuthService
{
    public async Task<JwtTokenModel> Login(string phoneNumber, string password)
    {
        var user = await userService.GetUserByPhoneAndPassword(phoneNumber, password);
        if (user == null)
        {
            throw new ArgumentException(nameof(user));
        }

        return tokenService.GenerateTokens(user);
    }

    public Task<JwtTokenModel> Refresh(string phoneNumber, string password)
    {
        throw new NotImplementedException();
    }
}
