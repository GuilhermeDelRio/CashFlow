using AutoMapper;
using cashflow.Domain.Interfaces;
using MediatR;

namespace cashflow.Application.UseCases.Expenses.Commands.UpdateExpenses;

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private IExpensesRepository _expensesRepository;
    private IMapper _mapper;

    public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IExpensesRepository expensesRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _expensesRepository = expensesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseToUpdate = await _expensesRepository
            .GetById(request.Id, cancellationToken);

        if (expenseToUpdate == null) throw new NullReferenceException();

        _mapper.Map(request, expenseToUpdate);
        _expensesRepository.Update(expenseToUpdate);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
