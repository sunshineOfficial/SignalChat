using Microsoft.AspNetCore.Mvc;
using SignalChat.Models.Contact;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер контактов.
/// </summary>
[Route("api/[controller]")]
public class ContactController(IContactService contactService) : BaseController
{
    /// <summary>
    /// Добавляет пользователя в контакты текущего пользователя.
    /// </summary>
    /// <param name="request"><see cref="AddUserToContactsRequest"/>.</param>
    [HttpPost("my")]
    public async Task<IActionResult> AddUserToMyContacts(AddUserToContactsRequest request)
    {
        request.UserId = Id;
        await contactService.AddUserToContacts(request);
        
        return Ok();
    }

    /// <summary>
    /// Получает контакты текущего пользователя.
    /// </summary>
    /// <returns>Список контактов текущего пользователя.</returns>
    [HttpGet("my")]
    public async Task<IActionResult> GetMyContacts()
    {
        return Ok(await contactService.GetContactsByUserId(Id));
    }
}