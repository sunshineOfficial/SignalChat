namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при попытке добавить пользователя в контакты еще раз.
/// </summary>
public class ContactAlreadyExistsException(int userId, int friendId) : BadRequestException($"Пользователь с id {friendId} уже есть в контактах пользователя с id {userId}");