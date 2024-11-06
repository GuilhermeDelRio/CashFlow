using cashflow.Application.Dtos;
using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace cashflow.Application.UseCases.Category.Commands.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
        {
            throw new ValidationException(validatorResult.Errors);
        }

        var category = new CategoryModel
        {
            CategoryName = request.CategoryName,
            Description = request.Description
        };

        _categoryRepository.Create(category);

        await _unitOfWork.Commit(cancellationToken);

        return CategoryDto.ToDto(category);
    }
}
