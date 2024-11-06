using cashflow.Application.Dtos;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}
