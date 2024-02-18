using System.Security.Claims;
using SignalChat.Models.Auth;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса токенов.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Создает новый токен.
    /// </summary>
    /// <param name="claims">Перечисление <see cref="Claim"/>.</param>
    /// <param name="tokenExpiresAfterHours">Время жизни токена.</param>
    /// <returns>Новый токен.</returns>
    string CreateToken(IEnumerable<Claim> claims, int tokenExpiresAfterHours = 0);

    /// <summary>
    /// Обновляет AccessToken.
    /// </summary>
    /// <param name="refreshToken">Токен для обновления AccessToken.</param>
    /// <returns><see cref="AuthResponse"/>.</returns>
    Task<AuthResponse> RefreshToken(string refreshToken);
}