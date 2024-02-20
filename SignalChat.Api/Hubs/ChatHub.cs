using Microsoft.AspNetCore.SignalR;
using SignalChat.Models.Chat;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Hubs;

/// <summary>
/// Хаб чатов.
/// </summary>
public class ChatHub(IConnectionTracker connectionTracker, IChatService chatService) : BaseHub
{
    /// <summary>
    /// Создает новый чат.
    /// </summary>
    /// <param name="chat">Новый чат.</param>
    public async Task CreateChat(Chat chat)
    {
        chat.CreatorId = Id;
        var chatId = await chatService.CreateChat(chat);

        // добавляем всех подключенных пользователей в группу чата
        var addToGroupTasks = new List<Task> { Groups.AddToGroupAsync(Context.ConnectionId, $"Chat{chatId}") };
        addToGroupTasks.AddRange(connectionTracker.SelectConnectionIds(chat.UserIds)
            .Select(connectionId => Groups.AddToGroupAsync(connectionId, $"Chat{chatId}")));
        await Task.WhenAll(addToGroupTasks);

        await Clients.Caller.SendAsync("ChatCreated", chatId.ToString());
        await Clients.Group($"Chat{chatId}").SendAsync("AddedToChat", chatId.ToString(), chat.Name);
    }
    
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