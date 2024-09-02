using cashflow.API.Custom;
using cashflow.Application.UseCases.Category.Commands.BulkDeleteCategory;
using cashflow.Application.UseCases.Category.Commands.CreateCategory;
using cashflow.Application.UseCases.Category.Commands.DeleteCategory;
using cashflow.Application.UseCases.Category.Commands.UpdateCategory;
using cashflow.Application.UseCases.Category.Queries.GetAllCategories;
using cashflow.Application.UseCases.Category.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cashflow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : CustomReturnController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateCategory", Name = "CreateCategory")]
    public async Task<ActionResult<CategoryResponse>> Create
        ([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
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

    [HttpGet("GetAllCategories", Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoryResponse>> GetAllCategories(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPut("UpdateCategory", Name = "UpdateCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateExpense([FromBody] UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(updateCategoryCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpDelete("DeleteCategory/{id}", Name = "DeleteCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteCategory([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var deleteCategoryCommand = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(deleteCategoryCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpPost("BulkDeleteCategories", Name = "BulkDeleteCategories")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> BulkDeleteCategories(
        [FromBody] BulkDeleteCategoryCommand bulkDeleteCategoryCommand, 
        CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(bulkDeleteCategoryCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

}
