using System.Text.Json.Serialization;

namespace SignalChat.Models.Chat;

/// <summary>
/// Модель запроса на создание чата.
/// </summary>
public class CreateChatRequest
{
    /// <summary>
    /// Название чата.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Id пользователей, которых нужно добавить в чат.
    /// </summary>
    public List<int> UserIds { get; set; }
    
    /// <summary>
    /// Id создателя чата.
    /// </summary>
    [JsonIgnore]
    public int CreatorId { get; set; }
}