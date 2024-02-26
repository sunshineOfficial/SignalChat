using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalChat.Common;
using SignalChat.Models.User;

namespace SignalChat.Api.Hubs;

/// <summary>
/// Базовый хаб.
/// </summary>
[Authorize]
public class BaseHub : Hub
{
    private string Token => Context.GetHttpContext()?.Request.Query["access_token"];
    
    protected int Id => int.Parse(Jwt.GetId(Token));
    protected Role Role => Enum.Parse<Role>(Jwt.GetRole(Token));
    protected string Email => Jwt.GetEmail(Token);
    protected string Username => Jwt.GetUsername(Token);
}