using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.DataAccess.Repositories.Scripts;

namespace SignalChat.DataAccess.Repositories;

/// <summary>
/// Репозиторий контактов.
/// </summary>
public class ContactRepository(IDapperContext<IDapperSettings> dapperContext) : IContactRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task CreateContact(DbContact contact)
    {
        await dapperContext.Command(new QueryObject(Sql.CreateContact, contact));
    }

    public async Task<bool> IsContactExists(int userId, int friendId)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsContactExists, new { userId, friendId }));
    }
}