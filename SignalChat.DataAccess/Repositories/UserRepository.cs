using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.DataAccess.Repositories.Scripts;

namespace SignalChat.DataAccess.Repositories;

/// <summary>
/// Репозиторий пользователей.
/// </summary>
public class UserRepository(IDapperContext<IDapperSettings> dapperContext) : IUserRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<bool> IsUserExistsById(int id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsUserExistsById, new { id }));
    }

    public async Task<bool> IsUserExistsByUsername(string username)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsUserExistsByUsername, new { username }));
    }
    
    public async Task<bool> IsUserExistsByEmail(string email)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsUserExistsByEmail, new { email }));
    }

    public async Task<int> CreateUser(DbUser user)
    {
        return await dapperContext.CommandWithResponse<int>(new QueryObject(Sql.CreateUser, user));
    }

    public async Task<DbUser> GetUser(int id)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(Sql.GetUserById, new { id }));
    }

    public async Task<DbUser> GetUser(string login, string passwordHash)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(Sql.GetUserByLoginAndPassword, new { login, passwordHash }));
    }

    public async Task<DbUser> GetUserByRefreshToken(string refreshToken)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(Sql.GetUserByRefreshToken, new { refreshToken }));
    }

    public async Task<List<DbUser>> GetUsers()
    {
        return await dapperContext.ListOrEmpty<DbUser>(new QueryObject(Sql.GetUsers));
    }

    public async Task UpdateRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiredAfter)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateRefreshToken, new { id, refreshToken, refreshTokenExpiredAfter }));
    }

    public async Task UpdateUser(DbUser user)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateUser, user));
    }

    public async Task DeleteUser(int id)
    {
        await dapperContext.Command(new QueryObject(Sql.DeleteUser, new { id }));
    }
}