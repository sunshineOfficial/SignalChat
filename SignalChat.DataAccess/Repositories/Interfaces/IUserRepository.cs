using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Models;

namespace SignalChat.DataAccess.Repositories.Interfaces;

/// <summary>
/// Интерфейс репозитория пользователей.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Начинает транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    Transaction BeginTransaction();
    
    /// <summary>
    /// Проверяет, существует ли пользователь с данным id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>True, если пользователь существует, иначе - False.</returns>
    Task<bool> IsUserExistsById(int id);

    /// <summary>
    /// Проверяет, существует ли пользователь с данным логином.
    /// </summary>
    /// <param name="username">Логин пользователя.</param>
    /// <returns>True, если пользователь существует, иначе - False.</returns>
    Task<bool> IsUserExistsByUsername(string username);
    
    /// <summary>
    /// Проверяет, существует ли пользователь с данной почтой.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <returns>True, если пользователь существует, иначе - False.</returns>
    Task<bool> IsUserExistsByEmail(string email);

    /// <summary>
    /// Создает нового пользователя.
    /// </summary>
    /// <param name="user">Данные нового пользователя.</param>
    /// <returns>Id нового пользователя.</returns>
    Task<int> CreateUser(DbUser user);

    /// <summary>
    /// Получает пользователя по id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>Пользователь или null, если пользователь с указанными данными не найден.</returns>
    Task<DbUser> GetUser(int id);

    /// <summary>
    /// Получает пользователя по его почте и паролю.
    /// </summary>
    /// <param name="email">Почта пользователя.</param>
    /// <param name="passwordHash">Пароль пользователя.</param>
    /// <returns>Пользователь или null, если пользователь с указанными данными не найден.</returns>
    Task<DbUser> GetUser(string email, string passwordHash);

    /// <summary>
    /// Получает пользователя по RefreshToken.
    /// </summary>
    /// <param name="refreshToken">Токен для обновления AccessToken.</param>
    /// <returns>Пользователь или null, если пользователь с указанным токеном не найден.</returns>
    Task<DbUser> GetUserByRefreshToken(string refreshToken);

    /// <summary>
    /// Получает список всех пользователей.
    /// </summary>
    /// <returns>Список <see cref="DbUser"/>.</returns>
    Task<List<DbUser>> GetUsers();

    /// <summary>
    /// Обновляет RefreshToken.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <param name="refreshToken">Токен для обновления AccessToken.</param>
    /// <param name="refreshTokenExpiredAfter">Время истечения RefreshToken.</param>
    Task UpdateRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiredAfter);

    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    /// <param name="user">Новая информация о пользователе.</param>
    Task UpdateUser(DbUser user);

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    Task DeleteUser(int id);
}