using DreamGetter.Shared.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DreamGetter.Shared.Abstractions.Repositories;

public abstract class RepositoryBase<T>(DbContext dbContext)
    : IRepository<T>
    where T : Entity
{
    protected virtual Expression<Func<T, object?>>[] IncludeExpressions { get; } = [];
    protected readonly DbContext _dbContext = dbContext;

    public void Create(T entity) =>
        _dbContext.Set<T>().Add(entity);

    public void Delete(T entity) =>
        _dbContext.Set<T>().Remove(entity);

    public void Update(T entity) =>
        _dbContext.Set<T>().Update(entity);

    public virtual Task<List<T>> GetAll() =>
        WithIncludes().ToListAsync();

    public Task<T?> GetById(Guid entityId) =>
        WithIncludes().FirstOrDefaultAsync(x => x.Id == entityId);

    protected virtual IQueryable<T> WithIncludes()
    {
        var query = _dbContext.Set<T>().AsQueryable();

        foreach (var expression in IncludeExpressions)
        {
            query = query.Include(expression);
        }

        return query;
    }
}
