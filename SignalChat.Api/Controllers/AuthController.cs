using Microsoft.AspNetCore.Mvc;
using SignalChat.Models.Auth;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Controllers;

/// <summary>
/// Контроллер аутентификации.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, ITokenService tokenService) : ControllerBase
{
    /// <summary>
    /// Регистрирует нового пользователя.
    /// </summary>
    /// <param name="registerModel"><see cref="RegisterModel"/>.</param>
    /// <returns><see cref="AuthResponse"/>.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        return Ok(await authService.Register(registerModel));
    }
    
    /// <summary>
    /// Аутентифицирует нового пользователя.
    /// </summary>
    /// <param name="loginModel"><see cref="LoginModel"/>.</param>
    /// <returns><see cref="AuthResponse"/>.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        return Ok(await authService.Login(loginModel));
    }

    /// <summary>
    /// Обновляет AccessToken.
    /// </summary>
    /// <param name="token">RefreshToken.</param>
    /// <returns><see cref="AuthResponse"/>.</returns>
    [HttpPut("refresh-token/{token}")]
    public async Task<IActionResult> RefreshToken(string token)
    {
        return Ok(await tokenService.RefreshToken(token));
    }
}