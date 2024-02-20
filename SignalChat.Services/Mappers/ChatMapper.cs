using SignalChat.DataAccess.Models;
using SignalChat.Models.Chat;

namespace SignalChat.Services.Mappers;

/// <summary>
/// Маппер чатов.
/// </summary>
public static class ChatMapper
{
    /// <summary>
    /// Маппит <see cref="Chat"/> на <see cref="DbChat"/>.
    /// </summary>
    /// <param name="source"><see cref="Chat"/>.</param>
    /// <returns><see cref="DbChat"/>.</returns>
    public static DbChat MapToDb(this Chat source)
    {
        return source == null
            ? default
            : new DbChat
            {
                Name = source.Name,
                CreatorId = source.CreatorId
            };
    }
}