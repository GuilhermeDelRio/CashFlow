using cashflow.Application.Dtos;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesList = await _categoryRepository.GetAll(cancellationToken);
        return categoriesList.Select(cat => new CategoryDto
        {
            Id = cat.Id,
            CategoryName = cat.CategoryName,
            Description = cat.Description, 
        }).ToList();
    }
}
