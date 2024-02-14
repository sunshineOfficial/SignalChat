namespace SignalChat.DataAccess.Dapper.Interfaces;

/// <summary>
/// Интерфейс запроса к БД.
/// </summary>
public interface IQueryObject
{
    /// <summary>
    /// SQL-запрос к БД.
    /// </summary>
    string Sql { get; }
    
    /// <summary>
    /// Параметры, передаваемые в запрос.
    /// </summary>
    object Params { get; }
    
    /// <summary>
    /// Таймаут команды.
    /// </summary>
    int CommandTimeout { get; }
}