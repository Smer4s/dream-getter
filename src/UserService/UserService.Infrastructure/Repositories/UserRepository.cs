using DreamGetter.Shared.Abstractions.Repositories;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Entities;
using UserService.Infrastructure.Database;

namespace UserService.Infrastructure.Repositories;

internal class UserRepository(AppDbContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
{
}
