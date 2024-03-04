using System.Text.Json.Serialization;

namespace SignalChat.Models.User;

/// <summary>
/// Модель запроса на смену пароля пользователя.
/// </summary>
public class ChangePasswordRequest
{
    /// <summary>
    /// Старый пароль пользователя.
    /// </summary>
    public string OldPassword { get; set; }

    /// <summary>
    /// Новый пароль пользователя.
    /// </summary>
    public string NewPassword { get; set; }
    
    /// <summary>
    /// Логин или почта пользователя.
    /// </summary>
    [JsonIgnore]
    public string Login { get; set; }
}