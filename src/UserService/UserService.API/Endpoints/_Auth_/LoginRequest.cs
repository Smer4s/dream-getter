
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Models;

namespace UserService.API.Endpoints._Auth_;

internal record LoginRequestModel
{
    public string Login { get; init; } = null!;
    public string Password { get; init; } = null!;
}

internal class LoginRequest
{
    internal static async Task<JwtTokenModel> Request(LoginRequestModel loginRequestModel, IAuthService authService)
    {
        var tokens = await authService.Login(loginRequestModel.Login, loginRequestModel.Password);

        return tokens;
    }
}