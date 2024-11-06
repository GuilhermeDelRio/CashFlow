using cashflow.Application.Dtos;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetExpensesById;

public class GetExpenseByIdQuery : IRequest<ExpenseDto>
{
    public Guid Id { get; set; }
}
