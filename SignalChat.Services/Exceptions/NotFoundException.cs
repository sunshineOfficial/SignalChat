namespace SignalChat.Services.Exceptions;

/// <summary>
/// Абстрактный класс исключения NotFound.
/// </summary>
public abstract class NotFoundException(string message) : Exception(message);