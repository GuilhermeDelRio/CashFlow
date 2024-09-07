#nullable disable
using cashflow.Domain.Common;
using cashflow.Domain.Enums;

namespace cashflow.Domain.Entities;

public class Expense : AuditableEntity
{
    public string ExpenseName { get; set; }
    public decimal Value { get; set; }
    public Recurrence Recurrence {  get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryModel Category { get; set; }
}
