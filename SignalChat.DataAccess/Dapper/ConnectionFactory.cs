using System.Data;
using System.Data.Common;
using Npgsql;
using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Dapper;

public static class ConnectionFactory
{
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