using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Entities;

namespace UserService.Domain.Services.Grpc;


public class UserGrpcService(IUserRepository userRepository) : UserServiceGrpc.UserServiceGrpcBase
{
    public override async Task<UserGrpcDto> GetUserWithSubscribers(UserRequest request, ServerCallContext context)
    {
        var user = await userRepository.GetById(Guid.Parse(request.UserId)) ?? throw new ArgumentException();


        var userDto = new UserGrpcDto
        {
            Email = user.Email,
            Id = user.Id.ToString(),
            Name = user.Name,
            PhoneNumber = user.PhoneNumber
        };

        userDto.SubscribedOn.AddRange(user.SubscribedOn.Select(SlimMapper));
        userDto.Subscribers.AddRange(user.Subscribers.Select(SlimMapper));

        return userDto;
    }

    private static UserSlimGrpcDto SlimMapper(User user)
    {
        return new UserSlimGrpcDto
        {
            Id = user.Id.ToString(),
            Email = user.Email ?? "example@mail.com",
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
        };
    }
}
