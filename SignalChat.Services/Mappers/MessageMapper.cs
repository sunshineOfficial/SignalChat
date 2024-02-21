using SignalChat.DataAccess.Models;
using SignalChat.Models.Message;

namespace SignalChat.Services.Mappers;

/// <summary>
/// Маппер сообщений.
/// </summary>
public static class MessageMapper
{
    /// <summary>
    /// Маппит <see cref="SendMessageRequest"/> на <see cref="DbMessage"/>.
    /// </summary>
    /// <param name="source"><see cref="SendMessageRequest"/>.</param>
    /// <returns><see cref="DbMessage"/>.</returns>
    public static DbMessage MapToDb(this SendMessageRequest source)
    {
        return source == null
            ? default
            : new DbMessage
            {
                Text = source.Text,
                ChatId = source.ChatId,
                SentOn = source.SentOn,
                UserId = source.UserId
            };
    }

    /// <summary>
    /// Маппит <see cref="DbMessage"/> на <see cref="Message"/>.
    /// </summary>
    /// <param name="source"><see cref="DbMessage"/>.</param>
    /// <returns><see cref="Message"/>.</returns>
    public static Message MapToDomain(this DbMessage source)
    {
        return source == null
            ? default
            : new Message
            {
                Id = source.Id,
                Text = source.Text,
                SentOn = source.SentOn,
                ChatId = source.ChatId,
                UserId = source.UserId
            };
    }
}