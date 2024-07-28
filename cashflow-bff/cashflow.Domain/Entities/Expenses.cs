#nullable disable
using cashflow.Domain.Common;
using cashflow.Domain.Enums;

namespace cashflow.Domain.Entities;

public class Expenses : AuditableEntity
{
    public string ExpenseName { get; set; }
    public decimal Value { get; set; }
    public string Category {  get; set; }
    public Recurrence Recurrence {  get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
}
