using SignalChat.DataAccess.Models;
using SignalChat.Models.Contact;

namespace SignalChat.Services.Mappers;

/// <summary>
/// Маппер контактов.
/// </summary>
public static class ContactMapper
{
    /// <summary>
    /// Маппит <see cref="AddUserToContactsRequest"/> на <see cref="DbContact"/>.
    /// </summary>
    /// <param name="source"><see cref="AddUserToContactsRequest"/>.</param>
    /// <returns><see cref="DbContact"/>.</returns>
    public static DbContact MapToDb(this AddUserToContactsRequest source)
    {
        return source == null
            ? default
            : new DbContact
            {
                UserId = source.UserId,
                FriendId = source.FriendId
            };
    }
}