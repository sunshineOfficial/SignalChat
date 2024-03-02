namespace SignalChat.Models.ChatParticipant;

/// <summary>
/// Полная информация об участнике чата.
/// </summary>
public class ChatParticipantFull
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string Surname { get; set; }
    
    /// <summary>
    /// Id чата.
    /// </summary>
    public int ChatId { get; set; }
    
    /// <summary>
    /// Роль пользователя в чате.
    /// </summary>
    public ChatRole Role { get; set; }
}