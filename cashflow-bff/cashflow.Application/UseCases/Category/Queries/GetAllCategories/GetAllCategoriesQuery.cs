using cashflow.Application.UseCases.Category.Reponses;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<CategoryResponse>>
{
}
