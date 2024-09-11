#nullable disable
using cashflow.Domain.Enums;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.UpdateExpenses;

public class UpdateExpenseCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string ExpenseName { get; set; }
    public decimal Value { get; set; }
    public Guid CategoryId { get; set; }
    public Recurrence Recurrence { get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
}
