using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс репозитория чатов.
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

    /// <summary>
    /// Проверяет, существует ли чат с данным id.
    /// </summary>
    /// <param name="id">Id чата.</param>
    /// <returns>True, если чат существует, иначе - False.</returns>
    Task<bool> IsChatExists(int id);
}