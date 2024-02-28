using System.Text.Json.Serialization;

namespace SignalChat.Models.Message;

/// <summary>
/// Модель запроса на редактирование сообщения.
/// </summary>
public class EditMessageRequest
{
    /// <summary>
    /// Id сообщения.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Отредактированный текст сообщения.
    /// </summary>
    public string EditedText { get; set; }
    
    /// <summary>
    /// Id пользователя.
    /// </summary>
    [JsonIgnore]
    public int UserId { get; set; }
    
    /// <summary>
    /// Дата и время редактирования сообщения.
    /// </summary>
    [JsonIgnore]
    public DateTime? EditedOn { get; set; }
}