using Microsoft.AspNetCore.SignalR;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Hubs;

/// <summary>
/// Хаб чатов.
/// </summary>
public class ChatHub(IConnectionTracker connectionTracker) : BaseHub
{
    public override Task OnConnectedAsync()
    {
        connectionTracker.TrackConnection(Context.ConnectionId, Id);
        
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        connectionTracker.UntrackConnection(Context.ConnectionId);
        
        return base.OnDisconnectedAsync(exception);
    }
}