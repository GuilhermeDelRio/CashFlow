using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;

namespace cashflow.Persistence.Repositories;

public class ExpensesRepository : BaseRepository<Expense>, IExpensesRepository
{
    public ExpensesRepository(AppDbContext context) : base(context) { }
}
