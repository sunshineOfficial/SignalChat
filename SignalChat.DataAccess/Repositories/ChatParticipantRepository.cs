using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.DataAccess.Repositories.Scripts;

namespace SignalChat.DataAccess.Repositories;

/// <summary>
/// Репозиторий участников чата.
/// </summary>
public class ChatParticipantRepository(IDapperContext<IDapperSettings> dapperContext) : IChatParticipantRepository
{
    public Transaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task CreateChatParticipant(DbChatParticipant chatParticipant, Transaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.CreateChatParticipant, chatParticipant), transaction);
    }

    public async Task CreateChatParticipants(List<DbChatParticipant> chatParticipants, Transaction transaction = null)
    {
        await dapperContext.Command(new QueryObject(Sql.CreateChatParticipant, chatParticipants), transaction);
    }

    public async Task<bool> IsChatParticipantExists(int userId, int chatId)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsChatParticipantExists, new { userId, chatId }));
    }
}