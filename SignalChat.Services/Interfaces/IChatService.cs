using SignalChat.Models.Chat;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса чатов.
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Создает новый чат.
    /// </summary>
    /// <param name="chat">Новый чат.</param>
    /// <returns>Id нового чата.</returns>
    Task<int> CreateChat(Chat chat);
}