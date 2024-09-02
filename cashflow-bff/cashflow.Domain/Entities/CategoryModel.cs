#nullable disable
using cashflow.Domain.Common;

namespace cashflow.Domain.Entities;

public class CategoryModel : AuditableEntity
{
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
