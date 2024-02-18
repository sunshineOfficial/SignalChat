using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalChat.Common;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Базовый контроллер.
/// </summary>
[Authorize]
[ApiController]
public class BaseController : ControllerBase
{
    private string AuthHeader => HttpContext.Request.Headers.Authorization.ToString();

    protected int Id => int.Parse(Jwt.GetId(AuthHeader));
    protected string Email => Jwt.GetEmail(AuthHeader);
    protected string Username => Jwt.GetUsername(AuthHeader);
}