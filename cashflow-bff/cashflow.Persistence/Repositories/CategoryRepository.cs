using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;

namespace cashflow.Persistence.Repositories;

public class CategoryRepository : BaseRepository<CategoryModel>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }
}
