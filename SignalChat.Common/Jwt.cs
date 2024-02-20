using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SignalChat.Common;

/// <summary>
/// Класс для работы с JWT.
/// </summary>
public static class Jwt
{
    /// <summary>
    /// Получает id пользователя из токена.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <returns>Id пользователя.</returns>
    public static string GetId(string token)
    {
        return ParseToken(token, "userId");
    }
    
    /// <summary>
    /// Получает почту пользователя из токена.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <returns>Почта пользователя.</returns>
    public static string GetEmail(string token)
    {
        return ParseToken(token, "email");
    }
    
    /// <summary>
    /// Получает логин пользователя из токена.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <returns>Логин пользователя.</returns>
    public static string GetUsername(string token)
    {
        return ParseToken(token, "username");
    }

    /// <summary>
    /// Получает список <see cref="Claim"/>.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="username">Логин пользователя.</param>
    /// <returns>Список <see cref="Claim"/>.</returns>
    public static List<Claim> GetClaims(int id, string email, string username)
    {
        return
        [
            new Claim("userId", id.ToString()),
            new Claim("email", email),
            new Claim("username", username)
        ];
    }
    
    /// <summary>
    /// Парсит токен и получает из него указанную роль.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <param name="role">Роль.</param>
    /// <returns>Значение роли.</returns>
    private static string ParseToken(string token, string role)
    {
        if (token.Contains("Bearer "))
        {
            token = token.Split(' ')[1]; // убираем Bearer из токена
        }
        var handler = new JwtSecurityTokenHandler();
        var payload = handler.ReadJwtToken(token).Payload;

        return payload.Claims.FirstOrDefault(c => c.Type.Split('/').Last() == role)?.Value;
    }
}