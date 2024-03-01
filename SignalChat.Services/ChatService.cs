using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Chat;
using SignalChat.Models.ChatParticipant;
using SignalChat.Services.Exceptions;
using SignalChat.Services.Interfaces;
using SignalChat.Services.Mappers;

namespace SignalChat.Services;

/// <summary>
/// Сервис чатов.
/// </summary>
public class ChatService(IChatRepository chatRepository, IUserRepository userRepository, IChatParticipantRepository chatParticipantRepository) : IChatService
{
    public async Task<Chat> CreateChat(CreateChatRequest request)
    {
        request.UserIds.Add(request.CreatorId);
        foreach (var id in request.UserIds)
        {
            if (!await userRepository.IsUserExistsById(id))
            {
                throw new UserNotFoundException(id);
            }
        }

        // создаем чат и добавляем в него пользователей
        using var transaction = chatRepository.BeginTransaction();
        try
        {
            var dbChat = request.MapToDb();
            var chatId = await chatRepository.CreateChat(request.MapToDb(), transaction);
            var chatParticipants = request.UserIds.Select(id => new DbChatParticipant
            {
                UserId = id,
                ChatId = chatId,
                Role = (int)(id == request.CreatorId ? ChatRole.Creator : ChatRole.User)
            }).ToList();
            await chatParticipantRepository.CreateChatParticipants(chatParticipants, transaction);

            transaction.Commit();
            dbChat.Id = chatId;

            return dbChat.MapToDomain();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<List<Chat>> GetChatsByUserId(int userId)
    {
        var dbChats = await chatRepository.GetChatsByUserId(userId);

        return dbChats.MapToDomain();
    }
}