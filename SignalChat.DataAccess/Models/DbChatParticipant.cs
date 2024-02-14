namespace SignalChat.DataAccess.Models;

/// <summary>
/// Модель участника чата в БД.
/// </summary>
public class DbChatParticipant
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
    public int Role { get; set; }
}