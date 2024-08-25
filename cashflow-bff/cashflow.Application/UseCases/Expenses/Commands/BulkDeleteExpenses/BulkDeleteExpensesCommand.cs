#nullable disable
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.BulkDeleteExpenses;

public class BulkDeleteExpensesCommand : IRequest<Unit>
{
    public List<Guid> Ids { get; set; }
}
