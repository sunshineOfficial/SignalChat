using SignalChat.DataAccess.Dapper.Interfaces;

namespace SignalChat.DataAccess.Dapper.Models;

/// <summary>
/// Настройки Dapper.
/// </summary>
public class DapperSettings : IDapperSettings
{
    public string ConnectionString { get; set; }
    public Provider Provider { get; set; }
}