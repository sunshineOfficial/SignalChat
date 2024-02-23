using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.DataAccess.Repositories.Scripts;

namespace SignalChat.DataAccess.Repositories;

/// <summary>
/// Репозиторий сообщений.
/// </summary>
public class MessageRepository(IDapperContext<IDapperSettings> dapperContext) : IMessageRepository
{
    public Transaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<int> CreateMessage(DbMessage message)
    {
        return await dapperContext.CommandWithResponse<int>(new QueryObject(Sql.CreateMessage, message));
    }

    public async Task<List<DbMessage>> GetMessagesByChat(int chatId, DateTime from)
    {
        return await dapperContext.ListOrEmpty<DbMessage>(new QueryObject(Sql.GetMessagesByChat, new { chatId, from }));
    }
}