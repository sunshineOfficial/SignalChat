using System.Text.Json.Serialization;

namespace SignalChat.Models.Message;

/// <summary>
/// Модель запроса на отправку сообщения.
/// </summary>
public class SendMessageRequest
{
    /// <summary>
    /// Текст сообщения.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Id чата.
    /// </summary>
    public int ChatId { get; set; }
    
    /// <summary>
    /// Дата и время отправки сообщения.
    /// </summary>
    [JsonIgnore]
    public DateTime SentOn { get; set; }
    
    /// <summary>
    /// Id пользователя.
    /// </summary>
    [JsonIgnore]
    public int UserId { get; set; }
}