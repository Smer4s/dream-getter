namespace UserService.API.Endpoints._Auth_;

internal static class AuthEndpointsInjector
{
    public static void AddAuthEndpoints(this WebApplication app)
    {
        var authGroup = app.MapGroup("/auth").WithTags("Auth");

        authGroup.MapPost("/login", LoginRequest.Request);
    }
}
