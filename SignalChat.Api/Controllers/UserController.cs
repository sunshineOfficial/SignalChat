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
    /// <param name="request">Новая информация о текущем пользователе.</param>
    [HttpPut("me")]
    public async Task<IActionResult> UpdateMe(UpdateUserRequest request)
    {
        request.Id = Id;
        await userService.UpdateUser(request);
        
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

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (Role != Role.Admin)
        {
            return Forbid();
        }

        await userService.DeleteUser(id);

        return Ok();
    }

    /// <summary>
    /// Меняет пароль пользователя.
    /// </summary>
    /// <param name="request"><see cref="ChangePasswordRequest"/>.</param>
    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        request.Login = Username;
        await userService.ChangePassword(request);
        
        return Ok();
    }
}