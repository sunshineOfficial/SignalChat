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
}