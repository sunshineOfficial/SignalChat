namespace SignalChat.Models.User;

/// <summary>
/// Роль пользователя.
/// </summary>
[Flags]
public enum Role
{
    None = 0,
    User = 1,
    Admin = 2,
    All = User | Admin
}