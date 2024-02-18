namespace SignalChat.Models.Auth.Interfaces;

/// <summary>
/// Интерфейс настроек аутентификации.
/// </summary>
public interface IAuthSettings
{
    /// <summary>
    /// Издатель токена.
    /// </summary>
    public string Issuer { get; }

    /// <summary>
    /// Потребитель токена.
    /// </summary>
    public string Audience { get; }

    /// <summary>
    /// Ключ для шифрования токена.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Время жизни токена.
    /// </summary>
    public int TokenExpiresAfterHours { get; }
}