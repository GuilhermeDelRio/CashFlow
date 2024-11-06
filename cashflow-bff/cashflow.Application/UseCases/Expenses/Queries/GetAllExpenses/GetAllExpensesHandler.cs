using cashflow.Application.Dtos;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetAllExpenses;

public class GetAllExpensesHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseDto>>
{
    private readonly IExpensesRepository _expensesRepository;

    public GetAllExpensesHandler(IExpensesRepository expensesRepository)
    {
        _expensesRepository = expensesRepository;
    }

    public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        var expensesList = await _expensesRepository.GetAll(cancellationToken);
        return expensesList.Select(ex => new ExpenseDto
        {
            Id = ex.Id,
            ExpenseName = ex.ExpenseName,
            Value = ex.Value,
            Recurrence = ex.Recurrence,
            InitialDate = ex.InitialDate,
            FinalDate = ex.FinalDate,
            CategoryId = ex.CategoryId
        }).ToList();
    }
}
