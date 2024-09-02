using MediatR;
using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using cashflow.Application.UseCases.Category.Reponses;

namespace cashflow.Application.UseCases.Category.Commands.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
        {
            throw new ValidationException(validatorResult.Errors);
        }

        var category = _mapper.Map<CategoryModel>(request);

        _categoryRepository.Create(category);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<CategoryResponse>(category);
    }
}
