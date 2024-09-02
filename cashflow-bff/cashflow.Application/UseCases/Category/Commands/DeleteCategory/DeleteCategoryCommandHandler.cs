using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _categoryRepository
            .GetById(request.Id, cancellationToken);

        if (categoryToDelete == null) throw new NullReferenceException();

        _categoryRepository.Delete(categoryToDelete);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
