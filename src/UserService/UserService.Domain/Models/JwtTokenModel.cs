namespace UserService.Domain.Models;

public record JwtTokenModel
{
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
}
