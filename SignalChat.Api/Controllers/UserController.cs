using Microsoft.AspNetCore.Mvc;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер пользователей.
/// </summary>
[Route("api/[controller]")]
public class UserController(IUserService userService) : BaseController
{
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        return Ok(await userService.GetUser(Id));
    }
}