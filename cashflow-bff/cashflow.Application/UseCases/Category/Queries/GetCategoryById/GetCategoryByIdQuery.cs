using cashflow.Application.Dtos;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
