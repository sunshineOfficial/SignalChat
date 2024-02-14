namespace SignalChat.DataAccess.Dapper.Interfaces;

public interface IDapperContext<TSettings> where TSettings : IDapperSettings
{
    Task<T> FirstOrDefault<T>(IQueryObject queryObject);
    Task<List<T>> ListOrEmpty<T>(IQueryObject queryObject);
    Task Command(IQueryObject queryObject, Transaction transaction = null);
    Task<T> CommandWithResponse<T>(IQueryObject queryObject, Transaction transaction = null);
    Transaction BeginTransaction();
}