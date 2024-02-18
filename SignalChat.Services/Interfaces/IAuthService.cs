using SignalChat.Models.Auth;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса аутентификации.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрирует нового пользователя.
    /// </summary>
    /// <param name="registerModel"><see cref="RegisterModel"/>.</param>
    /// <returns><see cref="AuthResponse"/>.</returns>
    Task<AuthResponse> Register(RegisterModel registerModel);

    /// <summary>
    /// Аутентифицирует пользователя.
    /// </summary>
    /// <param name="loginModel"><see cref="LoginModel"/>.</param>
    /// <returns><see cref="AuthResponse"/>.</returns>
    Task<AuthResponse> Login(LoginModel loginModel);
}