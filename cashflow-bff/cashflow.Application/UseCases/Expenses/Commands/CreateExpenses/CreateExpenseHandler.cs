using cashflow.Application.Dtos;
using cashflow.Domain.Entities;
using cashflow.Domain.Exceptions;
using cashflow.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;

public class CreateExpenseHandler : IRequestHandler<CreateExpenseRequest, ExpenseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateExpenseHandler(IUnitOfWork unitOfWork, IExpensesRepository expensesRepository,
        ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _expensesRepository = expensesRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ExpenseDto> Handle(CreateExpenseRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateExpenseValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
        {
            throw new ValidationException(validatorResult.Errors);
        }

        var category = await _categoryRepository
            .GetById(request.CategoryId, cancellationToken);

        if (category == null)
            throw new NotFoundException("Category not found.");

        var expense = new Expense
        {
            ExpenseName = request.ExpenseName,
            Value = request.Value,
            Recurrence = request.Recurrence,
            InitialDate = request.InitialDate,
            FinalDate = request.FinalDate,
            CategoryId = request.CategoryId,
        };

        _expensesRepository.Create(expense);

        await _unitOfWork.Commit(cancellationToken);

        return ExpenseDto.ToDto(expense);
    }
}
