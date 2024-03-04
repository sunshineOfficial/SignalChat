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
    /// Добавляет пользователя в контакты.
    /// </summary>
    /// <param name="request"><see cref="AddUserToContactsRequest"/>.</param>
    [HttpPost]
    public async Task<IActionResult> AddUserToContacts(AddUserToContactsRequest request)
    {
        request.UserId = Id;
        await contactService.AddUserToContacts(request);
        
        return Ok();
    }
}