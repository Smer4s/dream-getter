using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Entities.Abstractions;
using EventService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Repositories.Abstractions;

internal abstract class RepositoryBase<T>(AppDbContext dbContext)
    : IRepository<T>
    where T : Entity
{
    protected readonly AppDbContext _dbContext = dbContext;

    public void Create(T entity) =>
        _dbContext.Set<T>().Add(entity);

    public void Delete(T entity) =>
        _dbContext.Set<T>().Remove(entity);

    public void Update(T entity) =>
        _dbContext.Set<T>().Update(entity);

    public virtual Task<List<T>> GetAll() =>
        _dbContext.Set<T>().ToListAsync();

    public T? GetById(Guid entityId) =>
        _dbContext.Set<T>().FirstOrDefault(x => x.Id == entityId);

}
