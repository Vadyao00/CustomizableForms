using Contracts.IServices;
using CustomizableForms.Controllers.Filters;
using CustomizableForms.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomizableForms.Controllers.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController(IServiceManager service, IHttpContextAccessor accessor) : ApiControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        var baseResult = await service.AuthenticationService.RegisterUser(userForRegistration);
        if(!baseResult.Suссess)
            return ProccessError(baseResult);
        
        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        var baseResult = await service.AuthenticationService.ValidateUser(user);
        if(!baseResult.Suссess)
            return ProccessError(baseResult);

        var tokenDto = await service.AuthenticationService.CreateToken(populateExp: true);

        var context = accessor.HttpContext;
        context.Response.Cookies.Append("AccessToken", tokenDto.AccessToken);
        context.Response.Cookies.Append("RefreshToken", tokenDto.RefreshToken);

        return Ok();
    }
}