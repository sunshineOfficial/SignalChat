using SignalChat.Models.ChatParticipant;

namespace SignalChat.Models.Chat;

/// <summary>
/// Подробная информация о чате.
/// </summary>
public class ChatDetails
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
    /// Создатель чата.
    /// </summary>
    public ChatParticipantFull Creator { get; set; }

    /// <summary>
    /// Участники чата.
    /// </summary>
    public List<ChatParticipantFull> Participants { get; set; }
}