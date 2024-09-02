using cashflow.Application.UseCases.Category.Reponses;
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.CreateCategory;

public sealed record CreateCategoryRequest(
    string CategoryName,
    string Description
) : IRequest<CategoryResponse>;