using Microsoft.AspNetCore.Mvc;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер чатов.
/// </summary>
[Route("api/[controller]")]
public class ChatController(IChatService chatService) : BaseController
{
    /// <summary>
    /// Получает все чаты, в которых состоит пользователь.
    /// </summary>
    /// <returns>Чаты, в которых состоит пользователь.</returns>
    [HttpGet("my")]
    public async Task<IActionResult> GetMyChats()
    {
        return Ok(await chatService.GetChatsByUserId(Id));
    }

    /// <summary>
    /// Получает подробную информацию о чате.
    /// </summary>
    /// <param name="id">Id чата.</param>
    /// <returns>Подробная информация о чате.</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetChatDetails(int id)
    {
        return Ok(await chatService.GetChatDetails(id));
    }
}