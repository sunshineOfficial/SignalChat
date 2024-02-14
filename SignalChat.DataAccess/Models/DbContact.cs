namespace SignalChat.DataAccess.Models;

/// <summary>
/// Модель контакта в БД.
/// </summary>
public class DbContact
{
    /// <summary>
    /// Id пользователя, создавшего запись в своих контактах.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Id пользователя, добавленного в контакты.
    /// </summary>
    public int FriendId { get; set; }
}