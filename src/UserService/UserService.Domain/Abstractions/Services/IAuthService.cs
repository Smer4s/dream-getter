using UserService.Domain.Models;

namespace UserService.Domain.Abstractions.Services;

public interface IAuthService
{
    Task<JwtTokenModel> Login(string phoneNumber, string password);
    Task<JwtTokenModel> Refresh(string phoneNumber, string password);
}
