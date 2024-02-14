using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Dapper.Interfaces;

/// <summary>
/// Интерфейс настроек Dapper.
/// </summary>
public interface IDapperSettings
{
    /// <summary>
    /// Строка подключения к БД.
    /// </summary>
    string ConnectionString { get; }
    
    /// <summary>
    /// Провайдер БД.
    /// </summary>
    Provider Provider { get; }
}