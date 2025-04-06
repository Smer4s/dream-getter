using DreamGetter.Shared.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Entities;
using UserService.Infrastructure.Database;

namespace UserService.Infrastructure.Repositories;

internal class UserRepository(AppDbContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
{
    public Task<User?> GetUserByPhoneAndPassword(string phone, string password)
        => dbContext.Users
            .Where(x => x.PhoneNumber == phone && password == x.Password)
            .FirstOrDefaultAsync();
}
