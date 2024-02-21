namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого если чат не найден.
/// </summary>
public class ChatNotFoundException(int id) : NotFoundException($"Чат с id {id} не найден.");