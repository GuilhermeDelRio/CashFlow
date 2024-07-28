using MediatR;
using cashflow.Domain.Entities;
using cashflow.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;

public class CreateExpenseHandler : IRequestHandler<CreateExpenseRequest, CreateExpenseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpensesRepository _expensesRepository;
    private readonly IMapper _mapper;

    public CreateExpenseHandler(IUnitOfWork unitOfWork, IExpensesRepository expensesRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _expensesRepository = expensesRepository;
        _mapper = mapper;
    }

    public async Task<CreateExpenseResponse> Handle(CreateExpenseRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateExpenseValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
        {
            throw new ValidationException(validatorResult.Errors);
        }

        var expenses = _mapper.Map<Expense>(request);

        _expensesRepository.Create(expenses);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<CreateExpenseResponse>(expenses);
    }
}
