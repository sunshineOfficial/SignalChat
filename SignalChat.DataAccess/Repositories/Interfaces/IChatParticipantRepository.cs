using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс репозитория участников чата.
/// </summary>
public interface IChatParticipantRepository
{
    /// <summary>
    /// Начинает транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    ITransaction BeginTransaction();

    /// <summary>
    /// Создает нового участника чата.
    /// </summary>
    /// <param name="chatParticipant">Новый участник чата.</param>
    /// <param name="transaction">Транзакция.</param>
    Task CreateChatParticipant(DbChatParticipant chatParticipant, ITransaction transaction = null);
    
    /// <summary>
    /// Создает новых участников чата.
    /// </summary>
    /// <param name="chatParticipants">Новые участники чата.</param>
    /// <param name="transaction">Транзакция.</param>
    Task CreateChatParticipants(List<DbChatParticipant> chatParticipants, ITransaction transaction = null);
    
    /// <summary>
    /// Проверяет, существует ли участник чата с данными id.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="chatId">Id чата.</param>
    /// <returns>True, если участник чата существует, иначе - False.</returns>
    Task<bool> IsChatParticipantExists(int userId, int chatId);

    /// <summary>
    /// Получает список участников чата по Id пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список участников чата.</returns>
    Task<List<DbChatParticipant>> GetChatParticipantsByUserId(int userId);
}