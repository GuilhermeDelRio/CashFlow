using cashflow.API.Custom;
using cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;
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

    [HttpPost(Name = "CreateExpense")]
    public async Task<ActionResult<CreateExpenseResponse>> Create
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
}
