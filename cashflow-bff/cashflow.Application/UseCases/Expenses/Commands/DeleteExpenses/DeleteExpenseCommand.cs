using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.DeleteExpenses;

public class DeleteExpenseCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
