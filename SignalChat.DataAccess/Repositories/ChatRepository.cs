using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.DataAccess.Repositories.Scripts;
using SignalChat.Models.Chat;
using SignalChat.Models.ChatParticipant;

namespace SignalChat.DataAccess.Repositories;

/// <summary>
/// Репозиторий чатов.
/// </summary>
public class ChatRepository(IDapperContext<IDapperSettings> dapperContext) : IChatRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<int> CreateChat(DbChat chat, ITransaction transaction = null)
    {
        return await dapperContext.CommandWithResponse<int>(new QueryObject(Sql.CreateChat, chat), transaction);
    }

    public async Task<bool> IsChatExists(int id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsChatExists, new { id }));
    }

    public async Task<List<DbChat>> GetChatsByUserId(int userId)
    {
        return await dapperContext.ListOrEmpty<DbChat>(new QueryObject(Sql.GetChatsByUserId, new { userId }));
    }

    public async Task<ChatDetails> GetChatDetails(int id)
    {
        var chat = await dapperContext.FirstOrDefault<DbChat>(new QueryObject(Sql.GetChatById, new { id }));

        if (chat == null)
        {
            return default;
        }
        
        var creatorTask = dapperContext.FirstOrDefault<ChatParticipantFull>(new QueryObject(Sql.GetChatParticipantFull, new { userId = chat.CreatorId, chatId = id }));
        var participantsTask = dapperContext.ListOrEmpty<ChatParticipantFull>(new QueryObject(Sql.GetChatParticipantsFullByChatId, new { chatId = id }));

        await Task.WhenAll(creatorTask, participantsTask);

        return new ChatDetails
        {
            Id = chat.Id,
            Name = chat.Name,
            Creator = creatorTask.Result,
            Participants = participantsTask.Result
        };
    }
}