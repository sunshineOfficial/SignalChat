using SignalChat.Models.Message;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса сообщений.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Отправляет сообщение в чат.
    /// </summary>
    /// <param name="request">Сообщение, которое будет отправлено в чат.</param>
    /// <returns><see cref="Message"/>.</returns>
    Task<Message> SendMessage(SendMessageRequest request);

    /// <summary>
    /// Получает сообщения из чата, начиная с определенной даты.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="chatId">Id чата.</param>
    /// <param name="from">Дата, с которой нужно получить сообщения.</param>
    /// <returns>Список сообщений.</returns>
    Task<List<Message>> GetMessagesByChat(int userId, int chatId, DateTime from);
}