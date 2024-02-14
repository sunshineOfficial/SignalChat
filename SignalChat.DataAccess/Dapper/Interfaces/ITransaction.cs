namespace SignalChat.DataAccess.Dapper.Interfaces;

/// <summary>
/// Интерфейс транзакции внутри БД.
/// </summary>
public interface ITransaction
{
    /// <summary>
    /// Выполняет команду к БД в рамках транзакции и возвращает ответ.
    /// </summary>
    /// <param name="queryObject"><see cref="IQueryObject"/>.</param>
    /// <typeparam name="T">Тип ответа.</typeparam>
    /// <returns>Ответ, который нужно получить после выполнения команды.</returns>
    Task<T> CommandWithResponse<T>(IQueryObject queryObject);
    
    /// <summary>
    /// Выполняет команду к БД в рамках транзакции.
    /// </summary>
    /// <param name="queryObject"><see cref="IQueryObject"/>.</param>
    Task Command(IQueryObject queryObject);
    
    /// <summary>
    /// Фиксирует изменения.
    /// </summary>
    public void Commit();
    
    /// <summary>
    /// Откатывает изменения.
    /// </summary>
    public void Rollback();
}