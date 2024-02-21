namespace SignalChat.Models.Chat;

/// <summary>
/// Модель чата.
/// </summary>
public class Chat
{
    /// <summary>
    /// Id чата.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название чата.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id создателя чата.
    /// </summary>
    public int CreatorId { get; set; }
}