namespace SignalChat.Models.Auth;

/// <summary>
/// Модель содержащая в себе токены.
/// </summary>
public class AuthResponse
{
    /// <summary>
    /// Токен доступа к системе.
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Токен для обновления <see cref="AccessToken"/>.
    /// </summary>
    public string RefreshToken { get; set; }
}