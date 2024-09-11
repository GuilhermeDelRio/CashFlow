using AutoMapper;
using cashflow.Application.UseCases.Expenses.Reponses;
using cashflow.Domain.Exceptions;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetExpensesById;

public class GetExpenseByIdHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseResponse>
{
    private readonly IExpensesRepository _expenseRepository;
    private readonly IMapper _mapper;

    public GetExpenseByIdHandler(IExpensesRepository expenseRepository, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _mapper = mapper;
    }

    public async Task<ExpenseResponse> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expense = await _expenseRepository.GetById(request.Id, cancellationToken);

        if (expense == null)
            throw new NotFoundException("Expense not found.");

        return _mapper.Map<ExpenseResponse>(expense);
    }
}
