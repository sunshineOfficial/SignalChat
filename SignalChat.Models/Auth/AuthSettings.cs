using Microsoft.Extensions.Configuration;
using SignalChat.Models.Auth.Interfaces;

namespace SignalChat.Models.Auth;

/// <summary>
/// Настройки аутентификации.
/// </summary>
public class AuthSettings(IConfiguration configuration) : IAuthSettings
{
    public string Issuer => configuration.GetSection("Auth")["Issuer"];
    public string Audience => configuration.GetSection("Auth")["Audience"];
    public string Key => configuration.GetSection("Auth")["Key"];
    public int TokenExpiresAfterHours => int.Parse(configuration.GetSection("Auth")["TokenExpiresAfterHours"]);
}