using cashflow.Domain.Enums;

namespace cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;

public sealed record CreateExpenseResponse(
    string ExpenseName, 
    decimal Value, 
    string Category,
    Recurrence Recurrence,
    DateTime InitialDate,
    DateTime FinalDate
);