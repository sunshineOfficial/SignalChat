namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого если сообщение не найдено.
/// </summary>
public class MessageNotFoundException(int id) : NotFoundException($"Сообщение с id {id} не найдено.");