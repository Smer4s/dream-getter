namespace UserService.API.Endpoints.User;
internal static class UserEndpointsInjector
{
    public static void AddUserEndpoints(this WebApplication app)
    {
        var usersGroup = app.MapGroup("/user").WithTags("Users");

        usersGroup.MapGet("/users", GetUsersRequest.Request);
        usersGroup.MapGet("/{userId:guid}", GetUserRequest.Request);
        usersGroup.MapPost("/", CreateUserRequest.Request);
        usersGroup.MapPut("/", UpdateUserRequest.Request);
        usersGroup.MapDelete("/{userId:guid}", DeleteUserRequest.Request);
    }
}

