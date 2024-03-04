using System.Text.Json.Serialization;

namespace SignalChat.Models.Contact;

/// <summary>
/// Модель запроса на добавление пользователя в контакты.
/// </summary>
public class AddUserToContactsRequest
{
    /// <summary>
    /// Id пользователя, которого нужно добавить в контакты.
    /// </summary>
    public int FriendId { get; set; }

    /// <summary>
    /// Id пользователя, добавляющего в свои контакты.
    /// </summary>
    [JsonIgnore]
    public int UserId { get; set; }
}