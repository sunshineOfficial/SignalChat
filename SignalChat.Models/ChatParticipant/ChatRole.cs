using System.Text.Json.Serialization;

namespace SignalChat.Models.ChatParticipant;

/// <summary>
/// Роль пользователя в чате.
/// </summary>
[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChatRole
{
    None = 0,
    User = 1,
    Moderator = 2,
    Admin = 4,
    Creator = 8,
    All = User | Moderator | Admin | Creator
}