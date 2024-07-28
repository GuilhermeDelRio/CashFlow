#nullable disable
using cashflow.Domain.Interfaces;
using cashflow.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace cashflow.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        _context.Add(entity);
    }

    public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
    }
}
