using Contracts.IServices;
using CustomizableForms.Domain.Entities;
using CustomizableForms.Domain.ErrorModels;
using CustomizableForms.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomizableForms.Controllers.Controllers;

public class ApiControllerBase : Controller
{
    protected readonly IServiceManager _serviceManager;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    
    protected ApiControllerBase(IServiceManager serviceManager, IHttpContextAccessor httpContextAccessor)
    {
        _serviceManager = serviceManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    protected async Task<User> GetCurrentUserAsync()
    {
        var token = _httpContextAccessor.HttpContext?.Request.Cookies["AccessToken"];
        if (string.IsNullOrEmpty(token))
        {
            return null;
        }

        var currentUser = await _serviceManager.AuthenticationService.GetCurrentUserFromTokenAsync(token);
        return currentUser;
    }
    
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