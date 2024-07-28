using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;

namespace cashflow.Persistence.Repositories;

public class ExpensesRepository : BaseRepository<Expenses>, IExpensesRepository
{
    public ExpensesRepository(AppDbContext context) : base(context) { }
}
