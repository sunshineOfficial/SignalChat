using SignalChat.DataAccess.Models;
using SignalChat.Models.ChatParticipant;

namespace SignalChat.Services.Mappers;

/// <summary>
/// Маппер участников чата.
/// </summary>
public static class ChatParticipantMapper
{
    /// <summary>
    /// Маппит <see cref="DbChatParticipant"/> на <see cref="ChatParticipant"/>.
    /// </summary>
    /// <param name="source"><see cref="DbChatParticipant"/>.</param>
    /// <returns><see cref="ChatParticipant"/>.</returns>
    public static ChatParticipant MapToDomain(this DbChatParticipant source)
    {
        return source == null
            ? default
            : new ChatParticipant
            {
                UserId = source.UserId,
                ChatId = source.ChatId,
                Role = (ChatRole)source.Role
            };
    }

    /// <summary>
    /// Маппит список <see cref="DbChatParticipant"/> на список <see cref="ChatParticipant"/>.
    /// </summary>
    /// <param name="source">Список <see cref="DbChatParticipant"/>.</param>
    /// <returns>Список <see cref="ChatParticipant"/>.</returns>
    public static List<ChatParticipant> MapToDomain(this List<DbChatParticipant> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }
}