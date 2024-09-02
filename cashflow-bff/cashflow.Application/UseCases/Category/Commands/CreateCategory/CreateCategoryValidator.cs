using FluentValidation;

namespace cashflow.Application.UseCases.Category.Commands.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.CategoryName)
            .MaximumLength(25)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(255)
            .MinimumLength(3)
            .NotEmpty();
    }
}
