namespace SignalChat.Models.ChatParticipant;

/// <summary>
/// Роль пользователя в чате.
/// </summary>
[Flags]
public enum ChatRole
{
    None = 0,
    User = 1,
    Moderator = 2,
    Admin = 4,
    Creator = 8,
    All = User | Moderator | Admin | Creator
}