#nullable disable
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.BulkDeleteCategory;

public class BulkDeleteCategoryCommand : IRequest<Unit>
{
    public List<Guid> Ids { get; set; }
}
