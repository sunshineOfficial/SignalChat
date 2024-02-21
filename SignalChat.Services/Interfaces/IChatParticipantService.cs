using SignalChat.Models.ChatParticipant;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса участников чата.
/// </summary>
public interface IChatParticipantService
{
    /// <summary>
    /// Получает список участников чата по Id пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список участников чата.</returns>
    Task<List<ChatParticipant>> GetChatParticipantsByUserId(int userId);
}