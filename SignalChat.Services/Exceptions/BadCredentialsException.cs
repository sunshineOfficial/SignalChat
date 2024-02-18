namespace SignalChat.Services.Exceptions;

/// <summary>
/// Класс исключения, выбрасываемого при вводе некорректных данных для входа в систему.
/// </summary>
public class BadCredentialsException() : BadRequestException("Некорректный логин и/или пароль.");