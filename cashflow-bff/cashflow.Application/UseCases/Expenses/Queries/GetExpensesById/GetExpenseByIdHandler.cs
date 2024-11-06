using cashflow.Application.Dtos;
using cashflow.Domain.Exceptions;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Queries.GetExpensesById;

public class GetExpenseByIdHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
{
    private readonly IExpensesRepository _expenseRepository;

    public GetExpenseByIdHandler(IExpensesRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<ExpenseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expense = await _expenseRepository.GetById(request.Id, cancellationToken);

        if (expense == null)
            throw new NotFoundException("Expense not found.");

        return ExpenseDto.ToDto(expense);
    }
}
