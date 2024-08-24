using FluentValidation;

namespace cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;

public class CreateExpenseValidator : AbstractValidator<CreateExpenseRequest>
{
    public CreateExpenseValidator()
    {
        RuleFor(x => x.ExpenseName)
            .MaximumLength(25)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(x => x.Value)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(x => x.Category)
            .MaximumLength(25)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(x => x.Recurrence)
            .NotEmpty();

        RuleFor(x => x.InitialDate)
            .NotEmpty();

        RuleFor(x => x.FinalDate)
            .NotEmpty();
    }
}
