using EventService.Domain.Entities.Abstractions;

namespace EventService.Domain.Abstractions.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<List<T>> GetAll();
    T? GetById(Guid entityId);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
