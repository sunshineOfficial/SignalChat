using Microsoft.AspNetCore.Mvc;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер пользователей.
/// </summary>
[Route("api/[controller]")]
public class UserController(IUserService userService) : BaseController
{
    /// <summary>
    /// Получает информацию о пользователе по токену.
    /// </summary>
    /// <returns>Информация о текущем пользователе.</returns>
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        return Ok(await userService.GetUser(Id));
    }

    /// <summary>
    /// Получает пользователя по id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>Информация о пользователе.</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(await userService.GetUser(id));
    }
}