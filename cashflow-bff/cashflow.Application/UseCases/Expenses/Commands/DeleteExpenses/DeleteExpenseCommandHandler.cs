using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.DeleteExpenses;

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
{
    private readonly IExpensesRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteExpenseCommandHandler(IExpensesRepository expenseRepository, IUnitOfWork unitOfWork)
    {
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseToDelete = await _expenseRepository
            .GetById(request.Id, cancellationToken);

        if (expenseToDelete == null) throw new NullReferenceException();

        _expenseRepository.Delete(expenseToDelete);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
