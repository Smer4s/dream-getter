using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DreamGetter.Shared.Authentication;

public record AuthInjections(string Issuer, string Audience, string Key, int AccessTokenLifeTimeMinutes, int RefreshTokenLifeTimeDays)
{
    public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.ASCII.GetBytes(Key));
}
