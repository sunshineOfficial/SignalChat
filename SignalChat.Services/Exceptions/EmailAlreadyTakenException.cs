namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при попытке использования уже существующей почты.
/// </summary>
public class EmailAlreadyTakenException(string email) : BadRequestException($"Пользователь с почтой {email} уже существует.");