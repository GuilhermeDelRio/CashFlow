namespace cashflow.Application.UseCases.Category.Reponses;

public sealed record CategoryResponse(
    Guid Id,
    string CategoryName,
    string Description
);