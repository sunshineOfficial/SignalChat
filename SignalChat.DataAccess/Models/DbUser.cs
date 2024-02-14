namespace SignalChat.DataAccess.Models;

/// <summary>
/// Модель пользователя в БД.
/// </summary>
public class DbUser
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
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
    
    /// <summary>
    /// Хешированный пароль.
    /// </summary>
    public string PasswordHash { get; set; }
}