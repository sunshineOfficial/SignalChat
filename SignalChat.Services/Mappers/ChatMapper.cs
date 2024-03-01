using SignalChat.DataAccess.Models;
using SignalChat.Models.Chat;

namespace SignalChat.Services.Mappers;

/// <summary>
/// Маппер чатов.
/// </summary>
public static class ChatMapper
{
    /// <summary>
    /// Маппит <see cref="CreateChatRequest"/> на <see cref="DbChat"/>.
    /// </summary>
    /// <param name="source"><see cref="CreateChatRequest"/>.</param>
    /// <returns><see cref="DbChat"/>.</returns>
    public static DbChat MapToDb(this CreateChatRequest source)
    {
        return source == null
            ? default
            : new DbChat
            {
                Name = source.Name,
                CreatorId = source.CreatorId
            };
    }
    
    /// <summary>
    /// Маппит <see cref="DbChat"/> на <see cref="Chat"/>.
    /// </summary>
    /// <param name="source"><see cref="DbChat"/>.</param>
    /// <returns><see cref="Chat"/>.</returns>
    public static Chat MapToDomain(this DbChat source)
    {
        return source == null
            ? default
            : new Chat
            {
                Id = source.Id,
                Name = source.Name,
                CreatorId = source.CreatorId
            };
    }
    
    /// <summary>
    /// Маппит список <see cref="DbChat"/> на список <see cref="Chat"/>.
    /// </summary>
    /// <param name="source">Список <see cref="DbChat"/>.</param>
    /// <returns>Список <see cref="Chat"/>.</returns>
    public static List<Chat> MapToDomain(this List<DbChat> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }
}