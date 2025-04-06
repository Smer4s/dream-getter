using DreamGetter.Shared.Abstractions.Repositories;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Entities;

namespace UserService.Domain.Services._User_;

internal class UserService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher)
    : IUserService
{
    public Task CreateUser(User user)
    {
        userRepository.Create(user);

        return unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteUserById(Guid userId)
    {
        var user = await GetUserById(userId) ?? throw new ArgumentNullException(nameof(userId));
        userRepository.Delete(user);

        await unitOfWork.SaveChangesAsync();
    }

    public Task<User?> GetUserById(Guid userId)
    {
        return userRepository.GetById(userId);
    }

    public Task<User?> GetUserByPhoneAndPassword(string phoneNumber, string password)
    {
        var passwordHash = passwordHasher.HashPassword(password);

        return userRepository.GetUserByPhoneAndPassword(phoneNumber, passwordHash);
    }

    public Task<List<User>> GetUsers()
    {
        return userRepository.GetAll();
    }

    public Task UpdateUser(User user)
    {
        userRepository.Update(user);

        return unitOfWork.SaveChangesAsync();
    }
}
