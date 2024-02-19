using SignalChat.Models.User;

namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса пользователей.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Получает пользователя по id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns><see cref="User"/>.</returns>
    Task<User> GetUser(int id);

    /// <summary>
    /// Получает список всех пользователей.
    /// </summary>
    /// <returns>Список <see cref="User"/>.</returns>
    Task<List<User>> GetUsers();
}