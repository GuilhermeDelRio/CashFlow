using cashflow.API.Custom;
using cashflow.Application.UseCases.Expenses.Commands.BulkDeleteExpenses;
using cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;
using cashflow.Application.UseCases.Expenses.Commands.DeleteExpenses;
using cashflow.Application.UseCases.Expenses.Commands.UpdateExpenses;
using cashflow.Application.UseCases.Expenses.Queries.GetAllExpenses;
using cashflow.Application.UseCases.Expenses.Queries.GetExpensesById;
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
        try
        {
            var response = await _mediator.Send(new GetAllExpensesQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {

            return ResultHandler(ex);
        }
    }

    [HttpGet("GetExpenseById", Name = "GetExpenseById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ExpenseResponse>> GetExpenseById(Guid Id, CancellationToken cancellationToken)
    {
        try
        {
            var expenseCommand = new GetExpenseByIdQuery { Id = Id };
            var response = await _mediator.Send(expenseCommand, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {

            return ResultHandler(ex);
        }
    }

    [HttpPut("UpdateExpense", Name = "UpdateExpense")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateExpense([FromBody] UpdateExpenseCommand updateExpenseCommand, CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(updateExpenseCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpDelete("DeleteExpense/{id}", Name = "DeleteExpense")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteExpense([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var deleteExpenseCommand = new DeleteExpenseCommand { Id = id };
            await _mediator.Send(deleteExpenseCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpPost("BulkDeleteExpenses", Name = "BulkDeleteExpenses")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> BulkDeleteExpenses(
        [FromBody] BulkDeleteExpensesCommand bulkDeleteExpensesCommand,
        CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(bulkDeleteExpensesCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

}
