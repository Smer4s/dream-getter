using DreamGetter.Shared.Abstractions.Entities;

namespace DreamGetter.Shared.Abstractions.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<List<T>> GetAll();
    Task<T?> GetById(Guid entityId);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
