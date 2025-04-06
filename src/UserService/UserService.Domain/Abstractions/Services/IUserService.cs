using UserService.Domain.Entities;

namespace UserService.Domain.Abstractions.Services;

public interface IUserService
{
    Task<User?> GetUserById(Guid userId);
    Task<User?> GetUserByPhoneAndPassword(string phoneNumber, string password);
    Task<List<User>> GetUsers();
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUserById(Guid userId);
}
