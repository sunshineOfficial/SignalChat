namespace SignalChat.DataAccess.Models;

/// <summary>
/// Модель чата в БД.
/// </summary>
public class DbChat
{
    /// <summary>
    /// Id чата.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название чата.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id создателя чата.
    /// </summary>
    public int CreatorId { get; set; }
}