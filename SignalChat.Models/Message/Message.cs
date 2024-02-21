namespace SignalChat.Models.Message;

/// <summary>
/// Модель сообщения.
/// </summary>
public class Message
{
    /// <summary>
    /// Id сообщения.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Текст сообщения.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Дата и время отправки сообщения.
    /// </summary>
    public DateTime SentOn { get; set; }
    
    /// <summary>
    /// Id чата.
    /// </summary>
    public int ChatId { get; set; }
    
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public int UserId { get; set; }
}