using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс для репозитория участников чата.
/// </summary>
public interface IChatParticipantRepository
{
    /// <summary>
    /// Начинает транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    Transaction BeginTransaction();

    /// <summary>
    /// Создает нового участника чата.
    /// </summary>
    /// <param name="chatParticipant">Новый участник чата.</param>
    /// <param name="transaction">Транзакция.</param>
    Task CreateChatParticipant(DbChatParticipant chatParticipant, Transaction transaction = null);
    
    /// <summary>
    /// Создает новых участников чата.
    /// </summary>
    /// <param name="chatParticipants">Новые участники чата.</param>
    /// <param name="transaction">Транзакция.</param>
    Task CreateChatParticipants(List<DbChatParticipant> chatParticipants, Transaction transaction = null);
}