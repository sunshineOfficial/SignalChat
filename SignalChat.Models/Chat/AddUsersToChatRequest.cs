using System.Text.Json.Serialization;

namespace SignalChat.Models.Chat;

/// <summary>
/// Модель запроса на добавление пользователей в чат.
/// </summary>
public class AddUsersToChatRequest
{
    /// <summary>
    /// Id чата.
    /// </summary>
    public int ChatId { get; set; }

    /// <summary>
    /// Id пользователей.
    /// </summary>
    public List<int> UserIds { get; set; }

    /// <summary>
    /// Id пользователя, отправившего запрос.
    /// </summary>
    [JsonIgnore]
    public int RequestingUserId { get; set; }
}