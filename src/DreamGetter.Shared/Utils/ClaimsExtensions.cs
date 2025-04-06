using System.Security.Claims;

namespace DreamGetter.Shared.Utils;

public static class ClaimsExtensions
{
    public static bool TryGetUserId(this ClaimsPrincipal user, out Guid? userId)
    {
        var userIdString = user.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
        if (userIdString == null)
        {
            userId = null;
            return false;
        }

        userId = Guid.Parse(userIdString);

        return true;
    }
}
