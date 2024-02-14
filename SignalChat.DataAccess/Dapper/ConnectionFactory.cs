using System.Data;
using System.Data.Common;
using Npgsql;
using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Dapper;

/// <summary>
/// Фабрика подключений к БД.
/// </summary>
public static class ConnectionFactory
{
    /// <summary>
    /// Создает подключение к БД в зависимости от провайдера.
    /// </summary>
    /// <param name="connectionString">Строка подключения к БД.</param>
    /// <param name="provider">Провайдер БД.</param>
    /// <returns><see cref="IDbConnection"/>.</returns>
    public static IDbConnection Create(string connectionString, Provider provider)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        DbConnection connection = provider switch
        {
            Provider.PostgreSQL => new NpgsqlConnection(),
            _ => throw new NotImplementedException()
        };

        connection.ConnectionString = connectionString;

        return connection;
    }
}