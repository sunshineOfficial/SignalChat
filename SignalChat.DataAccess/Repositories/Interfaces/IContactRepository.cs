using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс репозитория контактов.
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Начинает транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    ITransaction BeginTransaction();

    /// <summary>
    /// Создает новый контакт.
    /// </summary>
    /// <param name="contact">Новый контакт.</param>
    Task CreateContact(DbContact contact);
    
    /// <summary>
    /// Проверяет, существует ли контакт с данными id.
    /// </summary>
    /// <param name="userId">Id пользователя, создавшего запись в своих контактах.</param>
    /// <param name="friendId">Id пользователя, добавленного в контакты.</param>
    /// <returns>True, если контакт существует, иначе - False.</returns>
    Task<bool> IsContactExists(int userId, int friendId);

    /// <summary>
    /// Получает контакты пользователя по его Id.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список контактов пользователя.</returns>
    Task<List<DbContact>> GetContactsByUserId(int userId);
}