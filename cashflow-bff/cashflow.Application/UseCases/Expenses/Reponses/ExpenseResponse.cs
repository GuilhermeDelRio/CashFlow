﻿using cashflow.Domain.Enums;

namespace cashflow.Application.UseCases.Expenses.Reponses;

public sealed record ExpenseResponse(
    string ExpenseName,
    decimal Value,
    string Category,
    Recurrence Recurrence,
    DateTime InitialDate,
    DateTime FinalDate
);