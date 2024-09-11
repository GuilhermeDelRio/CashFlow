using cashflow.Application.UseCases.Category.Reponses;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryResponse>
{
    public Guid Id { get; set; }
}
