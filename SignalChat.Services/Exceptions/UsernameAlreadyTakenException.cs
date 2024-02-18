namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при попытке использования уже существующего логина.
/// </summary>
public class UsernameAlreadyTakenException(string username) : BadRequestException($"Пользователь с логином {username} уже существует.");