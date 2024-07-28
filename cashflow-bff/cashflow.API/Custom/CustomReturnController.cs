using cashflow.Application.Reponses;
using Microsoft.AspNetCore.Mvc;

namespace cashflow.API.Custom;

public class CustomReturnController : ControllerBase
{
    [NonAction]
    protected ActionResult ResultHandler(Exception ex)
    {
        BaseReponse errorDetailModel = new BaseReponse();

        switch (ex)
        {
            case NullReferenceException:
                errorDetailModel.MessageDetail = ex.Message;
                errorDetailModel.Status = StatusCodes.Status404NotFound;
                return NotFound(errorDetailModel);

            default:
                errorDetailModel.MessageDetail = ex.Message ?? string.Empty;
                errorDetailModel.Status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, errorDetailModel);
        }
    }
}
