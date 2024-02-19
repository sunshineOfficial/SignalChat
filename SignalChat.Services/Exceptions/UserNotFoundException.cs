namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого если пользователь не найден.
/// </summary>
public class UserNotFoundException(int id) : NotFoundException($"Пользователь с id {id} не найден.");