using UserService.Domain.Entities;
using UserService.Domain.Models;

namespace UserService.Domain.Abstractions.Services;

internal interface ITokenService
{
    JwtTokenModel GenerateTokens(User user);
}
