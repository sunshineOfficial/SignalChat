namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при попытке отредактировать чужое сообщение.
/// </summary>
public class EditMessageException() : BadRequestException("Вы не можете редактировать чужое сообщение.");