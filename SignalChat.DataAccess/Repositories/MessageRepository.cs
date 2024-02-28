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
    public ITransaction BeginTransaction()
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

    public async Task<DbMessage> GetMessageById(int id)
    {
        return await dapperContext.FirstOrDefault<DbMessage>(new QueryObject(Sql.GetMessageById, new { id }));
    }

    public async Task<bool> IsMessageExists(int id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsMessageExists, new { id }));
    }

    public async Task EditMessage(int id, string editedText, DateTime editedOn)
    {
        await dapperContext.Command(new QueryObject(Sql.EditMessage, new { id, editedText, editedOn }));
    }
}