using Microsoft.Extensions.Configuration;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Models.Settings;

/// <summary>
/// Настройки Dapper для SignalChatDatabase.
/// </summary>
public class SignalChatDatabase(IConfiguration configuration) : IDapperSettings
{
    public string ConnectionString => configuration.GetSection("SignalChatDatabase")["ConnectionString"];
    public Provider Provider => Enum.Parse<Provider>(configuration.GetSection("SignalChatDatabase")["Provider"]);
}