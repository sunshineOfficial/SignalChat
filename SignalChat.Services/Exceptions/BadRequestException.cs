namespace SignalChat.Services.Exceptions;

/// <summary>
/// Абстрактный класс исключения BadRequest.
/// </summary>
public abstract class BadRequestException(string message) : Exception(message);