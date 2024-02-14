namespace SignalChat.DataAccess.Dapper.Interfaces;

public interface ITransaction
{
    Task<T> CommandWithResponse<T>(IQueryObject queryObject);
    Task Command(IQueryObject queryObject);
    public void Commit();
    public void Rollback();
}