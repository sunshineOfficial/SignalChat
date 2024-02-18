using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер для пинга сервиса.
/// </summary>
public class PingController : BaseController
{
    /// <summary>
    /// Пингует сервис без авторизации.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("ping")]
    public Task<IActionResult> Ping()
    {
        return Task.FromResult<IActionResult>(Ok("I'm alive!"));
    }
    
    /// <summary>
    /// Пингует сервис с авторизацией.
    /// </summary>
    [HttpGet("ping-auth")]
    public Task<IActionResult> PingAuth()
    {
        return Task.FromResult<IActionResult>(Ok("I'm alive with auth!"));
    }
}