using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс репозитория сообщений.
/// </summary>
public interface IMessageRepository
{
    /// <summary>
    /// Начинает транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    ITransaction BeginTransaction();
    
    /// <summary>
    /// Создает новое сообщение.
    /// </summary>
    /// <param name="message">Новое сообщение.</param>
    /// <returns>Id нового сообщения.</returns>
    Task<int> CreateMessage(DbMessage message);

    /// <summary>
    /// Получает сообщения из чата, начиная с определенной даты.
    /// </summary>
    /// <param name="chatId">Id чата.</param>
    /// <param name="from">Дата, с которой нужно получить сообщения.</param>
    /// <returns>Список сообщений.</returns>
    Task<List<DbMessage>> GetMessagesByChat(int chatId, DateTime from);
}