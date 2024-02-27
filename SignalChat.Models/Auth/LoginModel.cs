namespace SignalChat.Models.Auth;

/// <summary>
/// Модель входа в систему.
/// </summary>
public class LoginModel
{
    /// <summary>
    /// Логин или почта пользователя.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
}