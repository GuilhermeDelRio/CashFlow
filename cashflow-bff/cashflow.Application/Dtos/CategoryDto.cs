#nullable disable
using cashflow.Domain.Entities;

namespace cashflow.Application.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public static CategoryDto ToDto(CategoryModel model)
    {
        return new CategoryDto
        {
            Id = model.Id,
            CategoryName = model.CategoryName,
            Description = model.Description
        };
    }
}
