using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
