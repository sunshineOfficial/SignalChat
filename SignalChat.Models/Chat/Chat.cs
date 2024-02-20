namespace SignalChat.Models.Chat;

/// <summary>
/// Модель чата.
/// </summary>
public class Chat
{
    /// <summary>
    /// Название чата.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id создателя чата.
    /// </summary>
    public int CreatorId { get; set; }

    /// <summary>
    /// Id пользователей, которых нужно добавить в чат.
    /// </summary>
    public List<int> UserIds { get; set; }
}