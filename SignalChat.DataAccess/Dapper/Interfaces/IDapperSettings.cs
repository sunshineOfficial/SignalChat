using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Dapper.Interfaces;

public interface IDapperSettings
{
    string ConnectionString { get; }
    Provider Provider { get; }
}