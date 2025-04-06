using EventService.Domain.Abstractions.Services;

namespace EventService.Domain.Services;

internal class GrpcUserService(UserServiceGrpc.UserServiceGrpcClient grpcClient) : IGrpcUserService
{
    public async Task<UserGrpcDto> GetUser(Guid userId)
    {
        var request = new UserRequest() { UserId = userId.ToString() };

        var response = await grpcClient.GetUserWithSubscribersAsync(request);

        return response;
    }
}
