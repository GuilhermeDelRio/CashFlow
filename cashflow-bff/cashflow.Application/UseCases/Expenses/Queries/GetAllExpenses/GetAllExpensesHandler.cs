using AutoMapper;
using cashflow.Application.UseCases.Expenses.Reponses;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseResponse>>
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IMapper _mapper;

    public GetAllExpensesHandler(IExpensesRepository expensesRepository, IMapper mapper)
    {
        _expensesRepository = expensesRepository;
        _mapper = mapper;
    }

    public async Task<List<ExpenseResponse>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        var expensesList = await _expensesRepository.GetAll(cancellationToken);
        return _mapper.Map<List<ExpenseResponse>>(expensesList);
    }
}
