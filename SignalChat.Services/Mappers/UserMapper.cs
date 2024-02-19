using SignalChat.DataAccess.Models;
using SignalChat.Models.User;

namespace SignalChat.Services.Mappers;

/// <summary>
/// Маппер пользователей.
/// </summary>
public static class UserMapper
{
    /// <summary>
    /// Маппит <see cref="DbUser"/> на <see cref="User"/>.
    /// </summary>
    /// <param name="source"><see cref="DbUser"/>.</param>
    /// <returns><see cref="User"/>.</returns>
    public static User MapToDomain(this DbUser source)
    {
        return source == null
            ? default
            : new User
            {
                Id = source.Id,
                Username = source.Username,
                Email = source.Email,
                Name = source.Name,
                Surname = source.Surname
            };
    }

    public static List<User> MapToDomain(this List<DbUser> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }
}