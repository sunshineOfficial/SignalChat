using Microsoft.AspNetCore.Mvc;
using SignalChat.Models.User;
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

    /// <summary>
    /// Получает список всех пользователей.
    /// </summary>
    /// <returns>Список всех пользователей.</returns>
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await userService.GetUsers());
    }

    /// <summary>
    /// Обновляет информацию о текущем пользователе.
    /// </summary>
    /// <param name="user">Новая информация о текущем пользователе.</param>
    [HttpPut("me")]
    public async Task<IActionResult> UpdateMe(User user)
    {
        user.Id = Id;
        await userService.UpdateUser(user);
        
        return Ok();
    }

    /// <summary>
    /// Удаляет текущего пользователя.
    /// </summary>
    [HttpDelete("me")]
    public async Task<IActionResult> DeleteMe()
    {
        await userService.DeleteUser(Id);
        
        return Ok();
    }
}