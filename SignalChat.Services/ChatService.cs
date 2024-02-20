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
    public async Task<int> CreateChat(Chat chat)
    {
        chat.UserIds.Add(chat.CreatorId);
        foreach (var id in chat.UserIds)
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
            var chatId = await chatRepository.CreateChat(chat.MapToDb(), transaction);
            var chatParticipants = chat.UserIds.Select(id => new DbChatParticipant
            {
                UserId = id,
                ChatId = chatId,
                Role = (int)(id == chat.CreatorId ? ChatRole.Creator : ChatRole.User)
            }).ToList();
            await chatParticipantRepository.CreateChatParticipants(chatParticipants, transaction);

            transaction.Commit();

            return chatId;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}