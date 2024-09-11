using MediatR;
using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using cashflow.Application.UseCases.Expenses.Reponses;
using cashflow.Domain.Exceptions;

namespace cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;

public class CreateExpenseHandler : IRequestHandler<CreateExpenseRequest, ExpenseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateExpenseHandler(IUnitOfWork unitOfWork, IExpensesRepository expensesRepository, 
        ICategoryRepository categoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _expensesRepository = expensesRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ExpenseResponse> Handle(CreateExpenseRequest request, CancellationToken cancellationToken)
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
        
        var expenses = _mapper.Map<Expense>(request);

        _expensesRepository.Create(expenses);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<ExpenseResponse>(expenses);
    }
}
