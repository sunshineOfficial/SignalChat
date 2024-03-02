using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Models;
using SignalChat.Models.Chat;

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
    ITransaction BeginTransaction();
    
    /// <summary>
    /// Создает новый чат.
    /// </summary>
    /// <param name="chat">Новый чат.</param>
    /// <param name="transaction">Транзакция.</param>
    /// <returns>Id нового чата.</returns>
    Task<int> CreateChat(DbChat chat, ITransaction transaction = null);

    /// <summary>
    /// Проверяет, существует ли чат с данным id.
    /// </summary>
    /// <param name="id">Id чата.</param>
    /// <returns>True, если чат существует, иначе - False.</returns>
    Task<bool> IsChatExists(int id);

    /// <summary>
    /// Получает чаты по id пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список чатов, в которых состоит пользователь.</returns>
    Task<List<DbChat>> GetChatsByUserId(int userId);

    /// <summary>
    /// Получает подробную информацию о чате.
    /// </summary>
    /// <param name="id">Id чата.</param>
    /// <returns>Подробная информация о чате.</returns>
    Task<ChatDetails> GetChatDetails(int id);
}