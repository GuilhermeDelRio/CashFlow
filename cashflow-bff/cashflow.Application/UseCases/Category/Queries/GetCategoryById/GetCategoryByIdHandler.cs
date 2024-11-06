using cashflow.Application.Dtos;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetCategoryById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(request.Id, cancellationToken);

        if (category == null) throw new NullReferenceException();

        return CategoryDto.ToDto(category);
    }
}
