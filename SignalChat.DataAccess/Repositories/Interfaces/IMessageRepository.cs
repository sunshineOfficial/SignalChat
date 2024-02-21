using SignalChat.DataAccess.Dapper;
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
    Transaction BeginTransaction();
    
    /// <summary>
    /// Создает новое сообщение.
    /// </summary>
    /// <param name="message">Новое сообщение.</param>
    /// <returns>Id нового сообщения.</returns>
    Task<int> CreateMessage(DbMessage message);
}