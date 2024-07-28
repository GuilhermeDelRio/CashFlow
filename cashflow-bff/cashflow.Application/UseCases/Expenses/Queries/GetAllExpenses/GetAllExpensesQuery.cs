using cashflow.Application.UseCases.Expenses.Reponses;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesQuery : IRequest<List<ExpenseResponse>>
{
}
