using System.Text.Json.Serialization;

namespace SignalChat.Models.User;

/// <summary>
/// Модель запроса на обновление данных пользователя.
/// </summary>
public class UpdateUserRequest
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    [JsonIgnore]
    public int Id { get; set; }
    
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string Surname { get; set; }
}