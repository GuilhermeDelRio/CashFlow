using cashflow.Application.UseCases.Expenses.Reponses;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetExpensesById;

public class GetExpenseByIdQuery : IRequest<ExpenseResponse>
{
    public Guid Id { get; set; }
}
