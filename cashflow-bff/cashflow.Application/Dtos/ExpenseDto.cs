#nullable disable
using cashflow.Domain.Entities;
using cashflow.Domain.Enums;

namespace cashflow.Application.Dtos;

public class ExpenseDto
{
    public Guid Id { get; set; }
    public string ExpenseName { get; set; }
    public decimal Value { get; set; }
    public Recurrence Recurrence { get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
    public Guid CategoryId { get; set; }

    public static ExpenseDto ToDto(Expense expense)
    {
        return new ExpenseDto
        {
            Id = expense.Id,
            ExpenseName = expense.ExpenseName,
            Value = expense.Value,
            Recurrence = expense.Recurrence,
            InitialDate = expense.InitialDate,
            FinalDate = expense.FinalDate,
            CategoryId = expense.CategoryId
        };
    }
}
