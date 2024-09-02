using AutoMapper;
using cashflow.Application.UseCases.Category.Reponses;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesList = await _categoryRepository.GetAll(cancellationToken);
        return _mapper.Map<List<CategoryResponse>>(categoriesList);
    }
}
