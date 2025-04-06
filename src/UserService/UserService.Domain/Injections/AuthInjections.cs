using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserService.Domain.Injections;

internal record AuthInjections(string Issuer, string Audience, string Key, int AccessTokenLifeTimeMinutes, int RefreshTokenLifeTimeDays)
{
    public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.ASCII.GetBytes(Key));
}
