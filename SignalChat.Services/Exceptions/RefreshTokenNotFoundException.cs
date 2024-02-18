namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при отсутствии RefreshToken.
/// </summary>
public class RefreshTokenNotFoundException() : NotFoundException("RefreshToken не существует.");