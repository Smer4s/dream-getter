using DreamGetter.Shared.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;
using UserService.Domain.Models;

namespace UserService.Domain.Services._Auth_;

internal class TokenService(AuthInjections authInjections) : ITokenService
{
    public JwtTokenModel GenerateTokens(User user)
    {
        var identity = GetIdentity(user);

        var accessToken = GenerateAccessToken(identity);

        return new JwtTokenModel { AccessToken = accessToken };
    }

    private string GenerateAccessToken(ClaimsIdentity identity)
    {
        var jwt = new JwtSecurityToken(
                issuer: authInjections.Issuer,
                audience: authInjections.Audience,
                notBefore: DateTime.UtcNow,
                claims: identity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(authInjections.AccessTokenLifeTimeMinutes)),
                signingCredentials: new SigningCredentials(authInjections.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }

    private ClaimsIdentity GetIdentity(User user)
    {
        List<Claim> claims =
            [
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            ];

        var claimsIdentity = new ClaimsIdentity(
            claims: claims,
            authenticationType: "Token",
            nameType: ClaimsIdentity.DefaultNameClaimType,
            roleType: ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}
