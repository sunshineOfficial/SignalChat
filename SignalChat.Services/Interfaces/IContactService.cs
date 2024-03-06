using SignalChat.Models.Contact;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса контактов.
/// </summary>
public interface IContactService
{
    /// <summary>
    /// Добавляет пользователя в контакты.
    /// </summary>
    /// <param name="request"><see cref="AddUserToContactsRequest"/>.</param>
    Task AddUserToContacts(AddUserToContactsRequest request);
    
    /// <summary>
    /// Получает контакты пользователя по его Id.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список контактов пользователя.</returns>
    Task<List<Contact>> GetContactsByUserId(int userId);
}