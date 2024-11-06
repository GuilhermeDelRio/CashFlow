using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await _categoryRepository
            .GetById(request.Id, cancellationToken);

        if (categoryToUpdate == null) throw new NullReferenceException();

        categoryToUpdate.CategoryName = request.CategoryName;
        categoryToUpdate.Description = request.Description;

        _categoryRepository.Update(categoryToUpdate);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
