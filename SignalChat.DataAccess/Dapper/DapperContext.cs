using System.Data;
using Dapper;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Dapper;

/// <summary>
/// Контекст Dapper для работы с БД.
/// </summary>
/// <typeparam name="TSettings"><see cref="IDapperSettings"/>.</typeparam>
public class DapperContext<TSettings> : IDapperContext<TSettings> where TSettings : IDapperSettings
{
    private readonly string _connectionString;
    private readonly Provider _provider;

    public DapperContext(IDapperSettings settings)
    {
        if (settings == null)
        {
            throw new ArgumentException();
        }
        
        _connectionString = settings.ConnectionString;
        _provider = settings.Provider;
    }
    
    public async Task<T> FirstOrDefault<T>(IQueryObject queryObject)
    {
        return await Execute(query => query.QueryFirstOrDefaultAsync<T>(queryObject.Sql, queryObject.Params, commandTimeout: queryObject.CommandTimeout)).ConfigureAwait(false);
    }

    public async Task<List<T>> ListOrEmpty<T>(IQueryObject queryObject)
    {
        return (await Execute(query => query.QueryAsync<T>(queryObject.Sql, queryObject.Params, commandTimeout: queryObject.CommandTimeout)).ConfigureAwait(false)).AsList();
    }

    public async Task Command(IQueryObject queryObject, ITransaction transaction = null)
    {
        await (transaction == null ? CommandExecute(queryObject) : transaction.Command(queryObject));
    }

    public async Task<T> CommandWithResponse<T>(IQueryObject queryObject, ITransaction transaction = null)
    {
        return await (transaction == null ? CommandWithResponseExecute<T>(queryObject) : transaction.CommandWithResponse<T>(queryObject));
    }

    public ITransaction BeginTransaction()
    {
        return new Transaction(_connectionString, _provider);
    }

    private async Task<T> Execute<T>(Func<IDbConnection, Task<T>> query)
    {
        using var connection = ConnectionFactory.Create(_connectionString, _provider);
        var result = await query(connection).ConfigureAwait(false);

        return result;
    }
    
    private async Task CommandExecute(IQueryObject queryObject)
    {
        await Execute(query => query.ExecuteAsync(queryObject.Sql, queryObject.Params, commandTimeout: queryObject.CommandTimeout)).ConfigureAwait(false);
    }

    private async Task<T> CommandWithResponseExecute<T>(IQueryObject queryObject)
    {
        return await Execute(query => query.QueryFirstAsync<T>(queryObject.Sql, queryObject.Params, commandTimeout: queryObject.CommandTimeout)).ConfigureAwait(false);
    }
}