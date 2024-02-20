using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс для репозитория чатов.
/// </summary>
public interface IChatRepository
{
    /// <summary>
    /// Начинает транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    Transaction BeginTransaction();
    
    /// <summary>
    /// Создает новый чат.
    /// </summary>
    /// <param name="chat">Новый чат.</param>
    /// <param name="transaction">Транзакция.</param>
    /// <returns>Id нового чата.</returns>
    Task<int> CreateChat(DbChat chat, Transaction transaction = null);
}