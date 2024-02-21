using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.ChatParticipant;
using SignalChat.Services.Interfaces;
using SignalChat.Services.Mappers;

namespace SignalChat.Services;

/// <summary>
/// Сервис участников чата.
/// </summary>
public class ChatParticipantService(IChatParticipantRepository chatParticipantRepository) : IChatParticipantService
{
    public async Task<List<ChatParticipant>> GetChatParticipantsByUserId(int userId)
    {
        var dbChatParticipants = await chatParticipantRepository.GetChatParticipantsByUserId(userId);

        return dbChatParticipants.MapToDomain();
    }
}