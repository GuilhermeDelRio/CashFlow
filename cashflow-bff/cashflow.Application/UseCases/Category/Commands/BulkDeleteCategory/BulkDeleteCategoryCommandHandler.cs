using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.BulkDeleteCategory;

public class BulkDeleteCategoryCommandHandler : IRequestHandler<BulkDeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BulkDeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(BulkDeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.BulkDelete(request.Ids, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
