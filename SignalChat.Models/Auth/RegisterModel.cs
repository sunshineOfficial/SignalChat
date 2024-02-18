namespace SignalChat.Models.Auth;

/// <summary>
/// Модель регистрации.
/// </summary>
public class RegisterModel
{
    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string Surname { get; set; }
}