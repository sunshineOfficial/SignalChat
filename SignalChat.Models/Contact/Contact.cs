namespace SignalChat.Models.Contact;

/// <summary>
/// Модель контакта.
/// </summary>
public class Contact
{
    /// <summary>
    /// Id пользователя, создавшего запись в своих контактах.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Id пользователя, добавленного в контакты.
    /// </summary>
    public int FriendId { get; set; }

    /// <summary>
    /// Статус онлайна пользователя, добавленного в контакты.
    /// </summary>
    public bool IsOnline { get; set; }
}