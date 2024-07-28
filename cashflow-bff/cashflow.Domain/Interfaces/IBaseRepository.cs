using cashflow.Domain.Common;

namespace cashflow.Domain.Interfaces;

public interface IBaseRepository<T> where T : AuditableEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
