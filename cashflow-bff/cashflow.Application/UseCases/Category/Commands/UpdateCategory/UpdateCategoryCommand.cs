#nullable disable
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
