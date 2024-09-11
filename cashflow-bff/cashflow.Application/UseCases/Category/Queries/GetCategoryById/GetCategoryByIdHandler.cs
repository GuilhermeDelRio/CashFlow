using AutoMapper;
using cashflow.Application.UseCases.Category.Reponses;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Category.Queries.GetCategoryById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(request.Id, cancellationToken);

        if (category == null) throw new NullReferenceException();

        return _mapper.Map<CategoryResponse>(category);
    }
}
