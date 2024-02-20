namespace SignalChat.Services.Interfaces;

/// <summary>
/// Интерфейс для учета подключенных пользователей.
/// </summary>
public interface IConnectionTracker
{
    /// <summary>
    /// Общее число подключений.
    /// </summary>
    int ConnectionsCount { get; }
    
    /// <summary>
    /// Количество подключенных пользователей.
    /// </summary>
    int ConnectedUsersCount { get; }

    /// <summary>
    /// Начинает отслеживать подключение с указанными Id подключения и пользователя.
    /// </summary>
    /// <param name="connectionId">Id подключения.</param>
    /// <param name="userId">Id подключенного пользователя.</param>
    void TrackConnection(string connectionId, int userId);

    /// <summary>
    /// Прекращает отслеживание соединения с указанным Id. 
    /// </summary>
    /// <param name="connectionId">Id подключения.</param>
    void UntrackConnection(string connectionId);
    
    /// <summary>
    /// Возвращает значение, отражающее, подключен ли пользователь с указанным Id в данный момент.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>True, если пользователь с указанным Id подключен в данный момент, иначе - false.
    /// </returns>
    bool IsUserConnected(int userId);
    
    /// <summary>
    /// Отбирает из указанного перечисления Id, соответствующие подключенным пользователям.
    /// </summary>
    /// <param name="userIds">Перечисление Id пользователей.</param>
    /// <returns>Перечисление с Id подключенных пользователей, входящих в <paramref name="userIds"/>.</returns>
    IEnumerable<int> SelectConnectedUsers(IEnumerable<int> userIds);
    
    /// <summary>
    /// Отбирает из указанного перечисления экземпляры типа <typeparamref name="TUser"/>,
    /// Id которых соответствуют подключенным пользователям.
    /// </summary>
    /// <typeparam name="TUser">Тип, представляющий некую структуру с данными пользователей, включая Id.</typeparam>
    /// <param name="users">Перечисление экземпляров типа <typeparamref name="TUser"/>, соответствующих пользователям.</param>
    /// <param name="idGetter">Делегат, получающий Id пользователя из экземпляра типа <typeparamref name="TUser"/>.</param>
    /// <returns>Перечисление с подключенными пользователями.</returns>
    IEnumerable<TUser> SelectConnectedUsers<TUser>(IEnumerable<TUser> users, Func<TUser, int> idGetter);

    /// <summary>
    /// Отбирает из указанного перечисления Id подключения, соответствующие подключенным пользователям.
    /// </summary>
    /// <param name="userIds">Перечисление Id пользователей.</param>
    /// <returns>Перечисление с Id подключений пользователей, входящих в <paramref name="userIds"/>.</returns>
    IEnumerable<string> SelectConnectionIds(IEnumerable<int> userIds);
}