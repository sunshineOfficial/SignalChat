namespace SignalChat.Models.ChatParticipant;

/// <summary>
/// Модель участника чата.
/// </summary>
public class ChatParticipant
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Id чата.
    /// </summary>
    public int ChatId { get; set; }
    
    /// <summary>
    /// Роль пользователя в чате.
    /// </summary>
    public ChatRole Role { get; set; }
}