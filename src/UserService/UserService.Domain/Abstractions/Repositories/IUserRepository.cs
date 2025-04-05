using DreamGetter.Shared.Abstractions.Repositories;
using UserService.Domain.Entities;

namespace UserService.Domain.Abstractions.Repositories;

public interface IUserRepository : IRepository<User>;