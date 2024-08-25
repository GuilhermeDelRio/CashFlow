using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.BulkDeleteExpenses;

public class BulkDeleteExpensesCommandHandler : IRequestHandler<BulkDeleteExpensesCommand, Unit>
{
    private readonly IExpensesRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BulkDeleteExpensesCommandHandler(IExpensesRepository expenseRepository, IUnitOfWork unitOfWork)
    {
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(BulkDeleteExpensesCommand request, CancellationToken cancellationToken)
    {
        await _expenseRepository.BulkDelete(request.Ids, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
