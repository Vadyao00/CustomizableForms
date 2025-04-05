using CustomizableForms.Domain.ErrorModels;
using CustomizableForms.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomizableForms.Controllers.Controllers;

public class ApiControllerBase : Controller
{
    [HttpHead]
    public IActionResult ProccessError(ApiBaseResponse baseResponse)
    {
        return baseResponse switch
        {
            BadUserBadRequestResponse response => Unauthorized(),
            ApiBadRequestResponse response => BadRequest(new ErrorDetails
            {
                Message = response.Message,
                StatusCode = StatusCodes.Status400BadRequest
            }),
            _ => throw new NotImplementedException()
        };
    }
}