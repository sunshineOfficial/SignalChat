namespace SignalChat.Models.Auth;

/// <summary>
/// Модель входа в систему.
/// </summary>
public class LoginModel
{
    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
}