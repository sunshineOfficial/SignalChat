using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Message;
using SignalChat.Services.Exceptions;
using SignalChat.Services.Interfaces;
using SignalChat.Services.Mappers;

namespace SignalChat.Services;

/// <summary>
/// Сервис сообщений.
/// </summary>
public class MessageService(IMessageRepository messageRepository, IChatRepository chatRepository, IChatParticipantRepository chatParticipantRepository) : IMessageService
{
    public async Task<Message> SendMessage(SendMessageRequest request)
    {
        if (!await chatRepository.IsChatExists(request.ChatId))
        {
            throw new ChatNotFoundException(request.ChatId);
        }

        if (!await chatParticipantRepository.IsChatParticipantExists(request.UserId, request.ChatId))
        {
            throw new ChatParticipantNotFoundException(request.UserId, request.ChatId);
        }

        request.SentOn = DateTime.UtcNow;
        var dbMessage = request.MapToDb();
        dbMessage.Id = await messageRepository.CreateMessage(dbMessage);

        return dbMessage.MapToDomain();
    }

    public async Task<List<Message>> GetMessagesByChat(int userId, int chatId, DateTime from)
    {
        if (!await chatRepository.IsChatExists(chatId))
        {
            throw new ChatNotFoundException(chatId);
        }
        
        if (!await chatParticipantRepository.IsChatParticipantExists(userId, chatId))
        {
            throw new ChatParticipantNotFoundException(userId, chatId);
        }

        var dbMessages = await messageRepository.GetMessagesByChat(chatId, from);

        return dbMessages.MapToDomain();
    }

    public async Task<Message> EditMessage(EditMessageRequest request)
    {
        var message = await messageRepository.GetMessageById(request.Id);

        if (message == null)
        {
            throw new MessageNotFoundException(request.Id);
        }

        if (message.UserId != request.UserId)
        {
            throw new EditMessageException();
        }

        request.EditedOn = DateTime.UtcNow;
        await messageRepository.EditMessage(request.Id, request.EditedText, request.EditedOn.Value);

        return request.MapToDomain(message.SentOn, message.ChatId);
    }
}