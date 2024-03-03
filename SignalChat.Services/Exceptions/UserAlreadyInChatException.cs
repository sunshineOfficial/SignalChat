namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при попытке добавления пользователя, который уже есть в чате.
/// </summary>
public class UserAlreadyInChatException(int userId, int chatId) : BadRequestException($"Пользователь с id {userId} уже есть в чате с id {chatId}");