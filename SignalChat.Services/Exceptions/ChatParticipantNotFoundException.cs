namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого если участник чата не найден.
/// </summary>
public class ChatParticipantNotFoundException(int userId, int chatId) : NotFoundException($"Пользователя с id {userId} нет в чате с id {chatId}.");