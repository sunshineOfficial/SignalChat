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
}