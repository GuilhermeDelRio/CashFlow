using AutoMapper;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await _categoryRepository
            .GetById(request.Id, cancellationToken);

        if (categoryToUpdate == null) throw new NullReferenceException();

        _mapper.Map(request, categoryToUpdate);
        _categoryRepository.Update(categoryToUpdate);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
