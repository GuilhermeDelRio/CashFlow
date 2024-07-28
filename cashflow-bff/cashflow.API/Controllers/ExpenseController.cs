using cashflow.API.Custom;
using cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;
using cashflow.Application.UseCases.Expenses.Queries.GetAllExpenses;
using cashflow.Application.UseCases.Expenses.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cashflow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : CustomReturnController
{
    private readonly IMediator _mediator;

    public ExpenseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateExpense", Name = "CreateExpense")]
    public async Task<ActionResult<ExpenseResponse>> Create
        ([FromBody] CreateExpenseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetAllExpenses", Name = "GetAllExpenses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ExpenseResponse>> GetAllExpenses(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllExpensesQuery(), cancellationToken);
        return Ok(response);
    }
}
