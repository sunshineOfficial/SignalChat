using Microsoft.AspNetCore.Mvc;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер сообщений.
/// </summary>
[Route("api/[controller]")]
public class MessageController(IMessageService messageService) : BaseController
{
    /// <summary>
    /// Получает сообщения из чата, начиная с определенной даты.
    /// </summary>
    /// <param name="chatId">Id чата.</param>
    /// <param name="from">Дата, с которой нужно получить сообщения.</param>
    /// <returns>Список сообщений.</returns>
    [HttpGet("{chatId:int}")]
    public async Task<IActionResult> GetMessagesByChat(int chatId, [FromQuery] DateTime from)
    {
        return Ok(await messageService.GetMessagesByChat(Id, chatId, from));
    }
}