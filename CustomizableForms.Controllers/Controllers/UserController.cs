using Contracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomizableForms.Controllers.Controllers;

[Route("api/users")]
[Authorize(Roles = "Admin")]
[ApiController]
public class UserController(IServiceManager serviceManager, IHttpContextAccessor accessor)
    : ApiControllerBase(serviceManager, accessor)
{
    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        var token = accessor.HttpContext.Request.Cookies["AccessToken"];
        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized();
        }
        
        var currentUser = serviceManager.AuthenticationService.GetCurrentUserFromTokenAsync(token);
        
        var baseResult = await serviceManager.UserService.DeleteUserAsync(email, currentUser.Result);
        if(!baseResult.Success)
            return ProccessError(baseResult);
        
        return Ok();
    }
}