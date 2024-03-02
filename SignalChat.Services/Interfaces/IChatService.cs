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
    /// <param name="request">Новый чат.</param>
    /// <returns>Id нового чата.</returns>
    Task<Chat> CreateChat(CreateChatRequest request);

    /// <summary>
    /// Получает чаты по id пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Список чатов, в которых состоит пользователь.</returns>
    Task<List<Chat>> GetChatsByUserId(int userId);
    
    /// <summary>
    /// Получает подробную информацию о чате.
    /// </summary>
    /// <param name="id">Id чата.</param>
    /// <returns>Подробная информация о чате.</returns>
    Task<ChatDetails> GetChatDetails(int id);
}