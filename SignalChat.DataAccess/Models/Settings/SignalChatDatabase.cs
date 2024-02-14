using Microsoft.Extensions.Configuration;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Dapper.Models;

namespace SignalChat.DataAccess.Models.Settings;

public class SignalChatDatabase : IDapperSettings
{
    private readonly IConfiguration _configuration;

    public SignalChatDatabase(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => _configuration.GetSection("SignalChatDatabase")["ConnectionString"];
    public Provider Provider => Enum.Parse<Provider>(_configuration.GetSection("SignalChatDatabase")["Provider"]);
}