namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при попытке добавить в контакты самого себя.
/// </summary>
public class AddUserToContactsException() : BadRequestException("Вы не можете добавить в контакты самого себя.");