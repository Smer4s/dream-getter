using DreamGetter.Shared.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Entities;
using UserService.Infrastructure.Database;

namespace UserService.Infrastructure.Repositories;

internal class UserRepository(AppDbContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
{
    protected override Expression<Func<User, object?>>[] IncludeExpressions => [x=>x.SubscribedOn, x=>x.Subscribers];

    public Task<User?> GetUserByPhoneAndPassword(string phone, string password)
        => dbContext.Users
            .Where(x => x.PhoneNumber == phone && password == x.Password)
            .FirstOrDefaultAsync();
}
