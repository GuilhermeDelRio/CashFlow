using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.UpdateExpenses;

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private IExpensesRepository _expensesRepository;

    public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IExpensesRepository expensesRepository)
    {
        _unitOfWork = unitOfWork;
        _expensesRepository = expensesRepository;
    }

    public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseToUpdate = await _expensesRepository
            .GetById(request.Id, cancellationToken);

        if (expenseToUpdate == null) throw new NullReferenceException();

        expenseToUpdate.ExpenseName = request.ExpenseName;
        expenseToUpdate.Value = request.Value;
        expenseToUpdate.Recurrence = request.Recurrence;
        expenseToUpdate.InitialDate = request.InitialDate;
        expenseToUpdate.FinalDate = request.FinalDate;
        expenseToUpdate.CategoryId = request.CategoryId;    

        _expensesRepository.Update(expenseToUpdate);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
