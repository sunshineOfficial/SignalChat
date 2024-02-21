using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.DataAccess.Repositories.Scripts;

namespace SignalChat.DataAccess.Repositories;

/// <summary>
/// Репозиторий чатов.
/// </summary>
public class ChatRepository(IDapperContext<IDapperSettings> dapperContext) : IChatRepository
{
    public Transaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<int> CreateChat(DbChat chat, Transaction transaction = null)
    {
        return await dapperContext.CommandWithResponse<int>(new QueryObject(Sql.CreateChat, chat), transaction);
    }

    public async Task<bool> IsChatExists(int id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsChatExists, new { id }));
    }
}