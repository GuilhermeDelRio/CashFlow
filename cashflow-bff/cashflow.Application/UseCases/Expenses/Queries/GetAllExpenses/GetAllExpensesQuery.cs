using cashflow.Application.Dtos;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesQuery : IRequest<List<ExpenseDto>>
{
}
