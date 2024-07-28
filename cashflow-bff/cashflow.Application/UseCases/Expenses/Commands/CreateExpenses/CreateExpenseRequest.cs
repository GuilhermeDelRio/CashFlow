using cashflow.Application.UseCases.Expenses.Reponses;
using cashflow.Domain.Enums;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;

public sealed record CreateExpenseRequest(
    string ExpenseName,
    decimal Value,
    string Category,
    Recurrence Recurrence,
    DateTime InitialDate,
    DateTime FinalDate
) : IRequest<ExpenseResponse>;